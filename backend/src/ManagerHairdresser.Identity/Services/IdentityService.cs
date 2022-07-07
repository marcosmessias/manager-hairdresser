using System.IdentityModel.Tokens.Jwt;
using ManagerHairdresser.Application.DTOs.Request;
using ManagerHairdresser.Application.DTOs.Response;
using ManagerHairdresser.Application.Interfaces.Services;
using ManagerHairdresser.Identity.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ManagerHairdresser.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<IdentityUser> signInManager,
                               UserManager<IdentityUser> userManager,
                               IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro)
        {
            var identityUser = new IdentityUser
            {
                UserName = usuarioCadastro.Email,
                Email = usuarioCadastro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Senha);
            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(identityUser, false);

            var usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);
            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));

            return usuarioCadastroResponse;
        }

        public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
            if (result.Succeeded)
                return await GerarCredenciais(usuarioLogin.Email);

            var usuarioLoginResponse = new UsuarioLoginResponse();
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
            }

            return usuarioLoginResponse;
        }

        public async Task<UsuarioLoginResponse> LoginSemSenha(string usuarioId)
        {
            var usuarioLoginResponse = new UsuarioLoginResponse();
            var usuario = await _userManager.FindByIdAsync(usuarioId);

            if (await _userManager.IsLockedOutAsync(usuario))
                usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
            else if (!await _userManager.IsEmailConfirmedAsync(usuario))
                usuarioLoginResponse.AdicionarErro("Essa conta precisa confirmar seu e-mail antes de realizar o login");

            if (usuarioLoginResponse.Sucesso)
                return await GerarCredenciais(usuario.Email);

            return usuarioLoginResponse;
        }

        private async Task<UsuarioLoginResponse> GerarCredenciais(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            var accessToken = GerarToken(dataExpiracaoAccessToken);
            var refreshToken = GerarToken(dataExpiracaoRefreshToken);

            return new UsuarioLoginResponse
            (
                sucesso: true,
                accessToken: accessToken,
                refreshToken: refreshToken
            );
        }

        private string GerarToken(DateTime dataExpiracao)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}

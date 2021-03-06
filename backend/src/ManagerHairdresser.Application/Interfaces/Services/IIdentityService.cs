using ManagerHairdresser.Application.DTOs.Request;
using ManagerHairdresser.Application.DTOs.Response;

namespace ManagerHairdresser.Application.Interfaces.Services;

public interface IIdentityService
{
    Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);
    Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin);
    Task<UsuarioLoginResponse> LoginSemSenha(string usuarioId);
}

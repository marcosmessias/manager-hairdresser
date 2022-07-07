using System.ComponentModel.DataAnnotations;

namespace ManagerHairdresser.Application.DTOs.Request;

public class UsuarioLoginRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; } = String.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Senha { get; set; } = String.Empty;
}

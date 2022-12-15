using System.ComponentModel.DataAnnotations;

namespace api_project.Dto.Client;

public class CreateClientReq
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(
        100,
        MinimumLength = 3,
        ErrorMessage = "O nome deve ter no mínimo {2} caracteres"
    )]
    public string Name { get; set; }

    [Required(ErrorMessage = "{0} é um campo obrigatório")]
    [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Insira um email válido")]
    public string Email { get; set; }

    [Required]
    [RegularExpression(
        "^(?=.*[A-Za-z])(?=.*?[0-9]){8,}$",
        ErrorMessage = "A senha deve ter no mínimo 8 caracteres, uma letra e um número"
    )]
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

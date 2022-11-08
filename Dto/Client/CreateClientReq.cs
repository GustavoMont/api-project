using System.ComponentModel.DataAnnotations;

namespace api_project.Dto.Client;

public class CreateClientReq
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "{0} é um campo obrigatório")]
    [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Insira um email válido")]
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace order_manager.Dto.Professional;

public class CreateProfessionalReq
{
    [Required(ErrorMessage = "O cargo é um campo obrigatório!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O cargo precisa ter entre {2} e {1} caracteres")]
    public string Ocupation { get; set; }
    [Required(ErrorMessage = "O nome é um campo obrigatório!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome precisa ter entre {2} e {1} caracteres")]
    public string Name { get; set; }
    [Required(ErrorMessage = "{0} é um campo obrigatório!")]
    [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Insira um e-mail válido")]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
}

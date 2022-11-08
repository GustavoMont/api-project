using System.ComponentModel.DataAnnotations;

namespace order_manager.Dto.Firm;

public class CreateFirmReq
{
    [Required(ErrorMessage = "Nome é um campo obrigatório")]
    [StringLength(
        100,
        MinimumLength = 3,
        ErrorMessage = "O nome deve ter entre {1} a {2} caracteres"
    )]
    public string Name { get; set; }

    [Required(ErrorMessage = "O CNPJ é um campo obrigatório")]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "Insira um CNPJ válido")]
    public string Cnpj { get; set; }

    [Required(ErrorMessage = "O Email é um campo obrigatório")]
    [StringLength(100, MinimumLength = 10)]
    [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Insira um email válido")]
    public string Email { get; set; }
}

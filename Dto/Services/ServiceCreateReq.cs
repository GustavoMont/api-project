using System.ComponentModel.DataAnnotations;

namespace api_project.Dto.Services;

public class ServiceCreateReq
{
    [Required(ErrorMessage = "Nome é um campo obrigatório")]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "O nome deve ter entre {2} e {1}")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Preço é um campo obrigatório")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Descrição é um campo obrigatório")]
    [StringLength(
        200,
        MinimumLength = 50,
        ErrorMessage = "A Descrição deve ter entre {2} e {1} caractéries"
    )]
    public string Description { get; set; }

    [Required(ErrorMessage = "O serviço deve ter um tipo.")]
    public int? ServiceTypeId { get; set; }

    [Required(ErrorMessage = "O serviço deve ser atribuído a uma empresa.")]
    public int? FirmId { get; set; }
}

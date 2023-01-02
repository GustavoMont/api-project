using System.ComponentModel.DataAnnotations;

namespace api_project.Dto.Contract;

public class CreateContract
{
    [Required]
    public int? ServiceId { get; set; }

    [Required]
    [StringLength(
        200,
        MinimumLength = 25,
        ErrorMessage = "Por favor detalhe mais como você quer esse serviço"
    )]
    public string Description { get; set; }
}

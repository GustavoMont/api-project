using System.ComponentModel.DataAnnotations;
using api_project.Models;

namespace api_project.Dto.ContractStatus;

public class CreateContractStatus
{
    [Required]
    [StringLength(40, MinimumLength = 5)]
    public string Name { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 10)]
    public string Description { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace api_project.Dto.ContractStatus;

public class CreateContractStatus
{
    [Required]
    [StringLength(40, MinimumLength = 5)]
    public string Name { get; set; }

    internal object Adpt()
    {
        throw new NotImplementedException();
    }
}

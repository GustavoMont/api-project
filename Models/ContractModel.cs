using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_project.Models;

public class Contract
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Description { get; set; }
    public DateTime ExpectDeadeline { get; set; }
    public DateTime CompletedAt { get; set; }
    public bool IsPaid { get; set; }
    public DateTime PaidAt { get; set; }
    public int StatusId { get; set; }
    public ContractStatus Status { get; set; }
    public Client Client { get; set; }

    [Required]
    public int ClientId { get; set; }
    public Service Service { get; set; }

    [Required]
    public int ServiceId { get; set; }
}

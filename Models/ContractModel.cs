using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_project.Models;

public class Contract
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "text")]
    public string Description { get; set; }
    public Client Client { get; set; }
    public int ClientId { get; set; }
    public Service Service { get; set; }
    public int ServiceId { get; set; }
}

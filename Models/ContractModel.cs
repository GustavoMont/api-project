using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_manager.Models;

public class Contract
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "text")]
    public string Description { get; set; }
    public Client Client { get; set; }
    public Service Service { get; set; }
    public int CientId { get; set; }
    public int ServiceId { get; set; }
}

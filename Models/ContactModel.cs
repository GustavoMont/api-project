using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_manager.Models;

public class Contact
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(10)")]
    public string Type { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Value { get; set; }
    public List<Client> User { get; set; }
    public int ClientId { get; set; }

}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api_project.Models;

public class ClientContact
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(10)")]
    public string Type { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Value { get; set; }
    public Client Client { get; set; }
    public int ClientId { get; set; }

}

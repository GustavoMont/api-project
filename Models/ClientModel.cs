using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_project.Models;

public class Client
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Client()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    public void Update()
    {
        UpdatedAt = DateTime.Now;
    }
    [Required]
    [Column(TypeName = "varchar(10)")]
    public string Type { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; }
    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Password { get; set; }
    public List<ClientContact> Contacts { get; set; }
    public List<Contract> Contract { get; set; }
}

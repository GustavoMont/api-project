using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_project.Models;

public class Firm
{
    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Firm()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update()
    {
        UpdatedAt = DateTime.Now;
    }

    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(18)")]
    public string Cnpj { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; }
    public List<Service> Services { get; set; }
    public List<Professional> Professionals { get; set; }
}

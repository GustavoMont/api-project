using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_project.Models;

public class Service
{
    public Service()
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
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    [Required]
    [Column(TypeName = "varchar(40)")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Description { get; set; }

    [Required]
    [Column(TypeName = "float(10)")]
    public decimal Price { get; set; }

    [Required]
    [Column(TypeName = "int(4)")]
    public int Duration { get; set; }

    public List<Contract> Contract { get; set; }

    public Firm Firm { get; set; }

    [Required]
    public int FirmId { get; set; }
    public List<Professional> Professionals { get; set; }

    [Required]
    public int ServiceTypeId { get; set; }
    public ServiceType ServiceType { get; set; }
}

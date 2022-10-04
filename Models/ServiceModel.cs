using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_manager.Models;

public class Service
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
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
    [Column(TypeName = "varchar(40)")]
    public string Name { get; set; }
    [Required]
    [Column(TypeName = "text")]
    public string Description { get; set; }
    [Required]
    [Column(TypeName = "float(10)")]
    public decimal Price { get; set; }
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime CompletionDeadline { get; set; }
    public List<Contract> Contract { get; set; }
    public int ContractId { get; set; }
    public Firm Firm { get; set; }
    public int FirmId { get; set; }
    public List<Professional> Professionals { get; set; }
}

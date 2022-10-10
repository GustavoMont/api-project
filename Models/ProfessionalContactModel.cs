using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_project.Models;

public class ProfessionalContact
{
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(10)")]
    public string Type { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Value { get; set; }
    public Professional Professional { get; set; }
    public int ProfessionalId { get; set; }

}

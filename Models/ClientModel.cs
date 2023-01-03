using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_project.Models;

[Index(nameof(Email), IsUnique = true)]
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
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    private string _password;
    public string Password
    {
        get { return _password; }
        set { _password = BCrypt.Net.BCrypt.HashPassword(value); }
    }

    public List<ClientContact> Contacts { get; set; }
    public List<Contract> Contracts { get; set; }
}

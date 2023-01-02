using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_project.Models;

public enum ContractStatusName
{
    Aguardando_Analise,
    Em_Analise,
    Rejeitado,
    Aguardando_Execucao,
    Em_Execucao,
    Finalizado
}

[Index(nameof(Name), IsUnique = true)]
public class ContractStatus
{
    public int Id { get; set; }

    [Required]
    public ContractStatusName Name { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Description { get; set; }

    public List<Contract> Contracts { get; set; }
}

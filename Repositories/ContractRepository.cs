using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Repositories;

public class ContractRepository
{
    private readonly Context _context;

    public ContractRepository([FromServices] Context context)
    {
        _context = context;
    }

    public Contract Create(Contract newContract)
    {
        _context.Contracts.Add(newContract);
        _context.SaveChanges();
        return newContract;
    }
}

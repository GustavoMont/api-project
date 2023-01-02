using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Repositories;

public class ContractStatusRepository
{
    private readonly Context _context;

    public ContractStatusRepository([FromServices] Context context)
    {
        _context = context;
    }

    public ContractStatus Create(ContractStatus newContractStatus)
    {
        _context.ContractStatus.Add(newContractStatus);
        _context.SaveChanges();
        return newContractStatus;
    }

    public List<ContractStatus> GetAll()
    {
        return _context.ContractStatus.AsNoTracking().ToList();
    }
}

using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        _context.Contracts
            .Include(c => c.Client)
            .Include(c => c.Firm)
            .Include(c => c.Status)
            .Include(c => c.Service);
        _context.SaveChanges();
        return newContract;
    }

    public List<Contract> GetAll()
    {
        return _context.Contracts
            .AsNoTracking()
            .Include(c => c.Client)
            .Include(c => c.Firm)
            .Include(c => c.Status)
            .Include(c => c.Service)
            .ToList();
    }

    public Contract GetOne(int id, bool tracking = true)
    {
        var getter = _context.Contracts
            .Include(c => c.Client)
            .Include(c => c.Firm)
            .Include(c => c.Status)
            .Include(c => c.Service);

        return tracking
            ? getter.FirstOrDefault(c => c.Id == id)
            : getter.AsNoTracking().FirstOrDefault(c => c.Id == id);
    }

    public void Update()
    {
        _context.SaveChanges();
    }
}

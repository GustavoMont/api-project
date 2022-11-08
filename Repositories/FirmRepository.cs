using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace order_manager.Repositories;

public class FirmRepository
{
    private Context _contextDb;

    public FirmRepository([FromServices] Context context)
    {
        _contextDb = context;
    }

    public Firm CreateFirm(Firm firm)
    {
        _contextDb.Firms.Add(firm);
        _contextDb.SaveChanges();
        return firm;
    }

    public List<Firm> GetAllFirm()
    {
        var firms = _contextDb.Firms.AsNoTracking().ToList();
        return firms;
    }

    public Firm GetOneFirm(int id, bool tracking = true)
    {
        return tracking
            ? _contextDb.Firms.AsNoTracking().FirstOrDefault(firm => firm.Id == id)
            : _contextDb.Firms.FirstOrDefault(firm => firm.Id == id);
    }

    public void UpdateFirm()
    {
        _contextDb.SaveChanges();
    }

    public void DeleteFirm(Firm firm)
    {
        _contextDb.Remove(firm);
        _contextDb.SaveChanges();
    }
}

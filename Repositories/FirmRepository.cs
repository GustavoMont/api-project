using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;
namespace order_manager.Repositories;

public class FirmRepository
{

    private Context _context;

    public FirmRepository([FromServices] Context context)
    {
        _context = context;
    }
    public void CreateFirm(Firm firm) 
    {
      _context.Firms.Add(firm);
      _context.SaveChanges();

    }
}

using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace order_manager.Repositories;


public class ProfessionalRepository
{

    private Context _context;

    public ProfessionalRepository([FromServices] Context context)
    {
      _context = context;
    }
    public Professional CreateProfessional(Professional professional)
    { 
      _context.Professionals.Add(professional);
      _context.SaveChanges();

      return professional;
    }

    public List<Professional> GetAllProfessionals()
    {
      return _context.Professionals.ToList();
    }

    public Professional GetOneProfessional(int id)
    {
      return _context.Professionals.FirstOrDefault( professional => professional.Id == id);
    }

     public void UpdateProfessional()
    {
      _context.SaveChanges();
    } 
    public void DeleteProfessional(Professional professional)
    {
      _context.Remove(professional);
      _context.SaveChanges();
    }
   
}

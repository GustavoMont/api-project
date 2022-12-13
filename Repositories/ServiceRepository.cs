using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Repositories;

public class ServiceRepository
{
    private readonly Context _context;

    public ServiceRepository([FromServices] Context context)
    {
        _context = context;
    }

    public Service CreateService(Service service)
    {
        _context.Services.Add(service);
        _context.SaveChanges();
        return service;
    }

    public List<Service> GetAllServices()
    {
        return _context.Services.AsNoTracking().ToList();
    }

    public Service GetOneService(int id, bool tracking = true)
    {
        return tracking
            ? _context.Services.FirstOrDefault(s => s.Id == id)
            : _context.Services.AsNoTracking().FirstOrDefault(s => s.Id == id);
    }
}

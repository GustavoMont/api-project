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

    public Service CreateService(Service newService)
    {
        _context.Services.Add(newService);
        _context.SaveChanges();
        return newService;
    }

    public List<Service> GetAllServices()
    {
        return _context.Services
            .AsNoTracking()
            .Include(service => service.ServiceType)
            .Include(service => service.Firm)
            .ToList();
    }

    public Service GetOneService(int id, bool tracking = true)
    {
        return tracking
            ? _context.Services
                .Include(service => service.ServiceType)
                .Include(service => service.Firm)
                .FirstOrDefault(service => service.Id == id)
            : _context.Services
                .AsNoTracking()
                .Include(service => service.ServiceType)
                .Include(service => service.Firm)
                .FirstOrDefault(service => service.Id == id);
    }
}

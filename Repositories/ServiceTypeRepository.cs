using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Repositories;

public class ServiceTypeRepository
{
    private readonly Context _context;

    public ServiceTypeRepository([FromServices] Context context)
    {
        _context = context;
    }

    public ServiceType CreateServiceType(ServiceType newServiceType)
    {
        _context.ServiceTypes.Add(newServiceType);
        _context.SaveChanges();
        return newServiceType;
    }

    public List<ServiceType> GetAllServiceTypes()
    {
        return _context.ServiceTypes.AsNoTracking().ToList();
    }

    public ServiceType GetOneServiceType(int id, bool tracking = true)
    {
        return tracking
            ? _context.ServiceTypes.FirstOrDefault(type => type.Id == id)
            : _context.ServiceTypes.AsNoTracking().FirstOrDefault(type => type.Id == id);
    }

    public void UpdateServiceType()
    {
        _context.SaveChanges();
    }

    public void DeleteServiceType(ServiceType serviceType)
    {
        _context.Remove(serviceType);
        _context.SaveChanges();
    }
}

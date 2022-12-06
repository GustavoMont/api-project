using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;

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
}

using api_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Controllers;

public class ServiceController
{
    private readonly ServiceServices _services;

    public ServiceController([FromServices] ServiceServices service)
    {
        _services = service;
    }
}

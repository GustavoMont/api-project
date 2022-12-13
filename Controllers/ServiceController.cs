using api_project.Dto.Services;
using api_project.errors;
using api_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Controllers;

[ApiController]
[Route("services")]
public class ServiceController : ControllerBase
{
    private readonly ServiceServices _services;

    public ServiceController([FromServices] ServiceServices service)
    {
        _services = service;
    }

    [HttpPost]
    public ActionResult<ServiceRes> CreateService([FromBody] ServiceCreateReq newService)
    {
        return StatusCode(201, _services.CreateService(newService));
    }

    [HttpGet]
    public ActionResult<List<ServiceRes>> GetAllServices()
    {
        try
        {
            return Ok(_services.GetAllServices());
        }
        catch (NotFoundException err)
        {
            return NotFound(new { message = err.Message });
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<List<ServiceRes>> GetOneService([FromRoute] int id)
    {
        try
        {
            return Ok(_services.GetOneService(id));
        }
        catch (NotFoundException err)
        {
            return NotFound(new { message = err.Message });
        }
    }
}

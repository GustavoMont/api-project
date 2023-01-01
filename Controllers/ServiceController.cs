using api_project.Dto.Services;
using api_project.errors;
using api_project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Controllers;

[ApiController]
[Route("services")]
public class ServiceController : ControllerBase
{
    private readonly ServiceServices _service;

    public ServiceController([FromServices] ServiceServices service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Firm")]
    public ActionResult<ServiceRes> CreateService([FromBody] ServiceCreateReq newService)
    {
        try
        {
            return StatusCode(201, _service.CreateService(newService));
        }
        catch (BadHttpRequestException err)
        {
            return BadRequest(new { message = err.Message });
        }
        catch (Exception err)
        {
            return StatusCode(500, new { message = err.Message });
        }
    }

    [HttpGet]
    public ActionResult<List<ServiceRes>> GetAllServices()
    {
        try
        {
            return Ok(_service.GetAllServices());
        }
        catch (NotFoundException err)
        {
            return NotFound(new { message = err.Message });
        }
        catch (Exception err)
        {
            return StatusCode(500, new { message = err.Message });
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<ServiceRes> GetOneService([FromRoute] int id)
    {
        try
        {
            return Ok(_service.GetOneService(id));
        }
        catch (NotFoundException err)
        {
            return NotFound(new { message = err.Message });
        }
        catch (Exception err)
        {
            return StatusCode(500, new { message = err.Message });
        }
    }
}

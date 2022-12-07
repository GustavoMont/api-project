using api_project.Dto.ServiceType;
using api_project.errors;
using api_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Controllers;

[ApiController]
[Route("service-types")]
public class ServiceTypeController : ControllerBase
{
    private readonly ServiceTypeService _service;

    public ServiceTypeController([FromServices] ServiceTypeService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ServiceTypeRes>> GetAllServicesTypes()
    {
        try
        {
            return Ok(_service.GetAllServiceTypes());
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<ServiceTypeRes> GetOneServiceType([FromRoute] int id)
    {
        try
        {
            return Ok(_service.GetOneServiceType(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpPost]
    public ActionResult<ServiceTypeRes> CreateServiceType(
        [FromBody] ServiceTypeCreateUpdateReq newServiceType
    )
    {
        return Ok(_service.CreateServiceType(newServiceType));
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult<ServiceTypeRes> UpdateServiceType(
        [FromRoute] int id,
        [FromBody] ServiceTypeCreateUpdateReq newServiceType
    )
    {
        try
        {
            return Ok(_service.UpdateServiceType(id, newServiceType));
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult DeleteServiceType([FromRoute] int id)
    {
        try
        {
            _service.DeleteServiceType(id);
            return NoContent();
        }
        catch (NotFoundException err)
        {
            return NotFound(new { message = err.Message });
        }
    }
}

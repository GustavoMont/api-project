using api_project.Dto.Firm;
using api_project.errors;
using Microsoft.AspNetCore.Mvc;
using order_manager.Dto.Firm;
using order_manager.Services;

namespace order_manager.Controllers;

[ApiController]
[Route("/firms")]
public class FirmController : ControllerBase
{
    private FirmServices _services;

    public FirmController([FromServices] FirmServices services)
    {
        _services = services;
    }

    [HttpPost]
    public ActionResult<FirmRes> PostFirm([FromBody] CreateFirmReq newFirmReq)
    {
        return Ok(_services.CreateFirm(newFirmReq));
    }

    [HttpGet]
    public ActionResult<List<FirmRes>> GetAllFirms()
    {
        try
        {
            return Ok(_services.GetAllFirms());
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<FirmRes> GetOneFirm([FromRoute] int id)
    {
        try
        {
            var user = _services.GetOneFirm(id, false);
            return Ok(user);
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<FirmRes> UpdateFirm([FromRoute] int id, [FromBody] CreateFirmReq firm)
    {
        try
        {
            return Ok(_services.UpdateFirm(id, firm));
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteFirm([FromRoute] int id)
    {
        try
        {
            _services.DeleteFirm(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}

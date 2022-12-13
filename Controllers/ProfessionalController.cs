using Microsoft.AspNetCore.Mvc;
using api_project.Dto.Professional;
using api_project.Services;

namespace api_project.Controllers;

[ApiController]
[Route("professionals")]
public class ProfessionalController : ControllerBase
{
    private readonly ProfessionalServices _services;

    public ProfessionalController([FromServices] ProfessionalServices services)
    {
        _services = services;
    }

    [HttpGet]
    public ActionResult<List<GetProfessionalRes>> GetAllProfessionals()
    {
        return Ok(_services.GetAllProfessionals());
    }

    [HttpGet("{id:int}")]
    public ActionResult<GetProfessionalRes> GetProfessional([FromRoute] int id)
    {
        try
        {
            return Ok(_services.GetOneProfessional(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public ActionResult<GetProfessionalRes> PostProfessional(
        [FromBody] CreateProfessionalReq newProfessionalReq
    )
    {
        var reply = _services.CreateProfessional(newProfessionalReq);
        return CreatedAtAction(nameof(GetProfessional), new { id = reply.Id }, reply);
    }

    [HttpPut("{id:int}")]
    public ActionResult<GetProfessionalRes> PutProfessional(
        [FromRoute] int id,
        [FromBody] CreateProfessionalReq professional
    )
    {
        try
        {
            return Ok(_services.UpdateProfessional(id, professional));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteProfessional([FromRoute] int id)
    {
        try
        {
            _services.DeleteProfessional(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}

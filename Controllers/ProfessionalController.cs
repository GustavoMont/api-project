using Microsoft.AspNetCore.Mvc;
using api_project.Dto.Professional;
using api_project.Services;

namespace api_project.Controllers;

[ApiController]
[Route("professionals")]
public class ProfessionalController : ControllerBase
{
    private ProfessionalServices _services;

    public ProfessionalController([FromServices] ProfessionalServices services)
    {
        _services = services;
    }

    [HttpPost]
    public GetProfessionalRes PostProfessional([FromBody] CreateProfessionalReq newProfessionalReq)
    {
        return _services.CreateProfessional(newProfessionalReq);
    }

    [HttpGet]
    public List<GetProfessionalRes> GetAllProfessionals()
    {
        return _services.GetAllProfessionals();
    }

    [HttpGet("{id:int}")]
    public GetProfessionalRes GetProfessional([FromRoute] int id)
    {
        return _services.GetOneProfessional(id);
    }

    [HttpPut("{id:int}")]
    public GetProfessionalRes PutProfessional(
        [FromRoute] int id,
        [FromBody] CreateProfessionalReq professional
    )
    {
        return _services.UpdateProfessional(id, professional);
    }

    [HttpDelete("{id:int}")]
    public void DeleteProfessional([FromRoute] int id)
    {
        _services.DeleteProfessional(id);
    }
}
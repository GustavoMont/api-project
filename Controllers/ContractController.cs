using api_project.Dto.Contract;
using api_project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Controllers;

[ApiController]
[Route("contracts")]
public class ContractController : ControllerBase
{
    private readonly ContractService _service;

    public ContractController([FromServices] ContractService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize(Roles = "Client")]
    public ActionResult<ContractRequested> Create([FromBody] CreateContract newContract)
    {
        try
        {
            return StatusCode(201, _service.Create(newContract));
        }
        catch (Exception err)
        {
            return BadRequest(new { message = err.Message, cause = err.Data });
        }
    }
}

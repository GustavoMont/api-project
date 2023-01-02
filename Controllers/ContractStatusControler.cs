using api_project.Dto.ContractStatus;
using api_project.errors;
using api_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Controllers;

[ApiController]
[Route("contract-status")]
public class ContractStatusController : ControllerBase
{
    private readonly ContractStatusService _service;

    public ContractStatusController([FromServices] ContractStatusService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<ContractStatusRes> Create([FromBody] CreateContractStatus newContractStatus)
    {
        try
        {
            return StatusCode(201, _service.Create(newContractStatus));
        }
        catch (Exception err)
        {
            return BadRequest(new { message = err.Message });
        }
    }

    [HttpGet]
    public ActionResult<List<ContractStatusRes>> GetAll()
    {
        try
        {
            return Ok(_service.GetAll());
        }
        catch (NotFoundException err)
        {
            return NotFound(new { message = err.Message });
        }
        catch (Exception err)
        {
            return BadRequest(new { message = err.Message });
        }
    }
}

using api_project.Dto.Contract;
using api_project.errors;
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

    [HttpGet]
    public ActionResult<List<ContractRequested>> GetAll()
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

    [HttpGet]
    [Authorize]
    [Route("{id:int}")]
    public ActionResult<ContractAcceptRes> GetOne([FromRoute] int id)
    {
        try
        {
            return Ok(_service.GetOne(id));
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

    [HttpPatch]
    [Route("{id:int}/finish")]
    [Authorize(Roles = "Firm")]
    public ActionResult<ContractAcceptRes> FinishContract([FromRoute] int id)
    {
        try
        {
            return Ok(_service.FinishContract(id));
        }
        catch (Exception err)
        {
            return BadRequest(new { message = err.Message });
        }
    }

    [HttpPatch]
    [Authorize]
    [Route("{id:int}")]
    public ActionResult<ContractAcceptRes> ChangeStatus(
        [FromRoute] int id,
        [FromBody] ChangeContractStatus changes
    )
    {
        try
        {
            return Ok(_service.ChangeStatus(id, changes));
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

    [HttpPut]
    [Route("{id:int}")]
    [Authorize(Roles = "Firm")]
    public ActionResult<ContractAcceptRes> Update(
        [FromRoute] int id,
        [FromBody] UpdateContract updates
    )
    {
        try
        {
            return Ok(_service.Update(id, updates));
        }
        catch (Exception err)
        {
            return BadRequest(new { message = err.Message });
        }
    }
}

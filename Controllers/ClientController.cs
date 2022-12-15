using System.Net;
using api_project.Dto.Login;
using api_project.Services;
using Microsoft.AspNetCore.Mvc;
using api_project.Dto.Client;
using api_project.errors;

namespace api_project.Controllers;

[ApiController]
[Route("clients")]
public class ClientController : ControllerBase
{
    private ClientServices _services;

    public ClientController([FromServices] ClientServices services)
    {
        _services = services;
    }

    [HttpPost]
    public ActionResult<TokenRes> CreateClient([FromBody] CreateClientReq newClientReq)
    {
        try
        {
            return Ok(_services.CreateClient(newClientReq));
        }
        catch (BadRequestException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPost]
    [Route("login")]
    public ActionResult<TokenRes> Login([FromBody] LoginReq login)
    {
        try
        {
            return Ok(_services.Login(login));
        }
        catch (BadRequestException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpGet]
    public ActionResult<List<GetClientRes>> GetAllClients()
    {
        try
        {
            return Ok(_services.GetAllClients());
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<GetClientRes> GetOneClient([FromRoute] int id)
    {
        try
        {
            var user = _services.GetOneClient(id, false);
            return Ok(user);
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<GetClientRes> UpdateClient(
        [FromRoute] int id,
        [FromBody] CreateClientReq client
    )
    {
        try
        {
            return Ok(_services.UpdateClient(id, client));
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteClient([FromRoute] int id)
    {
        try
        {
            _services.DeleteClient(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}

using System.Net;
using api_project.Dto.Login;
using api_project.Services;
using Microsoft.AspNetCore.Mvc;
using api_project.Dto.Client;

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
    public ClientLogin CreateClient([FromBody] CreateClientReq newClientReq)
    {
        return _services.CreateClient(newClientReq);
    }

    [HttpPost]
    [Route("login")]
    public ClientLogin Login([FromBody] LoginReq login)
    {
        return _services.Login(login);
    }

    [HttpGet]
    public List<GetClientRes> GetAllClients()
    {
        return _services.GetAllClients();
    }

    [HttpGet("{id:int}")]
    public GetClientRes GetOneClient([FromRoute] int id)
    {
        var user = _services.GetOneClient(id);
        return user;
    }

    [HttpPut("{id:int}")]
    public GetClientRes UpdateClient([FromRoute] int id, [FromBody] CreateClientReq client)
    {
        return _services.UpdateClient(id, client);
    }

    [HttpDelete("{id:int}")]
    public void DeleteClient([FromRoute] int id)
    {
        _services.DeleteClient(id);
    }
}

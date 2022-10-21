using api_project.Services;
using Microsoft.AspNetCore.Mvc;
using order_manager.Dto.Client;

namespace order_manager.Controllers;

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
    public GetClientRes CreateClient([FromBody] CreateClientReq newClientReq)
    {
        return _services.CreateClient(newClientReq);
    }

    [HttpGet]
    public List<GetClientRes> GetAllClients()
    {
        return _services.GetAllClients();
    }

    [HttpGet("{id:int}")]
    public GetClientRes GetOneClient([FromRoute] int id)
    {
        return _services.GetOneClient(id);
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

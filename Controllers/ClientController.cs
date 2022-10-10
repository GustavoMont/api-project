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
    public CreateClientReq CreateClient([FromBody] CreateClientReq newClientReq)
    {
        return _services.CreateClient(newClientReq);
    }
}

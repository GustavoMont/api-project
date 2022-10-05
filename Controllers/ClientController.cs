using api_project.Services;
using Microsoft.AspNetCore.Mvc;

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
}

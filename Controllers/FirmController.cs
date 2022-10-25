
using Microsoft.AspNetCore.Mvc;
using order_manager.Dto.Firm;
using order_manager.Services;

namespace order_manager.Controllers;

[ApiController]
[Route("/firms")]
public class FirmController : ControllerBase
{
    private FirmServices _services;

    public FirmController([FromServices] FirmServices services)
    {
      _services = services;
    }

    [HttpPost]
    public void PostFirm([FromBody] CreateFirmReq newFirmReq) 
    {
        //Enviar para os dados da requisição(DTO) para a classe de serviço
        
        _services.CreateFirm(newFirmReq);

    }
}

using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using order_manager.Dto.Firm;
using order_manager.Repositories;

namespace order_manager.Services;

public class FirmServices
{
    private FirmRepository _repository;

    public FirmServices([FromServices] FirmRepository repository)
    {
      _repository = repository;
    }
    public void CreateFirm(CreateFirmReq FirmReq)
    {
       var firm = new Firm();
       firm.Name = FirmReq.Name;
       firm.Cnpj = FirmReq.Cnpj;
       firm.Email = FirmReq.Email; 

       //Enviar para o repositório para salvar no BD  
      _repository.CreateFirm(firm);

    }
}

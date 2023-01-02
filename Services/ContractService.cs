using api_project.Dto.Contract;
using api_project.Models;
using api_project.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Services;

public class ContractService
{
    private readonly ContractRepository _repository;
    private readonly ServiceServices _serviceService;
    private readonly ClientServices _clientServices;

    public ContractService(
        [FromServices] ContractRepository repository,
        [FromServices] ClientServices clientServices,
        [FromServices] ServiceServices serviceServices
    )
    {
        _repository = repository;
        _clientServices = clientServices;
        _serviceService = serviceServices;
    }

    public ContractRequested Create(CreateContract newContract)
    {
        try
        {
            var serviceExists = _serviceService.GetServiceById((int)newContract.ServiceId, false);
            int clientId = _clientServices.GetClientId();
            var clientExists = _clientServices.GetClientById(clientId, false);
            var contract = newContract.Adapt<Contract>();
            contract.ClientId = clientId;
            contract.FirmId = serviceExists.FirmId;
            var contractCreated = _repository.Create(contract);
            return contractCreated.Adapt<ContractRequested>();
        }
        catch (Exception err)
        {
            throw new BadHttpRequestException(err.Message);
        }
    }
}

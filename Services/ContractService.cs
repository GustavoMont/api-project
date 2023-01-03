using api_project.Dto.Contract;
using api_project.errors;
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
    private readonly ContractStatusService _contractStatusService;

    public ContractService(
        [FromServices] ContractRepository repository,
        [FromServices] ClientServices clientServices,
        [FromServices] ServiceServices serviceServices,
        [FromServices] ContractStatusService contractStatusService
    )
    {
        _repository = repository;
        _clientServices = clientServices;
        _serviceService = serviceServices;
        _contractStatusService = contractStatusService;
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

    public List<ContractAcceptRes> GetAll()
    {
        try
        {
            var contracts = _repository.GetAll();
            if (contracts.Count == 0)
            {
                throw new NotFoundException("Nenhum contrato encontrado");
            }
            return contracts.Adapt<List<ContractAcceptRes>>();
        }
        catch (System.Exception)
        {
            throw new BadRequestException("Ocorreu um erro ao pegar os contratos");
        }
    }

    public Contract GetById(int id, bool tracking = true)
    {
        var contract = _repository.GetOne(id, tracking);
        if (contract is null)
        {
            throw new NotFoundException("Contrato não encontrado");
        }
        return contract;
    }

    public void IsContractOwner(Contract contract)
    {
        var userId = _clientServices.GetClientId();
        if (contract.FirmId != userId && contract.ClientId != userId)
        {
            throw new NotFoundException("Contrato não encontrado");
        }
    }

    public ContractAcceptRes GetOne(int id)
    {
        try
        {
            var contract = GetById(id, false);
            IsContractOwner(contract);
            return contract.Adapt<ContractAcceptRes>();
        }
        catch (NotFoundException err)
        {
            throw new NotFoundException(err.Message);
        }
        catch (Exception err)
        {
            throw new BadHttpRequestException(err.Message);
        }
    }

    public bool CanChangeToWaitingStart(ContractStatus status, ChangeContractStatus changes)
    {
        bool isChangeToWaitingStart = status.Name == ContractStatusName.Aguardando_Execucao;
        if (isChangeToWaitingStart && changes.ExpectDeadeline is null)
        {
            return false;
        }
        if (((DateTime)changes.ExpectDeadeline).Date <= DateTime.Now.Date)
        {
            return false;
        }
        return true;
    }

    public ContractAcceptRes ChangeStatus(int id, ChangeContractStatus changes)
    {
        var contract = GetById(id);
        IsContractOwner(contract);
        var contractStatus = _contractStatusService.GetById(changes.StatusId);
        bool isChangingToFinish = contractStatus.Name == ContractStatusName.Finalizado;
        if (isChangingToFinish)
        {
            throw new BadHttpRequestException("Não é possível realizar essa ação");
        }
        if (!CanChangeToWaitingStart(contractStatus, changes))
        {
            throw new BadHttpRequestException("É necessário informar a data esperada da entrega");
        }
        var contractChanged = changes.Adapt(contract);
        _repository.Update();
        contractChanged.Status = contractStatus;
        return contractChanged.Adapt<ContractAcceptRes>();
    }

    public ContractAcceptRes Update(int id, UpdateContract updateContract)
    {
        try
        {
            var contract = GetById(id);
            IsContractOwner(contract);
            var contractUpdated = updateContract.Adapt(contract);
            _repository.Update();
            return contractUpdated.Adapt<ContractAcceptRes>();
        }
        catch (System.Exception err)
        {
            throw new BadHttpRequestException(err.Message);
        }
    }

    public ContractAcceptRes FinishContract(int id)
    {
        var contract = GetById(id);
        IsContractOwner(contract);
        contract.CompletedAt = DateTime.Now.Date;
        contract.StatusId = _contractStatusService
            .GetByName(ContractStatusName.Finalizado.ToString())
            .Id;
        _repository.Update();
        return contract.Adapt<ContractAcceptRes>();
    }
}

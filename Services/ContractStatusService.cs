using api_project.Dto.ContractStatus;
using api_project.errors;
using api_project.Models;
using api_project.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Services;

public class ContractStatusService
{
    private readonly ContractStatusRepository _repository;

    public ContractStatusService([FromServices] ContractStatusRepository repository)
    {
        _repository = repository;
    }

    public ContractStatusRes Create(CreateContractStatus newContractStatus)
    {
        try
        {
            var contractStatus = newContractStatus.Adapt<ContractStatus>();
            var createdContractStatus = _repository.Create(contractStatus);
            return createdContractStatus.Adapt<ContractStatusRes>();
        }
        catch (System.Exception)
        {
            throw new BadHttpRequestException("Ocorreu um erro ao salvar novo status");
        }
    }

    public List<ContractStatusRes> GetAll()
    {
        var allContractStatus = _repository.GetAll();
        if (allContractStatus.Count == 0)
        {
            throw new NotFoundException("Nenhum estado de contrato cadastrado");
        }
        return allContractStatus.Adapt<List<ContractStatusRes>>();
    }

    public ContractStatusRes GetByName(string contractStatusName)
    {
        ContractStatusName statusNameEnum = (ContractStatusName)
            Enum.Parse(typeof(ContractStatusName), contractStatusName);
        var contractStatus = _repository.GetByName(statusNameEnum);
        if (contractStatus is null)
        {
            throw new NotFoundException("Status de Contrato não encontrados");
        }
        return contractStatus.Adapt<ContractStatusRes>();
    }

    public ContractStatus GetById(int id)
    {
        var contract = _repository.GetOne(id);
        if (contract is null)
        {
            throw new NotFoundException("Status não encontrado");
        }
        return contract;
    }
}

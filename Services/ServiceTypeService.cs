using api_project.Dto.ServiceType;
using api_project.errors;
using api_project.Models;
using api_project.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Services;

public class ServiceTypeService
{
    private readonly ServiceTypeRepository _repository;

    public ServiceTypeService([FromServices] ServiceTypeRepository repository)
    {
        _repository = repository;
    }

    public ServiceTypeRes CreateServiceType(ServiceTypeCreateUpdateReq newServiceType)
    {
        var serviceType = _repository.CreateServiceType(newServiceType.Adapt<ServiceType>());
        return serviceType.Adapt<ServiceTypeRes>();
    }

    public List<ServiceTypeRes> GetAllServiceTypes()
    {
        var serviceTypes = _repository.GetAllServiceTypes();
        if (serviceTypes.Count == 0)
        {
            throw new NotFoundException("Nenhum tipo de serviço encontrado");
        }
        return serviceTypes.Adapt<List<ServiceTypeRes>>();
    }

    public ServiceType GetById(int id, bool tracking = true)
    {
        var serviceType = _repository.GetOneServiceType(id, tracking);
        if (serviceType is null)
        {
            throw new NotFoundException("Tipo de serviço não encontrado");
        }
        return serviceType;
    }

    public ServiceTypeRes GetOneServiceType(int id)
    {
        return GetById(id, false).Adapt<ServiceTypeRes>();
    }

    public ServiceTypeRes UpdateServiceType(int id, ServiceTypeCreateUpdateReq changes)
    {
        var serviceType = GetById(id);
        var test = changes.Adapt(serviceType);
        _repository.UpdateServiceType();
        return serviceType.Adapt<ServiceTypeRes>();
    }

    public void DeleteServiceType(int id)
    {
        var serviceType = GetById(id);
        System.Console.WriteLine(serviceType.Name);
        _repository.DeleteServiceType(serviceType);
    }
}

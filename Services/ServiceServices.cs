using api_project.Dto.Services;
using api_project.errors;
using api_project.Models;
using api_project.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Services;

public class ServiceServices
{
    private readonly ServiceRepository _repository;
    private readonly FirmRepository _firmRepository;
    private readonly ServiceTypeRepository _serviceTypeRepository;

    public ServiceServices(
        [FromServices] ServiceRepository repository,
        [FromServices] FirmRepository firmRepository,
        [FromServices] ServiceTypeRepository serviceTypeRepository
    )
    {
        _repository = repository;
        _firmRepository = firmRepository;
        _serviceTypeRepository = serviceTypeRepository;
    }

    public ServiceRes CreateService(ServiceCreateReq newService, int firmId)
    {
        var firm = _firmRepository.GetOneFirm(firmId);
        if (firm is null)
        {
            throw new BadHttpRequestException("Firma não existente");
        }
        var serviceType = _serviceTypeRepository.GetOneServiceType((int)newService.ServiceTypeId);
        if (serviceType is null)
        {
            throw new BadHttpRequestException("Insira um tipo de serviço válido");
        }
        newService.FirmId = firmId;
        var service = _repository.CreateService(newService.Adapt<Service>());
        return service.Adapt<ServiceRes>();
    }

    public List<ServiceRes> GetAllServices()
    {
        var services = _repository.GetAllServices();
        if (services.Count == 0)
        {
            throw new NotFoundException("Serviços não cadastrados");
        }
        return services.Adapt<List<ServiceRes>>();
    }

    public Service GetServiceById(int id, bool tracking = true)
    {
        var service = _repository.GetOneService(id, tracking);
        if (service is null)
        {
            throw new NotFoundException("Serviço não encontrado");
        }
        return service;
    }

    public ServiceRes GetOneService(int id)
    {
        var service = GetServiceById(id, false);
        return service.Adapt<ServiceRes>();
    }
}

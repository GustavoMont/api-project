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
    private readonly FirmServices _firmService;
    private readonly ServiceTypeService _serviceTypeService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ServiceServices(
        [FromServices] ServiceRepository repository,
        [FromServices] FirmServices firmServices,
        [FromServices] ServiceTypeService serviceTypeService,
        [FromServices] IHttpContextAccessor httpContextAccessor
    )
    {
        _repository = repository;
        _firmService = firmServices;
        _serviceTypeService = serviceTypeService;
        _httpContextAccessor = httpContextAccessor;
    }

    public ServiceRes CreateService(ServiceCreateReq newService)
    {
        try
        {
            var firmId = _firmService.GetFirmId();
            var firm = _firmService.GetOneFirm(firmId);
            var serviceType = _serviceTypeService.GetOneServiceType((int)newService.ServiceTypeId);
            newService.FirmId = firmId;
            var service = _repository.CreateService(newService.Adapt<Service>());
            return service.Adapt<ServiceRes>();
        }
        catch (Exception err)
        {
            throw new BadHttpRequestException(err.Message);
        }
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

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

    public ServiceServices([FromServices] ServiceRepository repository)
    {
        _repository = repository;
    }

    public ServiceRes CreateService(ServiceCreateReq newService)
    {
        var service = _repository.CreateService(newService.Adapt<Service>());
        return service.Adapt<ServiceRes>();
    }

    public List<ServiceRes> GetAllServices()
    {
        var services = _repository.GetAllServices();
        if (services.Count == 0)
        {
            throw new NotFoundException("Não há nenhum serviço cadastrado");
        }
        return services.Adapt<List<ServiceRes>>();
    }

    private Service GetById(int id, bool tracking = true)
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
        var service = GetById(id, false);
        System.Console.WriteLine(service.Name);
        System.Console.WriteLine(id);
        return service.Adapt<ServiceRes>();
    }
}

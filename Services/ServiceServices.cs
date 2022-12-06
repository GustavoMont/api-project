using api_project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Services;

public class ServiceServices
{
    private readonly ServiceRepository _repository;

    public ServiceServices([FromServices] ServiceRepository repository)
    {
        _repository = repository;
    }
}

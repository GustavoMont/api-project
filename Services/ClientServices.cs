using api_project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Services;

public class ClientServices
{
    private ClientRepository _repository;

    public ClientServices([FromServices] ClientRepository repository)
    {
        _repository = repository;
    }
}

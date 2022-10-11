using api_project.Models;
using api_project.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using order_manager.Dto.Client;
using System.Security.Cryptography;

namespace api_project.Services;

public class ClientServices
{
    private ClientRepository _repository;

    public ClientServices([FromServices] ClientRepository repository)
    {
        _repository = repository;
    }

    public GetClientRes CreateClient(CreateClientReq clientReq)
    {
        var client = new Client();
        GetClientRes clientResponse = new();
        client.Name = clientReq.Name;
        client.Email = clientReq.Email;
        client.Password = BCrypt.Net.BCrypt.HashPassword(clientReq.Password);
        _repository.CreateClient(client);
        client.Adapt(clientResponse);
        return clientResponse;
    }

    public List<GetClientRes> GetAllClients()
    {
        var clients = _repository.GetAllClients();
        List<GetClientRes> clientsResponse = new();
        return clients.Adapt(clientsResponse);
    }

    public GetClientRes GetOneClient(int id)
    {
        var client = _repository.GetOneClient(id);
        if (client is null)
        {
            return null;
        }
        GetClientRes clientResponse = new();
        return client.Adapt(clientResponse);
    }

    public GetClientRes UpdateClient(int id, CreateClientReq updates)
    {
        var client = _repository.GetOneClient(id);
        if (client is null)
        {
            return null;
        }
        var clientUpdate = updates.Adapt(client);
        GetClientRes clientRes = new();
        return clientUpdate.Adapt(clientRes);
    }

    public void DeleteClient(int id)
    {
        var client = _repository.GetOneClient(id);
        if (client is null)
        {
            return;
        }
        _repository.DeleteClient(client);
        return;
    }
}

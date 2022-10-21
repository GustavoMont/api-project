using api_project.Dto.Login;
using api_project.Models;
using api_project.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using order_manager.Dto.Client;
using order_manager.Services;

namespace api_project.Services;

public class ClientServices
{
    private ClientRepository _repository;
    private TokenService _tokenService;

    public ClientServices(
        [FromServices] ClientRepository repository,
        [FromServices] TokenService tokenService
    )
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public ClientLogin Login(LoginReq login)
    {
        var client = _repository.GetCLientByEMail(login.Email);
        if (client == null)
        {
            return null;
        }
        if (BCrypt.Net.BCrypt.Verify(login.Password, client.Password))
        {
            return null;
        }
        var response = new ClientLogin();
        var token = _tokenService.GenerateToken(client);
        response.Access = token;
        client.Password = "";
        return response;
    }

    public ClientLogin CreateClient(CreateClientReq clientReq)
    {
        var client = new Client();
        client.Name = clientReq.Name;
        client.Email = clientReq.Email;
        client.Password = BCrypt.Net.BCrypt.HashPassword(clientReq.Password);
        client.Password = "";
        _repository.CreateClient(client);
        var token = _tokenService.GenerateToken(client);
        var response = new ClientLogin { Access = token };
        return response;
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
        client.Update();
        var clientUpdate = updates.Adapt(client);
        GetClientRes clientRes = new();
        _repository.UpdateClient();
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

using api_project.Models;
using api_project.Repositories;
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

    public CreateClientReq CreateClient(CreateClientReq clientReq)
    {
        var client = new Client();
        client.Name = clientReq.Name;
        client.Email = clientReq.Email;
        client.Password = BCrypt.Net.BCrypt.HashPassword(clientReq.Password);
        _repository.CreateClient(client);
        clientReq.Password = "";
        return clientReq;
    }
}

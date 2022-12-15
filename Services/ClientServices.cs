using api_project.Dto.Login;
using api_project.Models;
using api_project.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using api_project.Dto.Client;
using api_project.errors;

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

    public Client GetClientById(int id, bool tracking = true)
    {
        var client = _repository.GetOneClient(id, tracking);
        if (client is null)
        {
            throw new NotFoundException("Cliente não encontrado");
        }
        return client;
    }

    public TokenRes Login(LoginReq login)
    {
        var client = _repository.GetClientByEMail(login.Credential);
        if (client == null)
        {
            throw new BadRequestException("Usuário ou senha incorreto");
        }
        if (BCrypt.Net.BCrypt.Verify(login.Password, client.Password))
        {
            throw new BadRequestException("Usuário ou senha incorreto");
        }
        var response = new TokenRes();
        var token = _tokenService.GenerateToken(client);
        response.Access = token;
        client.Password = "";
        return response;
    }

    public TokenRes CreateClient(CreateClientReq clientReq)
    {
        var client = new Client();
        client.Name = clientReq.Name;
        client.Email = clientReq.Email;
        if (clientReq.Password != clientReq.ConfirmPassword)
        {
            throw new BadRequestException("As senhas estão diferentes");
        }
        client.Password = BCrypt.Net.BCrypt.HashPassword(clientReq.Password);
        _repository.CreateClient(client);
        client.Password = "";
        var token = _tokenService.GenerateToken(client);
        var response = new TokenRes { Access = token };
        return response;
    }

    public List<GetClientRes> GetAllClients()
    {
        var clients = _repository.GetAllClients();
        if (clients.Count == 0)
        {
            throw new NotFoundException("Clientes não encotrados");
        }
        List<GetClientRes> clientsResponse = new();
        return clients.Adapt(clientsResponse);
    }

    public GetClientRes GetOneClient(int id, bool tracking = true)
    {
        var client = GetClientById(id, false);
        GetClientRes clientResponse = new();
        return client.Adapt(clientResponse);
    }

    public GetClientRes UpdateClient(int id, CreateClientReq updates)
    {
        var client = GetClientById(id);
        client.Update();
        var clientUpdate = updates.Adapt(client);
        GetClientRes clientRes = new();
        _repository.UpdateClient();
        return clientUpdate.Adapt(clientRes);
    }

    public void DeleteClient(int id)
    {
        var client = GetClientById(id);
        _repository.DeleteClient(client);
        return;
    }
}

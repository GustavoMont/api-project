using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Repositories;

public class ClientRepository
{
    private Context _contextDb;

    public ClientRepository([FromServices] Context context)
    {
        _contextDb = context;
    }

    public Client CreateClient(Client newClient)
    {
        _contextDb.Clients.Add(newClient);
        _contextDb.SaveChanges();
        return newClient;
    }

    public List<Client> GetAllClients()
    {
        var clients = _contextDb.Clients.AsNoTracking().ToList();
        return clients;
    }

    public Client GetOneClient(int id, bool tracking = true)
    {
        return tracking
            ? _contextDb.Clients.AsNoTracking().FirstOrDefault(client => client.Id == id)
            : _contextDb.Clients.FirstOrDefault(client => client.Id == id);
    }

    public Client GetClientByEMail(string email)
    {
        var client = _contextDb.Clients
            .AsNoTracking()
            .FirstOrDefault(client => client.Email == email);
        return client;
    }

    public void UpdateClient()
    {
        _contextDb.SaveChanges();
    }

    public void DeleteClient(Client client)
    {
        _contextDb.Remove(client);
        _contextDb.SaveChanges();
    }
}

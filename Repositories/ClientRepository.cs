using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Repositories;

public class ClientRepository
{
    private Context _contextDb;

    public ClientRepository([FromServices] Context context)
    {
        _contextDb = context;
    }

    public void CreateClient(Client newClient)
    {
        _contextDb.Clients.Add(newClient);
        _contextDb.SaveChanges();
    }
}

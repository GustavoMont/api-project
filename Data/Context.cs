using Microsoft.EntityFrameworkCore;

using api_project.Models;

namespace api_project.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    //Tables
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientContact> ClientContacts { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Firm> Firms { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Professional> Professionals { get; set; }
    public DbSet<ContractStatus> ContractStatus { get; set; }
}

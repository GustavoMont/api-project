namespace api_project.Dto.Contract;

using api_project.Dto.Services;
using api_project.Models;

public class ContractRequested
{
    public int StatusId { get; set; }
    public ContractStatus Status { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int ServiceId { get; set; }
    public ServiceRes Service { get; set; }
}

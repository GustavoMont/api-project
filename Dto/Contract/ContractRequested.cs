namespace api_project.Dto.Contract;

using api_project.Dto.Client;
using api_project.Dto.ContractStatus;
using api_project.Dto.Firm;
using api_project.Dto.Services;
using api_project.Models;

public class ContractRequested
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public ContractStatusRes Status { get; set; }
    public int ClientId { get; set; }
    public ContractClientRes Client { get; set; }
    public int ServiceId { get; set; }
    public ContractServiceRes Service { get; set; }
    public int FirmId { get; set; }
    public ContractFirmRes Firm { get; set; }
}

public class ContractServiceRes
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ContractFirmRes
{
    public string Name { get; set; }
}

public class ContractClientRes
{
    public string Name { get; set; }
}

namespace api_project.Dto.Services;
using api_project.Models;

public class ServiceRes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int ServiceTypeId { get; set; }
    public int FirmId { get; set; }
    public ServiceFirm Firm { get; set; }
    public ServiceTypeRes ServiceType { get; set; }
}

public class ServiceFirm
{
    public string Name { get; set; }
}

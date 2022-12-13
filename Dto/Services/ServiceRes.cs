namespace api_project.Dto.Services;
using api_project.Models;

public class ServiceRes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public ServiceType ServiceType { get; set; }
}

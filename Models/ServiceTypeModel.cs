using api_project.Models;

namespace api_project.Models;

public class ServiceType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Service> Services { get; set; }
}

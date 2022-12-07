using api_project.Dto.Services;

public class ServiceTypeRes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ServiceRes> Services { get; set; }
}

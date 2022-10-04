namespace order_manager.Models;

public class Professional
{
    public int Id { get; set; }
    public string Ocupation { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string CompletionDeadline { get; set; }
    public Firm Firm { get; set; }
    public int FirmId { get; set; }
    public List<Service> Services { get; set; }
}

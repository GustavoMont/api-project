namespace api_project.Dto.Contract;

public class UpdateContract
{
    public DateTime? CompletedAt { get; set; }
    public bool IsPaid { get; set; }
    public DateTime PaidAt { get; set; }
}

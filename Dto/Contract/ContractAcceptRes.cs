namespace api_project.Dto.Contract;

public class ContractAcceptRes : ContractRequested
{
    public string Description { get; set; }

    public DateTime ExpectDeadeline { get; set; }

    public DateTime CompletedAt { get; set; }
    public bool IsPaid { get; set; }
    public DateTime PaidAt { get; set; }
}

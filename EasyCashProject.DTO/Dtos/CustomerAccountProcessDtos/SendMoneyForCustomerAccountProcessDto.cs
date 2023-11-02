namespace EasyCashProject.DTO.Dtos.CustomerAccountProcessDtos;

public class SendMoneyForCustomerAccountProcessDto
{
   
    public string ProcessType { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime ProcessDate { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string ReceiverAccountNumber { get; set; } = null!;

}
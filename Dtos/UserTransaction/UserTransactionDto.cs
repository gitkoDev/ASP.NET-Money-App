using api.Models;

namespace api.Dtos;

public class AddUserTransactionDto
{
    public int Sender { get; set; } 
    public required int Receiver { get; set; }
    public decimal Amount { get; set; }
}
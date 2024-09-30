using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class UserTransaction
{
    public int Id { get; set; }
    public required User Sender { get; set; }
    public required User Receiver { get; set; }
    public decimal Amount { get; set; }
}
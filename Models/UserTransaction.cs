using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class UserTransaction
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public required User Sender { get; set; }
    public int ReceiverId { get; set; }
    public required User Receiver { get; set; }
    public decimal Amount { get; set; }
}
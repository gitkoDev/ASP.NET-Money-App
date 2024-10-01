using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos
{
    public class UserTransactionDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public decimal Amount { get; set; }
    }

}


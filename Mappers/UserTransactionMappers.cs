using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class UserTransactionMapper
    {
        public static UserTransactionDto ToUserTransactionDto(this UserTransaction userTransaction)
        {
            return new()
            {
                SenderId = userTransaction.SenderId,
                ReceiverId = userTransaction.ReceiverId,
                Amount = userTransaction.Amount
            };
        }
    }
}
using api.Models;

namespace api.Interfaces
{
    public interface IUserTransactionRepository 
    {
        Task<UserTransaction> AddAsync(UserTransaction userTransaction);
        Task<User?> GetSenderById(int id);
        Task<User?> GetReceiverById(int id);
    }
}
using api.Models;

namespace api.Interfaces
{
    public interface IUserTransactionRepository 
    {
        Task <List<UserTransaction>> GetAllAsync(int pageNumber, int pageSize);
        Task<UserTransaction> AddAsync(UserTransaction userTransaction);
        Task<UserTransaction?> GetByIdAsync(int id);
        Task<User?> GetSenderByIdAsync(int id);
        Task<User?> GetReceiverByIdAsync(int id);
    }
}
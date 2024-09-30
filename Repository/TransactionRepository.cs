using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserTransactionRepository : IUserTransactionRepository
    {
        private readonly AppDbContext _context;
        public UserTransactionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserTransaction> AddAsync(UserTransaction userTransaction)
        {
            using var transaction = _context.Database.BeginTransaction();

            userTransaction.Sender.Salary -= userTransaction.Amount;
            userTransaction.Receiver.Salary += userTransaction.Amount;
            await _context.SaveChangesAsync();
            await _context.Transactions.AddAsync(userTransaction);
            await transaction.CommitAsync();
            return userTransaction;
        }
        public async Task<User?> GetSenderById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id); 
        }
          public async Task<User?> GetReceiverById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id); 
        }
    }
}
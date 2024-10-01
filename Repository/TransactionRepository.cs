using api.Data;
using api.Dtos;
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
        public async Task<List<UserTransaction>> GetAllAsync(int pageNumber,  int PageSize)
        {
            var transactions = _context.Transactions.AsQueryable();
            return await transactions.Skip(pageNumber - 1).Take(PageSize).ToListAsync();
        }
        public async Task<UserTransaction?> GetByIdAsync(int id)
        {
            var userTransaction =  await _context.Transactions.FirstOrDefaultAsync(userTransaction => userTransaction.Id == id);
            return userTransaction;
        }
        public async Task<UserTransaction> AddAsync(UserTransaction userTransaction)
        {
            using var transaction = _context.Database.BeginTransaction();

            userTransaction.Sender.Salary -= userTransaction.Amount;
            userTransaction.Receiver.Salary += userTransaction.Amount;
            await _context.Transactions.AddAsync(userTransaction);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            
            // Delete
            Console.WriteLine("Iddd" + userTransaction.Id);
            var doneTrans =  await _context.Transactions.FirstOrDefaultAsync(doneTrans => doneTrans.Id == userTransaction.Id);
            if (doneTrans != null)
            {
                Console.WriteLine("In add" + doneTrans.Receiver.Id);
            }
            else 
            {
                Console.WriteLine("null");
            }

            return userTransaction;
        }
        public async Task<User?> GetSenderByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id); 
        }
          public async Task<User?> GetReceiverByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id == id); 
        }
    }
}
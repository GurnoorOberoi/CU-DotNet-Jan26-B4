using Microsoft.EntityFrameworkCore;
using SmartBankMiniProject.Helpers;
using SmartBankMiniProject.Models;

namespace SmartBankMiniProject.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private AppDbContext _context {  get; set; }
        public AccountRepository(AppDbContext context)
        {
            _context = context; 
        }
        public async Task<Account> Create (Account account)
        {
            _context.Account.Add(account);
            //account.AccountNumber = AccountNumberGenerator.Generate(account.Id);
            await _context.SaveChangesAsync();
            account.AccountNumber = AccountNumberGenerator.Generate(account.Id);
            await _context.SaveChangesAsync();
            return account;
        }
        public async Task<List<Account>> GetAll()
        {
            return await _context.Account.ToListAsync();
        }
        public async Task<Account> GetById (int id)
        {
            return await _context.Account.FindAsync(id);
        }
        public async Task Update(Account account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Account account)
        {
            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
        }
    }

}

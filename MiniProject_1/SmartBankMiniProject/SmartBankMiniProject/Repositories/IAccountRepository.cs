using SmartBankMiniProject.Models;

namespace SmartBankMiniProject.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> Create(Account account);
        Task<List<Account>> GetAll();
        Task<Account> GetById(int id);
        Task Update(Account account);
        Task Delete(Account account);

    }
}

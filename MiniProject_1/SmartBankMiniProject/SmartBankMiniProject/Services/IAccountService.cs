using SmartBankMiniProject.DTOs;
using SmartBankMiniProject.Repositories;

namespace SmartBankMiniProject.Services
{
    public interface IAccountService
    {
        Task<AccountDto> CreateAccount(CreateAccountDto account);
        Task<List<AccountDto>> GetAll();
        Task<AccountDto> GetById(int id);
        Task Deposit(TransactionDto dto);
        Task Withdraw(TransactionDto dto);
        Task Update(AccountDto dto);
        Task Delete(int id);

    }
}

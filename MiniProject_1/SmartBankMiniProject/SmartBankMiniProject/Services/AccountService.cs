using SmartBankMiniProject.DTOs;
using SmartBankMiniProject.Exceptions;
using SmartBankMiniProject.Helpers;
using SmartBankMiniProject.Models;
using SmartBankMiniProject.Repositories;

namespace SmartBankMiniProject.Services
{
    public class AccountService: IAccountService
    {
        private IAccountRepository _repo { get; set; }
        public AccountService(IAccountRepository repo)
        {
            _repo = repo; 
        }
        public async Task<AccountDto> CreateAccount(CreateAccountDto account)
        {
            if (account.InitialDeposit < 1000)
                throw new BadRequestException("Minimum deposite is ₹1000");
            var item = new Account
            {
                Name = account.Name,
                Balance = account.InitialDeposit
            };
            //var created = await _repo.Create(item);
            item.AccountNumber = AccountNumberGenerator.Generate(item.Id);
            var created = await _repo.Create(item);
            //await _repo.Update(created);

            return new AccountDto
            {
                Id = created.Id,
                Name = created.Name,
                Balance = created.Balance,
                AccountNumber = created.AccountNumber
            };
        }
        public async Task<List<AccountDto>> GetAll()
        {
            var accounts = await _repo.GetAll();

            return accounts.Select(a => new AccountDto
            {
                Id = a.Id,
                Name = a.Name,
                Balance = a.Balance,
                AccountNumber = a.AccountNumber
            }).ToList();
        }

        public async Task<AccountDto> GetById(int id)
        {
            var account = await _repo.GetById(id);

            if (account == null)
                throw new NotFoundException("Account not found");

            return new AccountDto
            {
                Id = account.Id,
                Name = account.Name,
                Balance = account.Balance,
                AccountNumber = account.AccountNumber
            };
        }

        public async Task Deposit(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _repo.GetById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            account.Balance += dto.Amount;

            await _repo.Update(account);
        }

        public async Task Withdraw(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _repo.GetById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new BadRequestException("Minimum balance must be ₹1000");

            account.Balance -= dto.Amount;

            await _repo.Update(account);
        }
        public async Task Update(AccountDto dto)
        {
            var account = await _repo.GetById(dto.Id);

            if (account == null)
                throw new NotFoundException("Account not found");

            account.Name = dto.Name;
            account.Balance = dto.Balance;

            await _repo.Update(account);
        }
        public async Task Delete(int id)
        {
            var account = await _repo.GetById(id);

            if (account == null)
                throw new NotFoundException("Account not found");

            await _repo.Delete(account); // add this in repo
        }

    }
}

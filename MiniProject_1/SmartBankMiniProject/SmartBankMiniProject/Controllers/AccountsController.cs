using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBankMiniProject.DTOs;
using SmartBankMiniProject.Models;
using SmartBankMiniProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBankMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccount()
        {
            var accounts = await _service.GetAll();
            return Ok(accounts);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(int id)
        {
            try
            {
                var account = await _service.GetById(id);
                return Ok(account);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<ActionResult<AccountDto>> PostAccount(CreateAccountDto dto)
        {
            try
            {
                var created = await _service.CreateAccount(dto);
                return CreatedAtAction(nameof(GetAccount), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, AccountDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            try
            {
                await _service.Update(dto);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                await _service.Delete(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // 💰 Deposit
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(TransactionDto dto)
        {
            try
            {
                await _service.Deposit(dto);
                return Ok("Deposit successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 💸 Withdraw
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            try
            {
                await _service.Withdraw(dto);
                return Ok("Withdrawal successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

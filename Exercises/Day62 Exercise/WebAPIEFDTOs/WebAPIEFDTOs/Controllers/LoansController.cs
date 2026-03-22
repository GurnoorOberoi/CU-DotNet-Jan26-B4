using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIEFDTOs.Data;
using WebAPIEFDTOs.DTOs;
using WebAPIEFDTOs.Models;

namespace WebAPIEFDTOs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly WebAPIEFDTOsContext _context;

        public LoansController(WebAPIEFDTOsContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLoanResponse>>> GetLoan()
        {
            var loans = await _context.Loan.ToListAsync();

            return loans.Select(l => new GetLoanResponse
            {
                Id = l.Id,
                BorrowerName = l.BorrowerName,
                Amount = l.Amount,
                LoanTermMonths = l.LoanTermMonths,
                IsApproved = l.IsApproved
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetLoanResponse>> GetLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return new GetLoanResponse
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, UpdateLoanDetails dto)
        {

            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            // Mapping DTO → Entity
            loan.BorrowerName = dto.BorrowerName;
            loan.Amount = dto.Amount;
            loan.LoanTermMonths = dto.LoanTermMonths;
            loan.IsApproved = dto.IsApproved;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<GetLoanResponse>> PostLoan(CreateLoanRequest dto)
        {
            var loan = new Loan
            {
                BorrowerName = dto.BorrowerName,
                Amount = dto.Amount,
                LoanTermMonths = dto.LoanTermMonths,
                IsApproved = false // default
            };

            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            var readDto = new GetLoanResponse
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };

            return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, readDto);
        }

        // ✅ DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.Id == id);
        }
    }
}

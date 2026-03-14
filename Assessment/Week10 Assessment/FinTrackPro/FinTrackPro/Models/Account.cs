using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FinTrackPro.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Account Number")]
        public int AccountNumber { get; set; }
        [Required]
        [Display(Name = "Account Holder Name")]
        public string AccountName { get; set; }

        [Required]
        public double Balance { get; set; }

        [ValidateNever]
        public List<Transaction> Transactions { get; set; }
    }
}

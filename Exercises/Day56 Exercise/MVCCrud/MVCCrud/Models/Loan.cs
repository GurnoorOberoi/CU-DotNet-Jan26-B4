using System.ComponentModel.DataAnnotations;

namespace MVCCrud.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required]
        [Display(Name  = "Borrower Name")]
        public string BorrowerName { get; set; }

        [Display(Name = "Lender Name")]
        public string LenderName { get; set; }

        [Range(1,500000)]
        public double Amount { get; set; }

        [Display(Name = "Is Settled")]
        public bool IsSettled { get; set; }
    }
}

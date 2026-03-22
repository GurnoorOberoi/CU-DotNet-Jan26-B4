namespace WebAPIEFDTOs.DTOs
{
    public class CreateLoanRequest
    {
        public string BorrowerName { get; set; }
        public decimal Amount { get; set; }
        public int LoanTermMonths { get; set; }
    }
}

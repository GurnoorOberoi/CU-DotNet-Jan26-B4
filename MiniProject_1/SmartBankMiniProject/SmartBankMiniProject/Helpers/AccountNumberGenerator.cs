namespace SmartBankMiniProject.Helpers
{
    public class AccountNumberGenerator
    {
        public static string Generate(int accountId)
        {
            var year = DateTime.UtcNow.Year;
            return $"SB-{year}-{accountId.ToString().PadLeft(6, '0')}";
        }
    }
}

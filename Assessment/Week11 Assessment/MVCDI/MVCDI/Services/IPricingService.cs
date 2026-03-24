namespace MVCDI.Services
{
    public interface IPricingService
    {
        decimal CalculatePrice(decimal basePrice, string promoCode);
    }
}

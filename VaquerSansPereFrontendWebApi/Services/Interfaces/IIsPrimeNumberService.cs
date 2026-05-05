namespace VaquerSansPereFrontendWebApi.Services.Interfaces
{
    public interface IIsPrimeNumberService
    {
        Task<bool> IsPrime(int num);
    }
}

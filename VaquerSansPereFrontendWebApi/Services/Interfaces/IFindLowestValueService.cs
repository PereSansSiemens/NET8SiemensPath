namespace VaquerSansPereFrontendWebApi.Services.Interfaces
{
    public interface IFindLowestValueService
    {
        Task<int> FindLowestValue(List<int> list);
    }
}

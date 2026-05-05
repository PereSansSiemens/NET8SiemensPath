namespace VaquerSansPereFrontendWebApi.Services.Interfaces
{
    public interface IFindGreatestValueService
    {
        Task<int> FindGreatestValue(List<int> list);
    }
}

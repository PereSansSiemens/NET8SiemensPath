namespace VaquerSansPereFrontendWebApi.Services.Interfaces
{
    public interface IOrderNumListService
    {
        Task<List<int>> OrderedNumList(List<int> list);
    }
}

using BlitzDMS.Shared.Models;

namespace BlitzDMS.Client.Services.COAService
{
    public interface ICOAService
    {
        List<ChartOfAccount> ChartOfAccounts { get; set; }

        Task GetCOA();

        Task<ChartOfAccount> GetCOAById(int id);

        Task CreateCOA(ChartOfAccount chartOfAccount);

        Task UpdateCOA(ChartOfAccount chartOfAccount);

        Task DeleteCOA(int id);
    }
}
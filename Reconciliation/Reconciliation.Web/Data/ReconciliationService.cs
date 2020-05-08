using System.Threading.Tasks;
using ReconciliationApp.Service.Reconciliations;
using ReconciliationApp.Service.Reconciliations.Dtos;

namespace ReconciliationApp.Web.Data
{
    public class ReconciliationService
    {
        private readonly IReconciliationLogicService _reconciliationService;
        public ReconciliationService(IReconciliationLogicService reconciliationService)
        {
            _reconciliationService = reconciliationService;
        }


        public async Task<ReconciliationListDto[]> GetListAsync()
        {
            var result = await _reconciliationService.GetReconciliationsAsync();
            return result.ToArray();
        }

    }
}
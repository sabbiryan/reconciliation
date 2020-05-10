using System.Threading.Tasks;
using ReconciliationApp.Service.IncomeOrExpenseTypes;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;

namespace ReconciliationApp.Blazor.Data
{
    public class IncomeOrExpenseTypeService
    {
        private readonly IIncomeOrExpenseTypeLogicService _incomeOrExpenseTypeLogicService;
        public IncomeOrExpenseTypeService(IIncomeOrExpenseTypeLogicService incomeOrExpenseTypeLogicService)
        {
            _incomeOrExpenseTypeLogicService = incomeOrExpenseTypeLogicService;
        }


        public async Task<IncomeOrExpenseTypeListDto[]> GetListAsync()
        {
            var result = await _incomeOrExpenseTypeLogicService.GetIncomeOrExpenseTypesAsync();
            return result.ToArray();
        }

    }
}
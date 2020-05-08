using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReconciliationApp.Service.IncomeOrExpenses;
using ReconciliationApp.Service.IncomeOrExpenses.Dtos;

namespace ReconciliationApp.Web.Data
{
    public class IncomeOrExpenseService
    {
        private readonly IIncomeOrExpenseLogicService _incomeOrExpenseLogicService;
        public IncomeOrExpenseService(IIncomeOrExpenseLogicService incomeOrExpenseLogicService)
        {
            _incomeOrExpenseLogicService = incomeOrExpenseLogicService;
        }


        public async Task<IncomeOrExpenseListDto[]> GetListAsync()
        {
            var result = await _incomeOrExpenseLogicService.GetIncomeOrExpensesAsync();
            return result.ToArray();
        }

    }
}
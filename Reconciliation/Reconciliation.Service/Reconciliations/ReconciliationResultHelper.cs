using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;
using ReconciliationApp.Service.Reconciliations.Dtos;

namespace ReconciliationApp.Service.Reconciliations
{
    public class ReconciliationResultHelper
    {
        public static void AddReconciliationResult(YearlyReconciliationGridDto grid)
        {
            var result = new YearlyReconciliationGridResultDto("Reconciliation Result", 0);
            foreach (var title in grid.Titles)
            {
                var item = new YearlyReconciliationGridResultValueDto(title.Month);

                var columnValues = grid.Rows
                    .SelectMany(x => x.Columns)
                    .Where(x => x.Month == title.Month).ToList();

                item.Amount = columnValues.Where(x => x.Flag == IncomeOrExpenseFlag.Income).Sum(x => x.Amount) -
                              columnValues.Where(x => x.Flag == IncomeOrExpenseFlag.Expense).Sum(x => x.Amount);

                result.Values.Add(item);
            }

            grid.Results.Add(result);
        }
    }
}

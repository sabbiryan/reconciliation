using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;

namespace ReconciliationApp.EntityFrameworkCore.Seeds
{
    public static class IncomeOrExpenseTypeBuilder
    {
        public static void Build(ReconciliationDbContext context)
        {
            var incomeOrExpenseTypes = new List<IncomeOrExpenseType>()
            {
                new IncomeOrExpenseType("Expense Type 1", IncomeOrExpenseFlag.Expense),
                new IncomeOrExpenseType("Expense Type 2", IncomeOrExpenseFlag.Expense),
                new IncomeOrExpenseType("Expense Type 3", IncomeOrExpenseFlag.Expense),

                new IncomeOrExpenseType("Income Type 1", IncomeOrExpenseFlag.Income),
                new IncomeOrExpenseType("Income Type 2", IncomeOrExpenseFlag.Income),
                new IncomeOrExpenseType("Income Type 3", IncomeOrExpenseFlag.Income),
            };

            if (!context.IncomeOrExpenseTypes.AsNoTracking().Any())
            {
                context.IncomeOrExpenseTypes.AddRange(incomeOrExpenseTypes);
            }
            else
            {
                var types = context.IncomeOrExpenseTypes.AsNoTracking().ToList();

                foreach (var incomeOrExpenseType in incomeOrExpenseTypes)
                {
                    if (!types.Any(x => x.Flag == incomeOrExpenseType.Flag && x.SystemName == incomeOrExpenseType.SystemName))
                    {
                        context.IncomeOrExpenseTypes.Add(incomeOrExpenseType);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
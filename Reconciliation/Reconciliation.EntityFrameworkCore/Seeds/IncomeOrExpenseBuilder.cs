using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenses;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;

namespace ReconciliationApp.EntityFrameworkCore.Seeds
{
    public static class IncomeOrExpenseBuilder
    {
        public static void Build(ReconciliationDbContext context)
        {


            //var incomeOrExpenseTypes = new List<IncomeOrExpense>()
            //{
            //    new IncomeOrExpense()
            //};

            //if (!context.IncomeOrExpenses.AsNoTracking().Any())
            //{
            //    context.IncomeOrExpenses.AddRange(incomeOrExpenseTypes);
            //}
            //else
            //{
            //    var types = context.IncomeOrExpenses.AsNoTracking().ToList();

            //    //foreach (var incomeOrExpenseType in incomeOrExpenseTypes)
            //    //{
            //    //    if (!types.Any(x => x.IncomeOrExpenseTypeId == incomeOrExpenseType.IncomeOrExpenseTypeId && x.DateTime == incomeOrExpenseType.DateTime))
            //    //    {
            //    //        context.IncomeOrExpenseTypes.Add(incomeOrExpenseType);
            //    //    }
            //    //}
            //}

            context.SaveChanges();
        }
    }
}
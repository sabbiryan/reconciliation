using System;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;
using ReconciliationApp.Shared.Dtos;

namespace ReconciliationApp.Service.Reconciliations.Dtos
{
    public class YearlyReconciliationGridDto : DtoBase<string>
    {
        public string Year { get; set; }

        
    }

    public class MonthlyIncomeOrExpenseDto
    {
        public string Month { get; set; }

        public decimal Income { get; set; }
        public decimal CumulativeIncome { get; set; }


        public decimal Expense { get; set; }
        public decimal CumulativeExpense { get; set; }


        public decimal Result { get; set; }
    }
}
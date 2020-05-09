using System;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;
using ReconciliationApp.Shared.Dtos;

namespace ReconciliationApp.Service.Reconciliations.Dtos
{
    public class YearlyReconciliationGridDto
    {
        public string Year { get; set; }

        public string[] Months { get; set; }

    }

    public class YearlyReconciliationGridCellDto
    {
        public string IncomeOrExpenseTypeId { get; set; }
        public int Month { get; set; }
        public decimal? Amount { get; set; }
    }
}
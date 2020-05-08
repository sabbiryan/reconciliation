using System;
using ReconciliationApp.Service.IncomeOrExpenseTypes.Dtos;
using ReconciliationApp.Shared.Dtos;

namespace ReconciliationApp.Service.Reconciliations.Dtos
{
    public class ReconciliationDto : DtoBase<string>
    {
        public string IncomeOrExpenseTypeId { get; set; }
        public IncomeOrExpenseTypeDto IncomeOrExpenseType { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}
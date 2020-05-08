using System;
using ReconciliationApp.Shared.Dtos;

namespace ReconciliationApp.Service.Reconciliations.Dtos
{
    public class ReconciliationUpdateDto : DtoBase<string>
    {
        public string IncomeOrExpenseTypeId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}
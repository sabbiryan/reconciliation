using System;
using ReconciliationApp.Shared.Dtos;

namespace ReconciliationApp.Service.Reconciliations.Dtos
{
    public class ReconciliationCreateDto : DtoBase<string>
    {
        public ReconciliationCreateDto()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string IncomeOrExpenseTypeId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}
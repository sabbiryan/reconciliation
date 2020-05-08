using System;
using System.ComponentModel.DataAnnotations;
using ReconciliationApp.Shared.Dtos;

namespace ReconciliationApp.Service.Reconciliations.Dtos
{
    public class ReconciliationCreateDto : DtoBase<string>
    {
        public ReconciliationCreateDto()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required(ErrorMessage = "Please select an income or expense type")]
        public string IncomeOrExpenseTypeId { get; set; }

        [Required(ErrorMessage = "Please select a date")] public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please select an amount more than 0")]
        public decimal Amount { get; set; }
    }
}
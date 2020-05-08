using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;

namespace ReconciliationApp.EntityFrameworkCore.Reconciliations
{
    [Table("Reconciliations")]
    public class Reconciliation: EntityBase<string>
    {
        public string IncomeOrExpenseTypeId { get; set; }
        [ForeignKey("IncomeOrExpenseTypeId")]
        public IncomeOrExpenseType IncomeOrExpenseType { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}

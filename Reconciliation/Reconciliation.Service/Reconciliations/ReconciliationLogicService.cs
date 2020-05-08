using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore;
using ReconciliationApp.Service.Reconciliations.Dtos;

namespace ReconciliationApp.Service.Reconciliations
{
    public class ReconciliationLogicService: LogicServiceBase, IReconciliationLogicService
    {
        public ReconciliationLogicService(ReconciliationDbContext context) : base(context)
        {
        }

        public async Task<List<ReconciliationListDto>> GetReconciliationsAsync()
        {
            var reconciliations = await Context.Reconciliations.AsNoTracking()
                .Include(x=> x.IncomeOrExpenseType).ToListAsync();

            var map = Mapper.Map<List<ReconciliationListDto>>(reconciliations);

            return map;
        }
    }
}

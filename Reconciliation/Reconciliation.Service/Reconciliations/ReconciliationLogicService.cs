using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;
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

        public async Task CreateAsync(ReconciliationFormDto model)
        {
            var reconciliation = Mapper.Map<Reconciliation>(model);

            var entityEntry = await Context.Reconciliations.AddAsync(reconciliation);

            await Context.SaveChangesAsync();
        }

        public async Task<ReconciliationDto> GetAsync(string id)
        {
            var reconciliation = await Context.Reconciliations.FindAsync(id);

            var map = Mapper.Map<ReconciliationDto>(reconciliation);

            return map;
        }

        public async Task EditAsync(ReconciliationFormDto model)
        {
            var reconciliation = await Context.Reconciliations.FindAsync(model.Id);

            reconciliation = Mapper.Map(model, reconciliation);

            Context.Reconciliations.Update(reconciliation);
            

            await Context.SaveChangesAsync();
        }
    }
}

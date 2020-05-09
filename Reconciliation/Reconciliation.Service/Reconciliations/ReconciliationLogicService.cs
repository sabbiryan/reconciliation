using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore;
using ReconciliationApp.EntityFrameworkCore.IncomeOrExpenseTypes;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;
using ReconciliationApp.Service.Reconciliations.Dtos;
using ReconciliationApp.Shared.Dtos;
using ReconciliationApp.Shared.Extensions;

namespace ReconciliationApp.Service.Reconciliations
{
    public class ReconciliationLogicService: LogicServiceBase, IReconciliationLogicService
    {
        public ReconciliationLogicService(ReconciliationDbContext context) : base(context)
        {
        }

        public async Task<YearlyReconciliationGridDto> GetReconciliationsAsync(int year)
        {
            var grid = new YearlyReconciliationGridDto()
            {
                Year = year,
                Titles = Month.January.ToList().ConvertAll(x=> new YearlyReconciliationGridTitleDto(x)),
            };

            var reconciliations = await Context.Reconciliations.AsNoTracking()
                .Where(x => x.Year == year)
                .Include(x => x.IncomeOrExpenseType).ToListAsync();

            var incomeOrExpenseTypes = await Context.IncomeOrExpenseTypes.AsNoTracking().ToListAsync();
            incomeOrExpenseTypes = incomeOrExpenseTypes.OrderBy(x => x.Flag).ThenBy(x=> x.DisplayName).ToList();

            foreach (var type in incomeOrExpenseTypes)
            {
                var row = new YearlyReconciliationGridRowDto(type.DisplayName, type.Flag);

                foreach (var title in grid.Titles)
                {
                    var reconciliation = reconciliations.FirstOrDefault(x =>
                        x.Year == year && x.Month == title.Month && x.IncomeOrExpenseTypeId == type.Id);

                    var column = new YearlyReconciliationGridColumnDto()
                    {
                        Year = year,
                        Month = title.Month,
                        IncomeOrExpenseTypeId = type.Id
                    };

                    if (reconciliation != null)
                    {
                        column.Amount = reconciliation.Amount;
                        column.Flag = reconciliation.IncomeOrExpenseType.Flag;
                    }

                    row.Columns.Add(column);
                }

                grid.Rows.Add(row);
            }

            ReconciliationResultHelper.AddReconciliationResult(grid);

            return grid;
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

        public List<ComboBoxItemDto<int>> GetMonths()
        {
            var months = Enum.GetValues(typeof(Month)).Cast<Month>().ToList();

            var list = months.ConvertAll(x => new ComboBoxItemDto<int>()
            {
                Id = (int)x,
                DisplayText = x.GetDescription()
            });

            return list;
        }
    }
}

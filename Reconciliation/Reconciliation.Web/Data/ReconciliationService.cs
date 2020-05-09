using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReconciliationApp.EntityFrameworkCore.Reconciliations;
using ReconciliationApp.Service.Reconciliations;
using ReconciliationApp.Service.Reconciliations.Dtos;
using ReconciliationApp.Shared.Dtos;
using ReconciliationApp.Shared.Extensions;

namespace ReconciliationApp.Web.Data
{
    public class ReconciliationService: EndpointServiceBase
    {
        private readonly IReconciliationLogicService _reconciliationService;
        public ReconciliationService(IReconciliationLogicService reconciliationService)
        {
            _reconciliationService = reconciliationService;
        }


        public async Task<ReconciliationListDto[]> GetListAsync()
        {
            var result = await _reconciliationService.GetReconciliationsAsync();
            return result.ToArray();
        }

        public async Task CreateAsync(ReconciliationFormDto model)
        {
            await _reconciliationService.CreateAsync(model);
        }


        public async Task<ReconciliationFormDto> GetForEditAsync(string id)
        {
            var reconciliationDto = await _reconciliationService.GetAsync(id);

            var map = Mapper.Map<ReconciliationFormDto>(reconciliationDto);

            return map;
        }


        public async Task EditAsync(ReconciliationFormDto model)
        {
            await _reconciliationService.EditAsync(model);
        }


        public List<ComboBoxItemDto<int>> GetMonths()
        {
            var months = Enum.GetValues(typeof(Month)).Cast<Month>().ToList();

            var list = months.ConvertAll(x => new ComboBoxItemDto<int>()
            {
                Id = (int) x,
                DisplayText = x.GetDescription()
            });

            return list;
        }
    }
}
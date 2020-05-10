using System.Collections.Generic;
using System.Threading.Tasks;
using ReconciliationApp.Service.Reconciliations;
using ReconciliationApp.Service.Reconciliations.Dtos;
using ReconciliationApp.Shared.Dtos;

namespace ReconciliationApp.Blazor.Data
{
    public class ReconciliationService: EndpointServiceBase
    {
        private readonly IReconciliationLogicService _reconciliationLogicService;
        public ReconciliationService(IReconciliationLogicService reconciliationLogicService)
        {
            _reconciliationLogicService = reconciliationLogicService;
        }

        public async Task<YearlyReconciliationGridDto> GetYearlyTableAsync()
        {
            var reconciliations = await _reconciliationLogicService.GetReconciliationsAsync(2019);
            return reconciliations;
        }

        public async Task<ReconciliationListDto[]> GetListAsync()
        {
            var result = await _reconciliationLogicService.GetReconciliationsAsync();
            return result.ToArray();
        }

        public async Task CreateAsync(ReconciliationFormDto model)
        {
            await _reconciliationLogicService.CreateAsync(model);
        }


        public async Task<ReconciliationFormDto> GetForEditAsync(string id)
        {
            var reconciliationDto = await _reconciliationLogicService.GetAsync(id);

            var map = Mapper.Map<ReconciliationFormDto>(reconciliationDto);

            return map;
        }


        public async Task EditAsync(ReconciliationFormDto model)
        {
            if (!string.IsNullOrWhiteSpace(model.Id))
            {
                await _reconciliationLogicService.EditAsync(model);
            }
            else
            {
                await CreateAsync(model);
            }
        }


        public List<ComboBoxItemDto<int>> GetMonths()
        {
            var list = _reconciliationLogicService.GetMonths();

            return list;
        }
    }
}
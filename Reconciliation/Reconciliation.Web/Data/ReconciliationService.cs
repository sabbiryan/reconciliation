using System.Threading.Tasks;
using ReconciliationApp.Service.Reconciliations;
using ReconciliationApp.Service.Reconciliations.Dtos;

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

        public async Task CreateAsync(ReconciliationCreateDto model)
        {
            await _reconciliationService.CreateAsync(model);
        }


        public async Task<ReconciliationCreateDto> GetForEditAsync(string id)
        {
            var reconciliationDto = await _reconciliationService.GetAsync(id);

            var map = Mapper.Map<ReconciliationCreateDto>(reconciliationDto);

            return map;
        }


        public async Task EditAsync(ReconciliationCreateDto model)
        {
            await _reconciliationService.EditAsync(model);
        }
    }
}
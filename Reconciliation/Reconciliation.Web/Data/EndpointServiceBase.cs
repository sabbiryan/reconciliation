using AutoMapper;
using ReconciliationApp.Service.Mappers;

namespace ReconciliationApp.Blazor.Data
{
    public abstract class EndpointServiceBase
    {
        protected IMapper Mapper;

        protected EndpointServiceBase()
        {
            Mapper = MapperConfig.CreateMaps();
        }
    }
}
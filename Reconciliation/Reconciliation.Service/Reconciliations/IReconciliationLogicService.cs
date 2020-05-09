﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ReconciliationApp.Service.Reconciliations.Dtos;

namespace ReconciliationApp.Service.Reconciliations
{
    public interface IReconciliationLogicService
    {
        Task<List<ReconciliationListDto>> GetReconciliationsAsync();
        Task CreateAsync(ReconciliationFormDto model);
        Task<ReconciliationDto> GetAsync(string id);
        Task EditAsync(ReconciliationFormDto model);
    }
}
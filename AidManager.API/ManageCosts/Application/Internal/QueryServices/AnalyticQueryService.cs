using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Domain.Model.Queries;
using AidManager.API.ManageCosts.Domain.Repositories;
using AidManager.API.ManageCosts.Domain.Services;

namespace AidManager.API.ManageCosts.Application.Internal.QueryServices;

public class AnalyticQueryService(IAnalyticRepository analyticRepository) :IAnalyticQueryService
{
    public async Task<Analytic> Handle(GetAnalyticByIdQuery query)
    {
        Console.WriteLine("Query service called");
        return await analyticRepository.FindByIdAsync(query.Id);
    }
    
    
    public async Task<IEnumerable<Analytic>> Handle(GetAllAnalytics query) // New method
    {
        Console.WriteLine("Query service called");
        return await analyticRepository.FindByProjectIdAsync(query.ProjectId);
    }
    
}
using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Domain.Model.Commands;
using AidManager.API.ManageCosts.Domain.Repositories;
using AidManager.API.ManageCosts.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.ManageCosts.Application.Internal.CommandServices;

public class AnalyticCommandService(IAnalyticRepository analyticRepository, IUnitOfWork unitOfWork) :IAnalyticCommandService
{
    public async Task<Analytic> Handle(CreateAnalyticCommand command)
    {
        Console.WriteLine("Command service Called");
        var analytic = new Analytic(command);

        analyticRepository.CreateAnalytic(analytic);
        Console.WriteLine("Analytic added to repository");
        await unitOfWork.CompleteAsync();
        Console.WriteLine("unit of work completed");
        return analytic;
    }
}
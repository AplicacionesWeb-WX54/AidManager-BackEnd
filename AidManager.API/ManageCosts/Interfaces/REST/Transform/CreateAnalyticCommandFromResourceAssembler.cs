using AidManager.API.ManageCosts.Domain.Model.Commands;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;

namespace AidManager.API.ManageCosts.Interfaces.REST.Transform;

public static class CreateAnalyticCommandFromResourceAssembler
{
    public static CreateAnalyticCommand ToCommandFromResource(CreateAnalyticResource resource, int projectId) =>
        new CreateAnalyticCommand(resource.Title, resource.Description, resource.Cost, resource.Progress,
            resource.Current, resource.Expected, projectId);
}
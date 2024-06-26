namespace AidManager.API.ManageCosts.Domain.Model.Commands;

public record CreateAnalyticCommand(string Title, string Description, double Cost, double Progress, int[] Current, int[] Expected, int ProjectId);
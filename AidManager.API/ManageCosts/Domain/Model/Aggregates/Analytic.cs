using System.Runtime.InteropServices.JavaScript;
using AidManager.API.ManageCosts.Domain.Model.Commands;

namespace AidManager.API.ManageCosts.Domain.Model.Aggregates;

public class Analytic
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public double Cost { get; private set; }
    public double Progress { get; private set; }
    public int[] Current { get; private set; }
    public int[] Expected { get; private set; }
    
    public int ProjectId { get; private set; }

    protected Analytic()
    {
        this.Title = "nothing";
        this.Description = "nothing";
        this.Cost = 0.0;
        this.Progress = 0.0;
        this.Current = new int[12];
        this.Expected = new int[12];
    }
    public Analytic(CreateAnalyticCommand command)
    {
        this.Title = command.Title;
        this.Description = command.Description;
        this.Cost = command.Cost;
        this.Progress = command.Progress;
        this.Current = command.Current;
        this.Expected = command.Expected;
        this.ProjectId = command.ProjectId;
    }
    public void UpdateAnalytic(UpdateAnalyticCommand command)
    {
        this.Title = command.Title;
        this.Description = command.Description;
        this.Cost = command.Cost;
        this.Progress = command.Progress;
        this.Current = command.Current;
        this.Expected = command.Expected;
    }
}
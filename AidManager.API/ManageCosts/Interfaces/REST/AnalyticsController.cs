using System.Net.Mime;
using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Domain.Model.Queries;
using AidManager.API.ManageCosts.Domain.Services;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;
using AidManager.API.ManageCosts.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AidManager.API.ManageCosts.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]/{projectId}")]
[Produces(MediaTypeNames.Application.Json)]
public class AnalyticsController(IAnalyticCommandService analyticCommandService, IAnalyticQueryService analyticQueryService): ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult> GetAnalyticById(int id)
    {
        Console.WriteLine("Get Analytic By Id called");
        var getAnalyticByIdQuery = new GetAnalyticByIdQuery(id);
        Console.WriteLine("Query Created");
        var result = await analyticQueryService.Handle(getAnalyticByIdQuery);
        Console.WriteLine("Query Handled");
        var resource = AnalyticResourceFromEntityAssembler.ToResourceFromEntity(result);
        Console.WriteLine("Resource Created");
        return Ok(resource);
    }
    [HttpGet]
    public async Task<IEnumerable<Analytic>> GetAllAnalytics(int projectId)
    {
        Console.WriteLine("Get All Analytics called");
        var getAllAnalyticsQuery = new GetAllAnalytics(projectId);
        Console.WriteLine("Query Created");
        var result = await analyticQueryService.Handle(getAllAnalyticsQuery);
        Console.WriteLine("Query Handled");
        return result;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAnalytic(int projectId,[FromBody] CreateAnalyticResource resource)
    {
        Console.WriteLine("Create Analytic called");
        var createAnalyticCommand = CreateAnalyticCommandFromResourceAssembler.ToCommandFromResource(resource, projectId);
        Console.WriteLine("Command Created");
        var result = await analyticCommandService.Handle(createAnalyticCommand);
        
        var analyticById = GetAnalyticById(result.Id);
        Console.WriteLine("Analytic By Id called" + analyticById.Result);
        
        return CreatedAtAction(nameof(GetAnalyticById), new {projectId = projectId, id = result.Id },
            AnalyticResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAnalytic(int id, [FromBody] UpdateAnalyticResource resource)
    {
        var updateTaskCommand = UpdateAnalyticCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await analyticCommandService.Handle(updateTaskCommand);
        return Ok(AnalyticResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}
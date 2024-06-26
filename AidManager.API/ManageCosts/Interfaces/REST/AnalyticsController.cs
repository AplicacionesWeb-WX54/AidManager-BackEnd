using System.Net.Mime;
using AidManager.API.ManageCosts.Domain.Model.Queries;
using AidManager.API.ManageCosts.Domain.Services;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;
using AidManager.API.ManageCosts.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AidManager.API.ManageCosts.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AnalyticsController(
    IAnalyticsCommandService analyticsCommandService,
    IAnalyticsQueryService analyticsQueryService
    ) : ControllerBase
{
    
    [HttpPost]
    [SwaggerResponse(201, "Analytics created", typeof(CreateAnalyticsResource))]
    public async Task<IActionResult> CreateNewAnalytics([FromBody] CreateAnalyticsResource resource)
    {
        var command = CreateAnalyticsCommandFromResourceAssembler.ToCommandFromResource(resource);
        var analytic = await analyticsCommandService.Handle(command);
        
        if (analytic == null)
        {
            return NotFound();
        }
        
        var analyticResource = AnalyticsResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(analyticResource);
    }
    
    [HttpGet("{projectId}")]
    [SwaggerResponse(200, "Analytics found", typeof(AnalyticsResource))]
    public async Task<IActionResult> GetAnalyticsByProjectId([FromRoute] int projectId)
    {
        var query = new GetAnalyticsByProjectId(projectId);
        var analytic = await analyticsQueryService.Handle(query);
        
        if (analytic == null)
        {
            return NotFound();
        }
        
        var analyticResource = AnalyticsResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(analyticResource);
    }
    
    [HttpPatch("payments")]
    [SwaggerResponse(200, "Analytics updated", typeof(UpdateAnalyticPaymentsResource))]
    public async Task<IActionResult> UpdateAnalyticPayments([FromBody] UpdateAnalyticPaymentsResource resource)
    {
        var command = UpdateAnalyticPaymentCommandFromResourceAssembler.ToCommandFromResource(resource.Id, resource);
        var analytic = await analyticsCommandService.Handle(command);
        
        if (analytic == null)
        {
            return NotFound();
        }
        
        var analyticResource = AnalyticsResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(analyticResource);
    }
    
    [HttpPatch("lines")]
    [SwaggerResponse(200, "Analytics updated", typeof(UpdateAnalyticLinesResource))]
    public async Task<IActionResult> UpdateAnalyticLines([FromBody] UpdateAnalyticLinesResource resource)
    {
        var command = UpdateAnalyticLinesCommandFromResourceAssembler.ToCommandFromResource(resource.Id, resource);
        var analytic = await analyticsCommandService.Handle(command);
        
        if (analytic == null)
        {
            return NotFound();
        }
        
        var analyticResource = AnalyticsResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(analyticResource);
    }
    
    [HttpPatch("tasks")]
    [SwaggerResponse(200, "Analytics updated", typeof(UpdateAnalyticTasksResource))]
    public async Task<IActionResult> UpdateAnalyticTasks([FromBody] UpdateAnalyticTasksResource resource)
    {
        var command = UpdateAnalyticTasksCommandFromResourceAssembler.ToCommandFromResource(resource.Id, resource);
        var analytic = await analyticsCommandService.Handle(command);
        
        if (analytic == null)
        {
            return NotFound();
        }
        
        var analyticResource = AnalyticsResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(analyticResource);
    }
    
    [HttpPatch("progressbar")]
    [SwaggerResponse(200, "Analytics updated", typeof(UpdateAnalyticProgressbarResource))]
    public async Task<IActionResult> UpdateAnalyticProgressbar([FromBody] UpdateAnalyticProgressbarResource resource)
    {
        var command = UpdateAnalyticProgressbarCommandFromResourceAssembler.ToCommandFromResource(resource.Id, resource);
        var analytic = await analyticsCommandService.Handle(command);
        
        if (analytic == null)
        {
            return NotFound();
        }
        
        var analyticResource = AnalyticsResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(analyticResource);
    }
    
    [HttpPatch("status")]
    [SwaggerResponse(200, "Analytics updated", typeof(UpdateAnalyticStatusResource))]
    public async Task<IActionResult> UpdateAnalyticStatus([FromBody] UpdateAnalyticStatusResource resource)
    {
        var command = UpdateAnalyticStatusCommandFromResourceAssembler.ToCommandFromResource(resource.Id, resource);
        var analytic = await analyticsCommandService.Handle(command);
        
        if (analytic == null)
        {
            return NotFound();
        }
        
        var analyticResource = AnalyticsResourceFromEntityAssembler.ToResourceFromEntity(analytic);
        return Ok(analyticResource);
    }
    
}
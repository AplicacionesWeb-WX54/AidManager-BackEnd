﻿using System.Net.Mime;
using AidManager.API.Collaborate.Domain.Model.Queries;
using AidManager.API.Collaborate.Domain.Services;
using AidManager.API.Collaborate.Interfaces.REST.Resources;
using AidManager.API.Collaborate.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AidManager.API.Collaborate.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class EventsController(IEventCommandService eventCommandService, IEventQueryService eventQueryService) : ControllerBase
{
    
    [HttpPost]
    public async Task<ActionResult> CreateNewEvent([FromBody] CreateEventResource resource)
    {
        var createEventCommand = CreateEventCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await eventCommandService.handle(createEventCommand);
        if(!result) return Ok(new {status_code = "500", message = "Event not created"});
        return Ok(new {status_code = "202", message = "Event created"});
    }
    
    [HttpGet]
    public async Task<IEnumerable<GetEventResource>?> GetAllEvents()
    {
        var events = await eventQueryService.handle(new GetAllEventsQuery());
        if (events == null) return [];
        var result = events.Select(EventResourceFromEntityAssembler.ToResourceFromEntity);
        return result;
    }
}
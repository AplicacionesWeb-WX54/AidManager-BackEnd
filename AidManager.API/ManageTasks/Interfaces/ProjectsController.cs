﻿using System.Net.Mime;
using AidManager.API.ManageTasks.Domain.Model.Queries;
using AidManager.API.ManageTasks.Domain.Services;
using AidManager.API.ManageTasks.Interfaces.REST.Resources;
using AidManager.API.ManageTasks.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AidManager.API.ManageTasks.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProjectsController (IProjectCommandService projectCommandService, IProjectQueryService projectQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProject(CreateProjectResource resource)
    {
        var createProjectCommand = CreateProjectCommandFromResourceAssembler.ToCommandFromResource(resource);
        var project = await projectCommandService.Handle(createProjectCommand);
        var projectResource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(projectResource);
    }
    
    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetAllProjects(string companyId)
    {
        var projects = await projectQueryService.Handle(new GetAllProjectsQuery(companyId));
        var projectResources = projects.Select(ProjectResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(projectResources);
    }
    
    
}
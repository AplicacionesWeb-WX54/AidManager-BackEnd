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
public class ProjectsController(IProjectCommandService projectCommandService, IProjectQueryService projectQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProject(CreateProjectResource resource)
    {
        var createProjectCommand = CreateProjectCommandFromResourceAssembler.ToCommandFromResource(resource);
        var project = await projectCommandService.Handle(createProjectCommand);
        var projectResource = ProjectResourceFromEntityAssembler.ToResourceFromEntity(project);
        return Ok(projectResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await projectQueryService.Handle(new GetAllProjectsQuery());
        var projectResources = projects.Select(ProjectResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(projectResources);
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetProjectsByCompanyId([FromRoute] string companyId)
    {
        try
        {
            var projects = await projectQueryService.Handle(new GetAllProjectsByCompanyIdQuery(companyId));
            var projectResources = projects.Select(ProjectResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(projectResources);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
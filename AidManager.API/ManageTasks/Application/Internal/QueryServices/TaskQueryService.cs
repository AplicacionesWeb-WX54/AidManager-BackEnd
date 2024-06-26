﻿using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Model.Queries;
using AidManager.API.ManageTasks.Domain.Repositories;
using AidManager.API.ManageTasks.Domain.Services;

namespace AidManager.API.ManageTasks.Application.Internal.QueryServices;

public class TaskQueryService(ITaskRepository taskRepository) : ITaskQueryService
{
    public async Task<IEnumerable<TaskItem>> Handle(GetAllTasksQuery query)
    {
        return await taskRepository.ListAsync();
    }
        
    public async Task<TaskItem> Handle(GetTaskByIdQuery query)
    {
        return await taskRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<List<TaskItem>> Handle(GetTasksByProjectIdQuery query)
    {
        return await taskRepository.GetTasksByProjectId(query.ProjectId);
    }
}
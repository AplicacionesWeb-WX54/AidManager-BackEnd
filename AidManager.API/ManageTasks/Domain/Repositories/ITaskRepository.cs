﻿using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Model.Queries;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.ManageTasks.Domain.Repositories;

public interface ITaskRepository : IBaseRepository<TaskItem>
{
    Task<List<TaskItem>> GetTasksByProjectId(int projectId);

}
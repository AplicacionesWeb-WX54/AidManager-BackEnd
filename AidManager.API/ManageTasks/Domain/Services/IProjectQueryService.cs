﻿using System.Collections;
using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Model.Queries;

namespace AidManager.API.ManageTasks.Domain.Services;

public interface IProjectQueryService
{
    Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query);
}
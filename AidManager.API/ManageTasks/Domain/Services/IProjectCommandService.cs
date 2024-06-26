﻿using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Model.Commands;

namespace AidManager.API.ManageTasks.Domain.Services;

public interface IProjectCommandService
{
    Task<Project> Handle(CreateProjectCommand command);

}
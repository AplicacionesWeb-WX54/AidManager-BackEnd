﻿namespace AidManager.API.UserProfile.Domain.Model.Commands;

public record UpdateUserCommand(string FirstName, string LastName, int Age, string Phone, string Occupation, string ProfileImg, string Bio, string CompanyId);
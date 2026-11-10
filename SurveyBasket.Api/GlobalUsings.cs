global using Serilog;
global using Hangfire;
global using HangfireBasicAuthenticationFilter;
global using Hangfire.Dashboard;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.OpenApi.Models;

global using System.Security.Claims;

global using SurveyBasket.Api.Extensions;
global using SurveyBasket.Api.Configurations;

global using SurveyBasket.Application.Contracts.Authentication;
global using SurveyBasket.Application.Interfaces;
global using SurveyBasket.Application.Contracts.Polls;
global using SurveyBasket.Application;
global using SurveyBasket.Application.Common.Results;
global using SurveyBasket.Application.Common.Errors;
global using SurveyBasket.Application.Contracts.Questions;
global using SurveyBasket.Application.Contracts.Votes;

global using SurveyBasket.Infrastructure;
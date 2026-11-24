global using Serilog;
global using Hangfire;
global using MailKit.Net.Smtp;
global using MailKit.Security;
global using HangfireBasicAuthenticationFilter;
global using HealthChecks.UI.Client;

global using Microsoft.AspNetCore.RateLimiting;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.OpenApi.Models;
global using Microsoft.Extensions.Options;
global using Microsoft.Extensions.Diagnostics.HealthChecks;

global using System.Security.Claims;
global using System.Threading.RateLimiting;

global using SurveyBasket.Api.Extensions;
global using SurveyBasket.Api.Configurations;
global using SurveyBasket.Api.Filters;
global using SurveyBasket.Api.Health;

global using SurveyBasket.Application.Contracts.Authentication;
global using SurveyBasket.Application.Interfaces;
global using SurveyBasket.Application.Contracts.Polls;
global using SurveyBasket.Application;
global using SurveyBasket.Application.Common.Results;
global using SurveyBasket.Application.Common.Errors;
global using SurveyBasket.Application.Contracts.Questions;
global using SurveyBasket.Application.Contracts.Votes;
global using SurveyBasket.Application.Contracts.Users;
global using SurveyBasket.Application.Common.Consts;
global using SurveyBasket.Application.Contracts.Roles;
global using SurveyBasket.Application.Contracts.Common;

global using SurveyBasket.Infrastructure;
global using SurveyBasket.Infrastructure.Options;

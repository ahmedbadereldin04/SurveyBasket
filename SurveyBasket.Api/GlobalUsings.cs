global using Serilog;
global using Hangfire;
global using Asp.Versioning;
global using System.Reflection;
global using MailKit.Net.Smtp;
global using MailKit.Security;
global using HealthChecks.UI.Client;
global using Asp.Versioning.ApiExplorer;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using HangfireBasicAuthenticationFilter;
global using Swashbuckle.AspNetCore.Annotations;

global using Microsoft.AspNetCore.RateLimiting;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.OpenApi.Models;
global using Microsoft.Extensions.Options;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Mvc.ApiExplorer;

global using System.Security.Claims;
global using System.Threading.RateLimiting;
global using System.Text.Json;

global using SurveyBasket.Api.Extensions;
global using SurveyBasket.Api.Configurations;
global using SurveyBasket.Api.Filters;
global using SurveyBasket.Api.Health;
global using SurveyBasket.Api.Common.Consts;
global using SurveyBasket.Api.Exceptions;
global using SurveyBasket.Api.Swagger;

global using SurveyBasket.Application.Contracts.Authentication;
global using SurveyBasket.Application.Interfaces;
global using SurveyBasket.Application.Contracts.Polls;
global using SurveyBasket.Application;
global using SurveyBasket.Application.Common.Results;
global using SurveyBasket.Application.Contracts.Questions;
global using SurveyBasket.Application.Contracts.Votes;
global using SurveyBasket.Application.Contracts.Users;
global using SurveyBasket.Application.Common.Consts;
global using SurveyBasket.Application.Contracts.Roles;
global using SurveyBasket.Application.Contracts.Common;
global using SurveyBasket.Application.Common.Interfaces;

global using SurveyBasket.Infrastructure;
global using SurveyBasket.Infrastructure.Options;
global using SurveyBasket.Infrastructure.Common.Consts;

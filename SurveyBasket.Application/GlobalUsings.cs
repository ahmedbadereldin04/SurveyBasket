global using FluentValidation;
global using FluentValidation.AspNetCore;

global using Mapster;
global using MapsterMapper;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Logging;

global using System.Reflection;

global using SurveyBasket.Application.Interfaces;
global using SurveyBasket.Application.Services;
global using SurveyBasket.Domain.Entities;
global using SurveyBasket.Application.Contracts.Authentication;
global using SurveyBasket.Application.Common.Interfaces;
global using SurveyBasket.Application.Common.Errors;
global using SurveyBasket.Application.Common.Results;
global using SurveyBasket.Application.Contracts.Polls;
global using SurveyBasket.Application.Contracts.Answers;
global using SurveyBasket.Application.Contracts.Questions;

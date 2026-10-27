global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using System.ComponentModel.DataAnnotations;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using System.Security.Cryptography;
global using System.Reflection;


global using SurveyBasket.Domain.Entities;
global using SurveyBasket.Application.Common.Interfaces;
global using SurveyBasket.Application.Contracts.Authentication;
global using SurveyBasket.Application.Interfaces;
global using SurveyBasket.Infrastructure.Persistence;
global using SurveyBasket.Infrastructure.Services;
global using SurveyBasket.Application.Common.Errors;
global using SurveyBasket.Application.Common.Results;
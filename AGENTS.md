# SurveyBasket AGENTS.md

## Stack
- .NET 10, ASP.NET Core Web API
- Clean Architecture: `SurveyBasket.Api` -> `SurveyBasket.Application` -> `SurveyBasket.Domain` / `SurveyBasket.Infrastructure` implements `Application` contracts
- EF Core 10 + SQL Server (`DefaultConnection` in `appsettings.json`), Identity (`ApplicationUser` + `RefreshToken` owned)
- Auth: JWT Bearer (access + refresh tokens). Refresh tokens stored on user as owned collection (`RefreshTokens` table). 
- Cross-cutting: Mapster, FluentValidation, Result pattern, custom `GlobalExecptionHandler` + `ToProblem` extension, CORS (allow any origin/method/header)
- Swagger enabled in Development

## Key entrypoints / wiring
- `Program.cs`: `AddInfrastructure().AddApplication()`; middleware: `UseHttpsRedirection`, `UseCors()`, `UseAuthorization()`, `UseExceptionHandler()`, `MapControllers()`. Swagger only in dev.
- `SurveyBasket.Application/DependencyInjection.cs`: adds controllers, `IPollService`/`IQuestionService`, Mapster scan from Application assembly, FluentValidation auto-validation from Application assembly.
- `SurveyBasket.Infrastructure/DependencyInjention.cs` (typo in filename): DbContext, `IApplicationDbContext` -> `ApplicationDbContext`, Identity + EF stores + default token providers, `IAuthService`/`IJwtProvider`, JWT auth with validation, Swagger with Bearer security, CORS default policy, `GlobalExecptionHandler` + Problem Details.
- `ApplicationDbContext`: extends `IdentityDbContext<ApplicationUser>`, sets all FK delete behavior to `Restrict` (except ownership), tracks audit fields on `AuditableEntity` via `IHttpContextAccessor` (`CreatedById` on Add, `UpdatedById`/`UpdatedOn` on Modify).
- Global usings spread across layers (see each `GlobalUsings.cs`).

## Commands (exact)
```bash
# Build
dotnet build SurveyBasket.slnx

# Run API (https launches Swagger)
dotnet run --project SurveyBasket.Api --launch-profile https
dotnet run --project SurveyBasket.Api --launch-profile http

# EF Core migrations (from solution root; Infrastructure has tools)
# No dotnet-ef tool installed globally here - use SDK or add tool if needed
dotnet ef migrations add <Name> --project SurveyBasket.Infrastructure --startup-project SurveyBasket.Api
dotnet ef database update --project SurveyBasket.Infrastructure --startup-project SurveyBasket.Api
```
- DB: `Server=.;Database=SurveyBasketDb;Trusted_Connection=true;TrustServerCertificate=True;` (change in `appsettings.json`).
- JWT key empty in `appsettings.json` - must be set (via user-secrets/env). `JwtOptions` validated on start.

## API patterns
- Controllers under `Api/Controllers/`: `[Authorize]` on `PollsController` and `QuestionsController` (nested under `/api/polls/{pollId}/questions`), `AuthController` at `[controller]` (login/refresh/revoke) is unauthenticated.
- Result pattern: services return `Result`/`Result<T>`. Controllers map via `result.ToProblem(statusCode)` (from `Api/Extensions/ResultExtensions.cs`). Success returns `Ok`, `CreatedAtRoute`, or `NoContent`. Common errors: `PollErrors`, `QuestionErrors`, `UserErrors` (in `Application/Common/Errors/`).
- Validation: FluentValidation validators in `Application/Contracts/*` (auto-validated). 
- Mapping: Mapster with `MappingConfigurations : IRegister` (e.g. QuestionRequest -> Question maps Answers). `TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly())`.

## Domain/model gotchas
- `Poll`/`Question` inherit `AuditableEntity` (created/updated by/user + timestamps). `ApplicationDbContext.SaveChangesAsync` fills audit from `HttpContext.User` claims (`NameIdentifier`).
- `Question` has unique `(PollId, Content)` and owns `Answers` (unique `(QuestionId, Content)`, max length 1000). `QuestionService.AddAsync` adds answers from request strings.
- All cascade FKs converted to `Restrict` globally in `OnModelCreating`.
- `RefreshToken` is `[Owned]`, stored in `RefreshTokens` table via `UserConfiguration`.
- JWT validation in `JwtProvider.ValidateToken` ignores issuer/audience and only checks signing key (used for refresh/revoke flows).

## Notes
- No tests in repo. 
- `SurveyBasket.Api.http` contains a sample request with a hardcoded bearer token (ignore/replace).
- `SQLQuery2.sql` is scratch.
- Solution file is `SurveyBasket.slnx` (SDK-style solution format).
- `dotnet-ef` not installed globally in this environment.

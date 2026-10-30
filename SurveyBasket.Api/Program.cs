var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register Application and Infrastructure services
builder.Services.AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
 
app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();

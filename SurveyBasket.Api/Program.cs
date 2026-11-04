var builder = WebApplication.CreateBuilder(args);


// Register Application and Infrastructure services
builder.Services.AddInfrastructure(builder.Configuration)
    .AddApplication();

// Configure application logging with Serilog
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
 
app.UseAuthorization();

app.MapControllers();

app.Run();

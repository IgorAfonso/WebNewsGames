using WebGames.Infra.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string DevelopmentCorsPolicy = "DevelopmentCorsPolicy";

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add swagger in the project
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(DevelopmentCorsPolicy, policy =>
    {
        policy.WithOrigins(
                "http://localhost:3001",
                "https://localhost:3001")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//Dependency Injection
DependencyInjectionConfig.DependencyInjectionConfiguration(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(DevelopmentCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();

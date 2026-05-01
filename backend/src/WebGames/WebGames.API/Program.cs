using WebGames.Infra.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);
const string DevelopmentCorsPolicy = "DevelopmentCorsPolicy";

builder.Services.AddControllers();
builder.Services.AddOpenApi();
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

DependencyInjectionConfig.DependencyInjectionConfiguration(builder.Services, builder.Configuration);

var app = builder.Build();

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
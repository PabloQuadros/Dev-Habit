using DevHabit.Api;
using DevHabit.Api.Extensions;
using DevHabit.Api.Settings;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder
    .AddApiServices()
    .AddErrorHandling()
    .AddDatabase()
    .AddObservability()
    .AddApplicationServices()
    .AddAuthenticationServices()
    .AddBackgroundJobs()
    .AddCorsPolicy()
    .AddRateLimiting();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapScalarApiReference(options =>
{
    options.AddDocument("v1", "DevHabit API v1", "/swagger/1.0/swagger.json");
    options.AddDocument("v2", "DevHabit API v2", "/swagger/2.0/swagger.json");

    //options.WithOpenApiRoutePattern("/swagger/1.0/swagger.json");
});

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    await app.ApplyMigrationsAsync();

    await app.SeedInitialDataAsync();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseCors(CorsOptions.PolicyName);

app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();

app.UseUserContextEnrichment();
//app.UseETag();

app.MapControllers();

await app.RunAsync();

public partial class Program;

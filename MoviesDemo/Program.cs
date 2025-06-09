using MoviesDemo;
using MoviesDemo.Endpoints;
using MoviesDemo.Middleware;
using MoviesDemo.Middlewares;
using Scalar.AspNetCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    var origins = builder.Configuration.GetSection("Origins").Get<string[]>();
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials()
                          .SetIsOriginAllowed(origin => true)
                          .WithOrigins(origins);
                      });
});
// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add  Dependency Injections
builder.Services.AddAppDI(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Servers = [];
    });
}


app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseMiddleware<ApiKeyValidatorMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapMoviesRoutes(builder.Configuration);

app.Run();

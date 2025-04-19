using System.Net.Http.Json;
using Microsoft.OpenApi.Models;

using TronApiApp.Routes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddCors(options => {});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dotnet API", Description = "Null", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotnet API V1");
   });
}


app.MapGet("/", () => "Hello World!");

// Register tron routes
app.MapTronRoutes();

app.Run();

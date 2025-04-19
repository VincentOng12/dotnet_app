using System.Net.Http.Json;
using System.Text.Json;
using TronApiApp.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

HttpClient http = new HttpClient
{
    BaseAddress = new Uri("https://api.shasta.trongrid.io")
};

app.MapGet("/", () => "Hello World!");

app.MapPost("/tron/account", async (TronRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Address))
        return Results.BadRequest(new { error = "Missing or invalid address." });

    try
    {
        var result = await http.GetFromJsonAsync<JsonElement>($"/v1/accounts/{request.Address}");
        return Results.Json(result);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Failed to get account info: {ex.Message}");
    }
});

app.MapPost("/tron/account/transactions", async (TronRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Address))
        return Results.BadRequest(new { error = "Missing or invalid address." });

    try
    {
        var result = await http.GetFromJsonAsync<JsonElement>($"/v1/accounts/{request.Address}/transactions");
        return Results.Json(result);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Failed to get transactions: {ex.Message}");
    }
});

app.MapPost("/tron/account/trc20", async (TronRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Address))
        return Results.BadRequest(new { error = "Missing or invalid address." });

    try
    {
        var result = await http.GetFromJsonAsync<JsonElement>($"/v1/accounts/{request.Address}/transactions/trc20");
        return Results.Json(result);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Failed to get TRC20 transactions: {ex.Message}");
    }
});

app.Run();

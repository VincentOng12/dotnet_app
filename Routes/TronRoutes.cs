namespace TronApiApp.Routes;

using Microsoft.AspNetCore.Routing;
using System.Text.Json;
using TronApiApp.Models;

public static class TronRoutes
{
    public static RouteGroupBuilder MapTronRoutes(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/tron");

        const string BaseUrl = "https://api.shasta.trongrid.io";
        
        group.MapPost("/account", async (TronRequest request, HttpClient http) =>
        {
            if (string.IsNullOrWhiteSpace(request.Address))
                return Results.BadRequest(new { error = "Missing address" });

            try
            {
                var result = await http.GetFromJsonAsync<JsonElement>($"{BaseUrl}/v1/accounts/{request.Address}");
                return Results.Json(result);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Failed to get account info: {ex.Message}");
            }
        });

        group.MapPost("/account/transactions", async (TronRequest request, HttpClient http) =>
        {
            if (string.IsNullOrWhiteSpace(request.Address))
                return Results.BadRequest(new { error = "Missing address" });

            try
            {
                var result = await http.GetFromJsonAsync<JsonElement>($"{BaseUrl}/v1/accounts/{request.Address}/transactions");
                return Results.Json(result);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Failed to get transactions: {ex.Message}");
            }
        });

        group.MapPost("/account/trc20", async (TronRequest request, HttpClient http) =>
        {
            if (string.IsNullOrWhiteSpace(request.Address))
                return Results.BadRequest(new { error = "Missing address" });

            try
            {
                var result = await http.GetFromJsonAsync<JsonElement>($"{BaseUrl}/v1/accounts/{request.Address}/transactions/trc20");
                return Results.Json(result);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Failed to get TRC20 transactions: {ex.Message}");
            }
        });

        return group;
    }
}

using MSUAgent.Application.Interfaces;
using MSUAgent.Application.Models;
using System.Net.Http.Json;

namespace MSUAgent.Infrastructure.Clients;

public class AiClient : IAiClient
{
    private readonly HttpClient _httpClient;

    public AiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> SendChatRequest(string message, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsync(
            "/api/chat",
            JsonContent.Create(message),
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<AiChatResponse>(
            cancellationToken);

        return result?.Answer
            ?? throw new InvalidOperationException(
                "AI service returned an empty response.");
    }
}
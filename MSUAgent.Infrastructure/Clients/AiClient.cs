using MSUAgent.Application.Interfaces;
using MSUAgent.Application.Models;
using MSUAgent.Application.Models.Results;
using System.Net.Http.Json;

namespace MSUAgent.Infrastructure.Clients;

public class AiClient : IAiClient
{
    private readonly HttpClient _httpClient;

    public AiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IResult<string>> SendChatRequest(string message, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsync(
            "/api/chat",
            JsonContent.Create(message),
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return ResultExtensions.Failure<string>(
                ErrorType.Internal,
                "AI service request failed.");
        }

        var result = await response.Content.ReadFromJsonAsync<AiChatResponse>(cancellationToken);

        if (string.IsNullOrEmpty(result?.Answer))
        {
            return ResultExtensions.Failure<string>(
                ErrorType.Internal,
                "AI service returned an empty response.");
        }

        return result.Answer.Success();
    }
}
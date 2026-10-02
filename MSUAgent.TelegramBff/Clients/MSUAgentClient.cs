using System.Net.Http.Json;

namespace MSUAgent.TelegramBff.Clients;

public sealed class MSUAgentClient : IMSUAgentClient
{
    private readonly HttpClient _httpClient;

    public MSUAgentClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> SendChatRequest(string message, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/chat",
            message,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<string>(cancellationToken);

        return result
            ?? throw new InvalidOperationException(
                "Backend returned an empty response.");
    }

    public async Task<HttpResponseMessage> SendHealthRequest(CancellationToken cancellationToken)
    {
        return await _httpClient.GetAsync("/health", cancellationToken);
    }
}
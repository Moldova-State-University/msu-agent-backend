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
        var httpResponseMessage = await _httpClient.PostAsync("/chat", JsonContent.Create(message), cancellationToken);
        return await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
    }

    public async Task<HttpResponseMessage> SendHealthRequest(CancellationToken cancellationToken)
    {
        return await _httpClient.GetAsync("/health", cancellationToken);
    }
}
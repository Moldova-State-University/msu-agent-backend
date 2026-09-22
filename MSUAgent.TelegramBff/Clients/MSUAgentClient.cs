using System.Net.Http.Json;
using System.Text.Json;

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

        var result = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);

        var result2 = JsonDocument.Parse(result);

        var result3 = JsonDocument.Parse(result2.RootElement.GetString());

        // TODO Add results from 4 to 128
        return result3.RootElement.GetProperty("answer").GetString();
    }

    public async Task<HttpResponseMessage> SendHealthRequest(CancellationToken cancellationToken)
    {
        return await _httpClient.GetAsync("/health", cancellationToken);
    }
}

public record AnswerDto(string answer);
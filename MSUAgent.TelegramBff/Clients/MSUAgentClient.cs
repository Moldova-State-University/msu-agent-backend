
namespace MSUAgent.TelegramBff.Clients;
public sealed class MSUAgentClient : IMSUAgentClient
{
    private readonly HttpClient _httpClient;

    public MSUAgentClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> SendHealthRequest(CancellationToken cancellationToken)
    {
        return await _httpClient.GetAsync("/health", cancellationToken);
    }
}
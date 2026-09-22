using MSUAgent.Application.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace MSUAgent.Infrastructure.Clients
{
    public class AiClient : IAiClient
    {
        private readonly HttpClient _httpClient;

        public AiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendChatRequest(string message, CancellationToken cancellationToken)
        {
            var bodyObj = new
            {
                Question = message
            };

            var content = JsonSerializer.Serialize(bodyObj);

            var httpResponseMessage = await _httpClient.PostAsync("/api/chat", JsonContent.Create(content), cancellationToken);
            return await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
        }
    }
}
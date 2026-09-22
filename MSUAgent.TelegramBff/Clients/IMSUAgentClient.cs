namespace MSUAgent.TelegramBff.Clients;

public interface IMSUAgentClient
{
    Task<HttpResponseMessage> SendHealthRequest(CancellationToken cancellationToken);
    Task<string> SendChatRequest(string message, CancellationToken cancellationToken);
}
namespace MSUAgent.TelegramBff.Clients;

public interface IMSUAgentClient
{
    Task<HttpResponseMessage> SendHealthRequest(CancellationToken cancellationToken);
}


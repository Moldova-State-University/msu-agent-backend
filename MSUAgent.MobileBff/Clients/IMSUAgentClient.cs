namespace MSUAgent.MobileBff.Clients;

public interface IMSUAgentClient
{
    Task<HttpResponseMessage> SendHealthRequest(CancellationToken cancellationToken);
}


namespace MSUAgent.Application.Interfaces
{
    public interface IAiClient
    {
        Task<string> SendChatRequest(string message, CancellationToken cancellationToken);
    }
}
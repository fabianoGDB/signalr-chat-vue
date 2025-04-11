using Chat.Api.Model;

namespace Chat.Api.Hubs
{
    public interface IHubProvider
    {
        Task ReceivedMessage(Message message);
    }
}

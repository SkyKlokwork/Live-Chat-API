using System.Text.Json;
using Klokwork.ChatApp.DataSources.Client;

namespace Klokwork.ChatApp.DataSources.RequestHandler;
public class TextHandler : IRequestHandler
{
    public Task Handle(Packet packet)
    {
        var payload = packet.Payload.Deserialize<MessagePayload>()!;
        Console.WriteLine($"Author Id: {payload.authorId}\nChannel Id: {payload.channelId}\nMessage: {payload.message}");
        return Task.CompletedTask;
    }
}
public class RoomDataHandler : IRequestHandler
{
    public Task Handle(Packet packet)
    {
        throw new NotImplementedException();
    }
}
using Klokwork.ChatApp.DataSources.Client;

namespace Klokwork.ChatApp.DataSources.RequestHandler;
public interface IRequestHandler {
    public Task Handle(Packet packet);
}
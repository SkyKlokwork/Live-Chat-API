using Klokwork.ChatApp.DataSources.Client;

namespace Klokwork.ChatApp.DataSources.RequestHandler;
public class RequestHandlerProvider {
    // Do I need it to be a dictionary?
    private readonly Dictionary<PacketType,IRequestHandler> _provider = new () {
        {PacketType.PACKET_MESSAGE,new TextHandler()},
        {PacketType.PACKET_ROOM_DATA,new RoomDataHandler()}
        };
    // dumb doo doo code. I'm not feeling great but want something
    // forcing them to add the handler themselves and assign its associated packet type feels somewhat wrong
    // can also lead to annoying issues like them putting the wrong handler in
    // probably better to figure out a way for the packettype to be assigned to the handler on initialization (maybe somehow using generic types?)
    
    // Do I need to return the handler?
    public IRequestHandler? GetRequestHandler(Packet packet) {
        IRequestHandler? test = _provider.ContainsKey(packet.Type) ? _provider.GetValueOrDefault(packet.Type) : throw new KeyNotFoundException(nameof(packet.Type));
        test!.Handle(packet);
        return null;
    }
}
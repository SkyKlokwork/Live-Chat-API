using System.Text.Json;
using System.Text.Json.Nodes;

namespace Klokwork.ChatApp.DataSources.Client;
public class Packet {
    public PacketType Type {get; set;}
    public JsonElement Payload {get; set;}
    public Packet(PacketType type,object payload, JsonObject? ids) {
        Type = type;
        Payload = JsonSerializer.SerializeToElement(payload);
    }
    public Packet(PacketType type, JsonElement payload) {
        Type = type;
        Payload = payload;
    }
    public Packet(PacketType type) {
        Type = type;
    }
    public JsonObject ToJson() => JsonSerializer.SerializeToNode<Packet>(this)!.AsObject();

    public static Packet ToPacket(string message) {
        var json = string.IsNullOrEmpty(message) ? 
            new JsonObject().AsObject() : 
            JsonNode.Parse(message)!.AsObject();
        var output = (json.ContainsKey("Type") && json.ContainsKey("Payload")) ?
            new Packet( 
                json["Type"]!.GetValue<PacketType>(),
                json["Payload"]!.Deserialize<JsonElement>()
            ) :
            throw new JsonException("Malformed Packet JSON");
        return output;
    }
}
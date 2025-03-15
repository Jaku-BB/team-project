using WebSocketSharp;
using WebSocketSharp.Server;

public class ChatService : WebSocketBehavior
{
    private readonly Dictionary<string, string> _users = new();

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine("Got message from ID (" + ID + "): " + e.Data);
        if (!_users.TryGetValue(ID, out var value))
        {
            _users.Add(ID, e.Data);
        }
        else
        {
            Sessions.Broadcast(value + ": " + e.Data);
        }
    }
}

public class Server
{
    public static void Run()
    {
        Console.WriteLine("Starting server...");
        var webSocket = new WebSocketServer("ws://localhost:2137");
        webSocket.AddWebSocketService<ChatService>("/chat");
        webSocket.Start();
        Console.ReadKey(true);
        webSocket.Stop();
    }
}
using WebSocketSharp;

public class Client
{
    public static void ClearCurrentConsoleLine()
    {
        var currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Console.SetCursorPosition(0, currentLineCursor);
    }
    
    public static void Run()
    {
        Console.Write("Your name: ");
        var name = Console.ReadLine();
        
        var isFirstMessage = true;
        
        Console.WriteLine("Great! Connecting to the server...");
        
        using var webSocket = new WebSocket("ws://localhost:2137/chat");
        webSocket.OnMessage += (_, e) => Console.WriteLine(e.Data);
        webSocket.Connect();
        
        while (true)
        {
            var message = Console.ReadLine();

            if (isFirstMessage)
            {
                isFirstMessage = false;
                webSocket.Send(name);
            }
            
            webSocket.Send(message);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
        }
    }
}
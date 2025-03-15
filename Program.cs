public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: dotnet run server|client");
            return;
        }

        switch (args[0])
        {
            case "server":
                Server.Run();
                break;
            case "client":
                Client.Run();
                break;
            default:
                Console.WriteLine("Usage: dotnet run server|client");
                break;
        }
    }
}
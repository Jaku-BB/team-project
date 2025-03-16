using TeamProject;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: dotnet run server|client");
            return;
        }

        var authentication = new Authentication();
        Console.WriteLine(authentication.SignIn("Name", "Password").Message);
        Console.WriteLine(authentication.SignUp("Name", "Password").Message);

        for (var index = 0; index < 10000; index++)
        {
            var random = new Random();
            Console.WriteLine(authentication.SignUp(random.Next(10000000).ToString(), random.Next(10000000).ToString()).Message);
        }
        // switch (args[0])
        // {
        //     case "server":
        //         Server.Run();
        //         break;
        //     case "client":
        //         Client.Run();
        //         break;
        //     default:
        //         Console.WriteLine("Usage: dotnet run server|client");
        //         break;
        // }
    }
}
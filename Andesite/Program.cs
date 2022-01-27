namespace Andesite;

public class Program 
{
    public static void Main(string[] args)
    {
        SocketServer server = new SocketServer("127.0.0.1", 25575);
        server.Start();
    }
}

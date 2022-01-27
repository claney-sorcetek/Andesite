using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace Andesite;

public class SocketServer
{
    private IPAddress _ip;
    private int _port;
    private TcpListener _server;
    private Thread? _thread;
    private bool _listen;

    public SocketServer(string ip = "127.0.0.1", int port = 25575)
    {
        _ip = IPAddress.Parse(ip);
        _port = port;
        _server = new TcpListener(_ip, _port);
    }

    public void Start()
    {
        _listen = true;
        _server.Start();
        Log.Info("Started Started");
        _thread = new Thread(new ThreadStart(Listen));
        _thread.Start();
    }

    public void Stop()
    {
        if (_thread is null)
            return;

        Log.Info("Started Stopped");
        _listen = false;
        _thread.Join();
    }

    private void Listen()
    {
        while (_listen)
        {
            Log.Info("Waiting for Connection...");
            TcpClient client = _server.AcceptTcpClient();
            Log.Info($"Connection from {client.Client.RemoteEndPoint}");
            Handle(client);
        }
        
        _server.Stop();
    }

    private void Handle (TcpClient client)
    {
        TcpClient remoteClient = new TcpClient("127.0.0.1", 25565);

        Task T1 = Task.Factory.StartNew(async () => { await DataExchange(client, remoteClient); });
        Task T2 = Task.Factory.StartNew(async () => { await DataExchange(remoteClient, client); });
    }

    private async Task DataExchange(TcpClient target, TcpClient destination)
    {
        int bytesRead = 0;
        byte[] recvbuf = new byte[8192];
        do
        {
            bytesRead = await target.GetStream().ReadAsync(recvbuf, 0, recvbuf.Length);
            await destination.GetStream().WriteAsync(recvbuf, 0, bytesRead);
        } while (bytesRead != 0);
    }
}
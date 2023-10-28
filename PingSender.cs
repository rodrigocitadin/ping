using System.Net.NetworkInformation;
using System.Text;

namespace Pinger;

public class PingService
{
    // public string? Data { get; set; }
    // public byte[]? Buffer { get; set; }
    public int Timeout { get; set; }
    public string Address { get; set; }
    public Ping Ping { get; set; }
    public PingOptions Options { get; set; }

    public PingService(string address, int timeout = 150)
    {
        Address = address;
        Timeout = timeout;
        Ping = new();
        Options = new();

        Options.DontFragment = true;
    }

    public void Send(string data)
    {
        byte[] buffer = Encoding.ASCII.GetBytes(data);

        PingReply reply = Ping.Send(Address, Timeout, buffer, Options);  

        if (reply.Status == IPStatus.Success)
        {
            Console.WriteLine("Success");
        }
        else
        {
            System.Console.WriteLine("Error");
        }
    }
}

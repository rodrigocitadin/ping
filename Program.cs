using System.Net.NetworkInformation;
using System.Text;

Ping pingSender = new();
PingOptions options = new();

options.DontFragment = true;

string data = "testing";
byte[] buffer = Encoding.ASCII.GetBytes(data);
int timeout = 150;
string address = "4.2.2.2";

PingReply reply = pingSender.Send(address, timeout, buffer, options);

if (reply.Status == IPStatus.Success)
{
    Console.WriteLine($"Response: {reply.Status.ToString()}");
    Console.WriteLine($"RoundTrip: {reply.RoundtripTime}");
    Console.WriteLine($"Time to live: {reply.Options.Ttl}");
    Console.WriteLine($"Buffer size: {reply.Buffer.Length}");
}
else
{
    Console.WriteLine("Error");
}

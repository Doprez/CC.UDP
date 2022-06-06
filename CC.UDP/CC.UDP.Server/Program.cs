using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CC.UDP.Server;

internal class Program
{
    static void Main(string[] args)
    {
        bool done = false;

        UDPReceiver receiver = new UDPReceiver("127.0.0.1", 1902);

        try
        {
            while (!done)
            {
                Console.WriteLine(receiver.UDPRecieveData());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
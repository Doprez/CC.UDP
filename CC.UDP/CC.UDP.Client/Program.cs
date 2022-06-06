using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CC.UDP;

internal class Program
{
    private const string _ip = "127.0.0.1";
	private const int port = 1902;
	
	static void Main(string[] args)
	{
        bool done = false;
        bool exceptionThrown = false;

        var sender = new UDPSender(_ip, port);

        Console.WriteLine("Enter the message you want to send: ");
        Console.WriteLine("Enter nothing to exit. ");
        while (!done)
        {
            Console.WriteLine("Enter text to send and blank line to quit. ");
            string text_to_send = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text_to_send))
            {
                done = true;
            }
            else
            {
                Console.WriteLine($"Sending the message to the IP: {_ip}");

                exceptionThrown = sender.SendMessage(text_to_send);
                
                if (exceptionThrown == false)
                {
                    Console.WriteLine("Message has been sent");
                }
                else
                {
                    exceptionThrown = false;
                    Console.WriteLine("The exception indicates the message was not sent");
                }
            }
        }
    }

}

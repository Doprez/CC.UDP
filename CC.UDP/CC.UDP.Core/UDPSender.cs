using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CC.UDP;
public class UDPSender
{

	private Socket _sendingSocket;
	private string _serverIP;
	private IPAddress _sendToAddress;
	private IPEndPoint _sendingEndPoint;

	public UDPSender(string serverIP, int port)
	{
		_sendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

		_serverIP = serverIP;
		_sendToAddress = IPAddress.Parse(serverIP);
		_sendingEndPoint = new IPEndPoint(_sendToAddress, port);
	}

	public bool SendMessage(string textToSend)
	{
		byte[] sendBuffer = Encoding.ASCII.GetBytes(textToSend);
		try 
		{ 
			_sendingSocket.SendTo(sendBuffer, _sendingEndPoint);
		}
		catch (Exception sendException)
		{
			Console.WriteLine($"Exception {sendException}");
			return false;
		}
		return true;
	}
	
}

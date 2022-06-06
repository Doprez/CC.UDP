using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CC.UDP;
public class UDPReceiver
{

	private UdpClient _listener;
	private IPEndPoint _groupEndPoint;

	private string _ip;
	private int _port;

	public UDPReceiver(string ip, int port)
	{
		_ip = ip;
		_port = port;

		_listener = new UdpClient(_port);
		_groupEndPoint = new IPEndPoint(IPAddress.Any, _port);
	}

	public string UDPRecieveData()
	{
		string data_recieved;
		byte[] recieve_byte_array;

		Console.WriteLine("Waiting for a Message to come in...");
		recieve_byte_array = _listener.Receive(ref _groupEndPoint);
		Console.WriteLine("Message received from from {0}", _groupEndPoint.ToString());
		data_recieved = Encoding.ASCII.GetString(recieve_byte_array, 0, recieve_byte_array.Length);
		return data_recieved;
	}
	
}

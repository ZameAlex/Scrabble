using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Scrabble.Logic
{
	public static class Server
	{
		public static IPEndPoint ipPoint;
		public static Socket listenSocket;
		public static bool isConnect;
		public static Socket handler;

		static Server()
		{
			ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8005);
			listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			isConnect = false;
		}
		public static void Create()
		{
			try
			{
				listenSocket.Bind(ipPoint);
				listenSocket.Listen(10);
					handler = listenSocket.Accept();
					isConnect = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void GetAll(Player p)
		{
			byte[] buffer = new byte[80];
			int length = handler.Receive(buffer);
			p.Score = BitConverter.ToInt32(buffer, 0);
			do
			{
				for (int i = 0; i < 15; i++)
					for (int j = 0; j < 15; j++)
					{
						length = handler.Receive(buffer);
						LetterContainer.Container[i, j] = Chips.GetLetter(BitConverter.ToChar(buffer, 0));
					}
			} while (handler.Available > 0);
		}

		public static void SendAll(Player p)
		{
			listenSocket.Send(BitConverter.GetBytes(p.Score));
			for (int i = 0; i < 15; i++)
			{
				for (int j = 0; j < 15; j++)
				{
					handler.Send(BitConverter.GetBytes(LetterContainer.Container[i, j].Symbol));
				}
			}
		}

		public static void SendPlayer(Player p)
		{
			var x = new byte[80];
			x = Encoding.Unicode.GetBytes(" "+p.Name);
			handler.Send(x);
		}
	}
}

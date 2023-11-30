using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using Scrabble.Graphics;

namespace Scrabble.Logic
{
	public static class Client
	{
		public static IPEndPoint ipPoint;
		public static Socket listenSocket;
		public static Socket handler;

		static Client()
		{
			ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8005);
			listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}
		public static void Connect()
		{
			try
			{
				listenSocket.Connect(ipPoint);
				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void GetAll(Player p)
		{
			byte[] buffer = new byte[80];
			int length = listenSocket.Receive(buffer);
			p.Score = BitConverter.ToInt32(buffer,0);
			do
			{
				for(int i=0;i<15;i++)
					for(int j=0;j<15;j++)
					{
						length = listenSocket.Receive(buffer);
						LetterContainer.Container[i, j] = Chips.GetLetter(BitConverter.ToChar(buffer, 0));
					}
			} while (listenSocket.Available > 0);
		}

		public static void SendAll(Player p)
		{
			listenSocket.Send(BitConverter.GetBytes(p.Score));
			for(int i=0;i<15;i++)
			{
				for(int j=0;j<15;j++)
				{
					listenSocket.Send(BitConverter.GetBytes(LetterContainer.Container[i, j].Symbol));
				}
			}
		}

		public static List<Player> GetPlayers()
		{
			var result = new List<Player>();
			var player = new byte[80];
			do
			{
				int length = listenSocket.Receive(player, 80, 0);
				string name = UnicodeEncoding.Unicode.GetString(player,0,length);
				string[] names = name.Split(new char[] { ' ' });
				foreach (var item in names)
				{
					if(!String.IsNullOrWhiteSpace(item))
					result.Add(new Player(item));
				}
			}
			while (listenSocket.Available > 0);
			return result;
		}

		public static Player GetPlayer()
		{
			Player result = null;
			var player = new byte[80];
			do
			{
				int length = listenSocket.Receive(player, 80, 0);
				result =new Player(Encoding.Unicode.GetString(player, 0, length));
			}
			while (listenSocket.Available > 0);
			return result;
		}

		public static void GetLetters(Player p)
		{
			var result = new List<LettersControl>();
			var player = new byte[80];
			int count = 0;
			p.Letters.Clear();
			do
			{
				int length = listenSocket.Receive(player, 80, 0);
				p.Letters.Add(Components.GetChip(Components.CreateNextLetterPoint(count++), BitConverter.ToChar(player, 0)));
			} while (listenSocket.Available > 0);
		}

		public static int GetLetter()
		{
			byte[] number = new byte[80];
			int length = listenSocket.Receive(number);
			return BitConverter.ToInt32(number,0);
		}

		public static Point GetLocation()
		{
			var result = new Point();
			var player = new byte[80];
			int length = listenSocket.Receive(player, 80, 0);
			result.X= BitConverter.ToInt32(player, 0);
			length = listenSocket.Receive(player, 80, 0);
			result.Y = BitConverter.ToInt32(player, 0);
			return result;
		}

		public static int GetScore()
		{
			var player = new byte[80];
			int length = listenSocket.Receive(player);
			return BitConverter.ToInt32(player,0);
		}

		public static void SendPoint(Point point)
		{
			listenSocket.Send(BitConverter.GetBytes(point.X));
			listenSocket.Send(BitConverter.GetBytes(point.Y));
		}

		public static void SendScore(int score)
		{
			listenSocket.Send(BitConverter.GetBytes(score));
		}

		public static void SendPlayer(Player p)
		{
			var res = new byte[p.Name.Length];
			for (int i = 0; i < p.Name.Length; i++)
				res[i] = (byte)p.Name[i];
			listenSocket.Send(res);
		}

		public static void SendLetters(List<Letter> letters)
		{
			foreach(var item in letters)
			{
				listenSocket.Send(BitConverter.GetBytes(item.Symbol));
			}
		}

		public static void SendLetter(int number)
		{
			listenSocket.Send(BitConverter.GetBytes(number));
		}
	}
}

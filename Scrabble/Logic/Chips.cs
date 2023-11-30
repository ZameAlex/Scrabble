using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Logic
{
	public static class Chips
	{
		public static Dictionary<char, byte> LettersValues;
		public static Dictionary<char, byte> LeftLetters;
		public static int globalLeft;
		static Random r = new Random();

		static Chips()
		{

			LettersValues = new Dictionary<char, byte>();
			LeftLetters = new Dictionary<char, byte>();
			using (StreamReader values = new StreamReader(Directory.GetCurrentDirectory()+"\\..\\..\\AppData\\Files\\Values_eng.txt"))
			{
				while(!values.EndOfStream)
				{
					string[] pair = values.ReadLine().Trim().Split(new char[1] { ' ' });
					LettersValues.Add(pair[0][0], Convert.ToByte(pair[1]));
				}
			}
			using (StreamReader count = new StreamReader(Directory.GetCurrentDirectory() + "\\..\\..\\AppData\\Files\\Count_eng.txt"))
			{
				while (!count.EndOfStream)
				{
					string[] pair = count.ReadLine().Trim().Split(new char[1] { ' ' });
					LeftLetters.Add(pair[0][0], Convert.ToByte(pair[1]));
				}
			}
			foreach (var item in LeftLetters)
				globalLeft += item.Value;
		}

		private static char RandomLetter()
		{

			bool isReturn = false;
			while(!isReturn)
			{
				int rand = r.Next(0, globalLeft);
				int x = 0;
				int add = 0;
				foreach (var item in LeftLetters)
				{
					x += LeftLetters[(char)('A' + add++)];
					if(rand<=x)
					{
						globalLeft--;
						LeftLetters[(char)('A' + add)]--;
						return (char)('A' + add);
					}
				}
			}
			return 'A';
		}

		private static Letter ReturnLetter(char letter)
		{
			int value = LettersValues[letter];
			string valueSymbols = "";
			if (value < 10)
			{
				valueSymbols += (char)('\u2080' + value);
			}
			else
			{
				valueSymbols += "\u2081\u2080";
			}
			return new Letter(letter, value, valueSymbols);
		}

		/// <summary>
		/// Return random letter
		/// </summary>
		/// <returns></returns>
		public static Letter GetLetter()
		{
			char letter = RandomLetter();
			return ReturnLetter(letter);
			
		}
		/// <summary>
		/// Returns letter
		/// </summary>
		/// <param name="letter">Letter, which you want to get</param>
		/// <returns></returns>
		public static Letter GetLetter(char letter)
		{
			return ReturnLetter(letter);
		}

	}
}

using Scrabble.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Logic
{
	public static class Saver
	{
		private static string fileName;
		public static bool wasFile=false;
		public static void SaveFile(string file)
		{
			fileName = file;
			wasFile = true;
		}

		public static void Save(List<Player> players)
		{
			var currentDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\", @"AppData\SaveGame\").ToString();

			using (StreamWriter writer = new StreamWriter(currentDirectory + fileName+".txt",false))
			{
				for (int i= 0;i< 15;i++)
				{
					for(int j=0;j<15;j++)
					{
						if (LetterContainer.Container[i, j] == null)
							writer.Write(0);
						else
							writer.Write(LetterContainer.Container[i, j].Symbol);
					}
					writer.WriteLine();
				}

				foreach(var item in players)
				{
					writer.WriteLine(item.Name);
					writer.WriteLine(item.Score);
					foreach (var letter in item.Letters)
						writer.Write(letter.Letter.Symbol + " ");
					writer.WriteLine();
				}
			}
		}

		public static List<Player> Load(string filePath)
		{
			var result = new List<Player>();
			StreamReader sr = new StreamReader(filePath);
			for(int i=0;i<15;i++)
			{
				string str = sr.ReadLine();
				for (int j = 0; j < 15; j++)
				{
					if(str[j]=='0')
						LetterContainer.Container[i,j] = null;
					else
						LetterContainer.Container[i, j] = Chips.GetLetter(str[j]);
				}
			}
			while(!sr.EndOfStream)
			{
				Player tmp = new Player(sr.ReadLine());
				tmp.Score = Convert.ToInt32(sr.ReadLine());
				string[] str = sr.ReadLine().Split(new char[] { ' ' });
				for (int i = 0; i < str.GetLength(0); i++)
					tmp.Letters.Add(Components.GetChip(Components.CreateNextLetterPoint(i), str[i][0]));
				return result;			
			}
			return null;
		}
	}
}

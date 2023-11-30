using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Logic
{
	public static class Counter
	{
		private static int[,] Mults;
		
		static Counter()
		{
			Mults = new int[15, 15];
			using (StreamReader values = new StreamReader(Directory.GetCurrentDirectory() + "\\..\\..\\AppData\\Files\\Mults.txt"))
			{
				string temp;
				int i = 0;
				while (!values.EndOfStream)
				{
					int j = 0;
					temp = values.ReadLine();
					foreach (var item in temp)
					{
						Mults[i, j++] = Convert.ToInt32(item)-'0';
					}
					i++;
				}
			}
		}
		
		public static int Count(List<Word> words)
		{

			int result=0;
			foreach (var item in words)
			{
				int tempres = 0;
				int mult = 1;
				for (int i = item.iStart; i <= item.iEnd; i++)
				{
					for (int j = item.jStart; j < item.jEnd; j++)
					{
						if (Mults[i, j] == 0)
						{
							tempres += LetterContainer.Container[i, j].Value;
						}
						if (Mults[i, j] == 1)
						{
							tempres += LetterContainer.Container[i, j].Value * 2;
						}
						if (Mults[i, j] == 2)
						{
							tempres += LetterContainer.Container[i, j].Value * 3;
						}
						if (Mults[i, j] == 3)
						{
							tempres += LetterContainer.Container[i, j].Value;
							mult *= 2;
						}
						if (Mults[i, j] == 4)
						{
							tempres += LetterContainer.Container[i, j].Value;
							mult *= 3;
						}
					}
				}
				result += tempres * mult;
			}
			foreach (var item in words)
			{
				int tempres = 0;
				int mult = 1;
				for (int j = item.jStart; j <= item.jEnd; j++)
				{
					for (int i = item.iStart; i < item.iEnd; i++)
					{
						if (Mults[i, j] == 0)
						{
							tempres += LetterContainer.Container[i, j].Value;
						}
						if (Mults[i, j] == 1)
						{
							tempres += LetterContainer.Container[i, j].Value * 2;
						}
						if (Mults[i, j] == 2)
						{
							tempres += LetterContainer.Container[i, j].Value * 3;
						}
						if (Mults[i, j] == 3)
						{
							tempres += LetterContainer.Container[i, j].Value;
							mult *= 2;
						}
						if (Mults[i, j] == 4)
						{
							tempres += LetterContainer.Container[i, j].Value;
							mult *= 3;
						}
					}
				}
				result += tempres * mult;
			}
			return result;
		} 
	}
}

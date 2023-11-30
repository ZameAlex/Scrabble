using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Logic
{
	public static class Checker
	{
		private static List<string> Dictionary;
		private static List<string> UsedWords;

		static Checker()
		{
			Dictionary = new List<string>();
			UsedWords = new List<string>();
			using (StreamReader dictionary = new StreamReader(Directory.GetCurrentDirectory() + "\\..\\..\\AppData\\Files\\Dictionary.txt"))
			{
				while (!dictionary.EndOfStream)
				{
					Dictionary.Add(dictionary.ReadLine());
				}
			}
		}

		public static bool CheckIsWordRight(Word word)
		{
			foreach (var item in Dictionary)
				if (word.WordString.Equals(item, StringComparison.OrdinalIgnoreCase))
					return true;
			return false;
		}

		public static bool CheckIsWordUsed(Word word)
		{
			foreach (var item in UsedWords)
				if (word.WordString.Equals(item, StringComparison.OrdinalIgnoreCase))
					return true;
			return false;
		}

		public static void AddWordsToUsed(List<Word> words)
		{
			foreach (var item in words)
				UsedWords.Add(item.WordString);
		}
		public static void AddWordToDictionary(Word word)
		{
			Dictionary.Add(word.WordString);
			UsedWords.Add(word.WordString);
		}
	}
}

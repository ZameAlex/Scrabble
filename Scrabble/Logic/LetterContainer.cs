using Scrabble.Logic.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Scrabble.Logic
{
	public static class LetterContainer
	{
		
		
		public static Letter[,] Container;
		static Letter[] newLetters;
		static bool wasFirstWord;
		public static int tempScore;

		static LetterContainer()
		{
			tempScore = 0;
			Container = new Letter[15, 15];
			for (int i = 0; i < Container.GetLength(0); i++)
				for (int j = 0; j < Container.GetLength(1); j++)
				{
					Container[i, j] = null;
				}
			wasFirstWord = false;
		}

		public static void Initialize()
		{

		}

		public static void NewLetters(List<Letter> letters)
		{
			tempScore = 0;
			newLetters = letters.ToArray();
			foreach(var item in newLetters)
			{
				Container[item.Line, item.Column] = item;
			}
		}

		public static Exception Check()
		{
			try
			{
				if (!wasFirstWord)
					CheckFirstword();
				NewWordsCheck();
			}
			catch(ApplicationException e)
			{
				foreach (var item in newLetters)
				{
					Container[item.Line, item.Column] = null;
					item.CheckedHorizontal = false;
					item.CheckedVertival = false;
				}
				newLetters = null;
				return e;
			}
			return null;
		}

		private static Word GetHorizontalWord(Letter l)
		{
			int i = l.Line;
			int j = l.Column;
			Letter temp=l;
			while(j>=0 && Container[i,j]!=null)
			{
				temp = Container[i, j];
				j--;
			}
			int iStart = temp.Line;
			int jStart = temp.Column;
			i = temp.Line;
			j = temp.Column;
			StringBuilder word = new StringBuilder();
			while(Container[i,j]!=null && j<=14)
			{
				Container[i, j].CheckedHorizontal = true;
				word.Append(Container[i, j].Symbol);
				j++;
			}
			return new Word(word.ToString(),iStart,jStart,iStart,j);
		}

		private static Word GetVerticalWord(Letter l)
		{
			int i = l.Line;
			int j = l.Column;
			Letter temp = l;
			while (i >= 0 && Container[i, j] != null)
			{
				temp = Container[i, j];
				i--;
			}
			int iStart = temp.Line;
			int jStart = temp.Column;
			i = temp.Line;
			j = temp.Column;
			StringBuilder word = new StringBuilder();
			while (Container[i, j] != null && i <= 14)
			{
				Container[i, j].CheckedVertival = true;
				word.Append(Container[i, j].Symbol);
				i++;
			}
			return new Word(word.ToString(), iStart, jStart, i, jStart);
		}

		private static bool CheckHorizontalWord(Letter l)
		{
			if (l.CheckedHorizontal)
				return false;
			if (l.Column > 0 && Container[l.Line, l.Column - 1] != null)
				return true;
			else
				if (l.Column < 14 && Container[l.Line, l.Column + 1] != null)
				return true;
			return false;
		}
		private static bool CheckVerticallWord(Letter l)
		{
			if (l.CheckedVertival)
				return false;
			if (l.Line > 0 && Container[l.Line-1, l.Column] != null)
				return true;
			else
				if (l.Line < 14 && Container[l.Line+1, l.Column] != null)
				return true;
			return false;
		}

		private static void NewWordsCheck()
		{
			List<Word> temp = new List<Word>();
			foreach(var item in newLetters)
			{
				if (CheckHorizontalWord(item))
					temp.Add(GetHorizontalWord(item));
				if (CheckVerticallWord(item))
					temp.Add(GetVerticalWord(item));
			}
			if (temp.Count == 0)
				throw new NoNewWords();
			foreach(var item in temp)
			{
				if (IsCentre())
					goto NewWord;
				bool flag = true;
				for (int i = item.iStart; i <= item.jEnd; i++)
					for (int j = item.jStart; j < item.jEnd; j++)
					{
						foreach (var letter in newLetters)
							if (Container[i, j] != letter)
							{
								flag = false;
								break;
							}
						if (flag)
							throw new NewWordDisconnectWithOldException(item);
					}
				NewWord:
				if (Checker.CheckIsWordUsed(item))
					throw new WordWasUsedException(item);
				if (!Checker.CheckIsWordRight(item))
					throw new WordNotFoundException(item);
			}
			tempScore+=Counter.Count(temp);
			Checker.AddWordsToUsed(temp);
		}

		private static void CheckFirstword()
		{
			if (IsCentre())
				return;
			throw new FirstWordException();
		}

		private static bool IsCentre()
		{
			foreach (var item in newLetters)
				if (item.Line == 7 && item.Column == 7)
				{
					wasFirstWord = true;
					return true;
				}
			return false;
		}
	}
}

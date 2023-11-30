using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
	public enum CheckStates
	{
		NoSuchWord,
		CrashAnotherWords,
		Correct
	}
    public class Logic
    {
		List<string> _dictionary;
		List<string> _usedWords;
		char[,] _field;
		StringBuilder _newWord;
		public Logic(int lines, int columns,string dictionaryPath="dictionary.txt")
		{
			_usedWords = new List<string>();
			_dictionary = new List<string>();
			_newWord = new StringBuilder();
			_field = new char[lines, columns];
			for (int i = 0; i < lines; i++)
				for (int j = 0; j < columns; j++)
					_field[i, j] = '\0';
			using (StreamReader dictionary = new StreamReader(dictionaryPath))
			{
				while (!dictionary.EndOfStream)
					_dictionary.Add(dictionary.ReadLine());
			}
		}

		public bool AddLetter(int x,int y,char letter)
		{
			if (_field[y, x] != '\0')
				return false;
			_field[y, x] = letter;
			_newWord.Append(letter);
			return true;
		}

		private bool CheckWord()
		{
			string newWord = _newWord.ToString();
			foreach (var item in _dictionary)
				if (item == newWord)
					return true;
			return false;
		}
		private int[,] CheckState()
		{

		}

		public CheckStates Check()
		{
			if (!CheckWord())
				return CheckStates.NoSuchWord;
			return CheckStates.Correct;
		}

    }
}

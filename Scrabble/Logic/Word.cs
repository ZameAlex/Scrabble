using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Logic
{
	public class Word
	{
		public string WordString { get; set; }
		public int iStart { get; set; }
		public int jStart { get; set; }
		public int iEnd { get; set; }
		public int jEnd { get; set; }

		public Word(string word,int _iStart,int _jStart,int _iEnd, int _jEnd)
		{
			WordString = word;
			iStart = _iStart;
			jStart = _jStart;
			iEnd = _iEnd;
			jEnd = _jEnd;
		}
	}
}

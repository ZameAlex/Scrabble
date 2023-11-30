using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Logic.Errors
{
	public class WordWasUsedException : ApplicationException
	{
		public Word UsedWord { get; private set; }
		public WordWasUsedException(Word usedWord)
		{
			UsedWord = usedWord;
		}
	}
}

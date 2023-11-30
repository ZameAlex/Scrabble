using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Logic.Errors
{
	public class WordNotFoundException : ApplicationException
	{
		public Word NotFoundWord { get; private set; }
		public WordNotFoundException(Word notFound)
		{
			NotFoundWord = notFound;
		}
	}
}

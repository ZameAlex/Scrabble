using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Logic.Errors
{
	public class NewWordDisconnectWithOldException : ApplicationException
	{
		public Word DisconnectWord { get; private set; }
		public NewWordDisconnectWithOldException(Word disconnectWord)
		{
			DisconnectWord = disconnectWord;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble.Logic
{
	public class Letter
	{

		/// <summary>
		/// Line position in array and in field
		/// </summary>
		public int Line { get; set; }
		/// <summary>
		/// Column position in array and in field
		/// </summary>
		public int Column { get; set; }
		/// <summary>
		/// Symbol to represent
		/// </summary>
		public char Symbol { get; protected set; }
		/// <summary>
		/// Value of this character
		/// </summary>
		public int Value { get; protected set; }
		/// <summary>
		/// Symbols in Unicode to represent underline value
		/// </summary>
		public string ValueSymbol { get; protected set; }
		/// <summary>
		/// Is this symbol checked in horizontal words
		/// </summary>
		public bool CheckedHorizontal { get; set; }
		/// <summary>
		/// Is this symbol checked in vertical words
		/// </summary>
		public bool  CheckedVertival { get; set; }

		/// <summary>
		/// Base constructor
		/// </summary>
		/// <param name="symbol"> Letter character</param>
		/// <param name="value">Letter value</param>
		/// <param name="valueSymbol">Symbols to represent value</param>
		public Letter(char symbol, int value, string valueSymbol)
		{
			Symbol = symbol;
			Value = value;
			ValueSymbol = valueSymbol;
			Line = -1;
			Column = -1;
			CheckedHorizontal = false;
			CheckedVertival = false;
		}

	}
}

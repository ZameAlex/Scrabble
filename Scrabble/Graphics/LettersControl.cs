using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble.Logic
{

	public class LettersControl:Label
	{
		public Letter Letter { get; protected set; }
		public Point StartPosition { get; set; }
		public LettersControl(Letter letter,Size size,Point startPosition)
		{
			Letter = letter;
			Size = size;
			MinimumSize = size;
			Text += Letter.Symbol;
			Text += Letter.ValueSymbol;
			BackColor = Color.Goldenrod;
			BorderStyle = BorderStyle.Fixed3D;
			Font = new Font("Script MT", 13f);
			FontHeight = 18;
			StartPosition = startPosition;
			Location = startPosition;
		}
		public override string ToString()
		{
			return String.Format("Letter: {4},  X:{0},Y:{1}; StartX:{2},StartY:{3}", Location.X, Location.Y, StartPosition.X, StartPosition.Y,Letter.Symbol);
		}
	}
}

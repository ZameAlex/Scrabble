using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Scrabble.Logic;

namespace Scrabble.Graphics
{
	public class Components
	{
		public static readonly Size letterSize;
		public static readonly Size windowSize;
		public static readonly Size fieldSize;
		public static readonly Point fieldPosition;
		public static int parts;

		static Components()
		{
			parts = 15;
			windowSize = Application.OpenForms["GameForm"].Size;
			int size = (windowSize.Width * 2) / 3 < (windowSize.Height * 5) / 6 ?
				(windowSize.Width / 3) * 2 : (windowSize.Height / 6) * 5;
			letterSize = new Size((size - parts - 1) / parts, (size - parts - 1) / parts);
			fieldPosition = new Point((windowSize.Width - size) / 2,(windowSize.Height-size)/3);
			fieldSize = new Size(size, windowSize.Height - fieldPosition.Y);
		}

		/// <summary>
		/// Gets LettersControl with the position
		/// </summary>
		/// <param name="position">Position on the form</param>
		/// <returns></returns>
		public static LettersControl GetChip(Point position)
		{
			return new LettersControl(Chips.GetLetter(), letterSize, position);
		}

		/// <summary>
		/// Gets LettersControl with the position and the letter
		/// </summary>
		/// <param name="position">Position on the form</param>
		/// <param name="letter">Letter to represent</param>
		/// <returns></returns>
		public static LettersControl GetChip(Point position,char letter)
		{
			return new LettersControl(Chips.GetLetter(letter), letterSize, position);
		}

		/// <summary>
		/// Creates point for next LetterControl position
		/// </summary>
		/// <param name="number">Number of control</param>
		/// <returns></returns>
		public static Point CreateNextLetterPoint(int number)
		{
			return new Point(number * fieldSize.Width / 8 + fieldSize.Width / 16, fieldSize.Height - 20-letterSize.Height);
		}
		/// <summary>
		/// Creates point for next Label position
		/// </summary>
		/// <param name="line">In which line Label is located</param>
		/// <param name="column">In which column Label is located</param>
		/// <returns></returns>
		private static Point CreateNewLabelPoint(int line,int column)
		{
			return new Point(letterSize.Width * column + column, letterSize.Height * line + line);
		}
		/// <summary>
		/// Get new Label for field
		/// </summary>
		/// <param name="line">In which line Label is located</param>
		/// <param name="column">In which column Label is located</param>
		/// <returns></returns>
		public static Label GetLabel(int line, int column)
		{
			var result = new Label();
			result.Visible = true;
			result.Location= CreateNewLabelPoint(line, column);
			result.Size = letterSize;
			result.MinimumSize = letterSize;
			result.BorderStyle = BorderStyle.Fixed3D;
			result.Enabled = false;
			return result;
		}

		public static int ReturnColumn(Point position)
		{
			return position.X / (letterSize.Width + 1);
		}

		public static int ReturnLine(Point position)
		{
			return position.Y / (letterSize.Height + 1);
		}

		public static bool Check(int number)
		{
			if (number < 0 || number > 14)
				return false;
			return true;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrabble.Graphics;
using System.Drawing;

namespace Scrabble.Logic
{
	public class Player
	{
		public string Name { get; set; }
		public int Score { get; set; }
		public List<LettersControl> Letters { get; protected set; }

		public Player(string name)
		{
			Letters = new List<LettersControl>();
			Name = name;
			Score = 0;
		}

	}
}

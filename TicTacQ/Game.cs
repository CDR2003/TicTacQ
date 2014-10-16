using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public enum Tile
	{
		Empty,
		Cross,
		Circle
	}

	public class Game
	{
		public Grid Size { get; set; }

		public Game()
		{
			this.Size = new Grid( 3, 3 );
		}
	}
}

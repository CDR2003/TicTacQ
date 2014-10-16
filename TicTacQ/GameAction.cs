using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public struct GameAction
	{
		public Grid Grid;

		public GameAction( Grid grid )
		{
			this.Grid = grid;
		}
	}
}

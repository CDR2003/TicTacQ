using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public class GameState
	{
		public GameBoard Board { get; private set; }

		private Dictionary<Grid, float> _actionValues;

		public GameState( GameBoard board )
		{
			this.Board = board;
			_actionValues = new Dictionary<Grid, float>();

			var availableActions = this.AvailableActions;
			foreach( var action in availableActions )
			{
				_actionValues.Add( action, 0.0f );
			}
		}

		public List<Grid> AvailableActions
		{
			get
			{
				var actions = new List<Grid>();

				var size = this.Board.Size;
				for( int x = 0; x < size.X; x++ )
				{
					for( int y = 0; y < size.Y; y++ )
					{
						if( this.Board[x, y] == Tile.Empty )
						{
							actions.Add( new Grid( x, y ) );
						}
					}
				}

				return actions;
			}
		}

		public float GetActionValue( Grid grid )
		{
			return _actionValues[grid];
		}

		public void SetActionValue( Grid grid, float value )
		{
			_actionValues[grid] = value;
		}
	}
}

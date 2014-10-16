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

		private Dictionary<Grid, int> _actionValues;

		public GameState( GameBoard board )
		{
			this.Board = board.Clone();

			this.CalculateAvailableActions();

			_actionValues = new Dictionary<Grid, int>();
			foreach( var action in this.AvailableActions )
			{
				_actionValues.Add( action, 0 );
			}
		}

		public List<Grid> AvailableActions { get; private set; }

		public Grid BestAction
		{
			get
			{
				var bestActions = _actionValues.MaxElements( ( pair ) => pair.Value );
				return bestActions.RandomOne().Key;
			}
		}

		public Grid RandomAction
		{
			get
			{
				return _actionValues.RandomOne().Key;
			}
		}

		public Grid UntrainedAction
		{
			get
			{
				var untrained = new List<Grid>();
				foreach( var item in _actionValues )
				{
					if( item.Value == 0 )
					{
						untrained.Add( item.Key );
					}
				}

				if( untrained.Count == 0 )
				{
					return this.RandomAction;
				}
				else
				{
					return untrained.RandomOne();
				}
			}
		}

		public int MaxValue
		{
			get
			{
				return _actionValues.Max( ( pair ) => pair.Value );
			}
		}

		public int GetActionValue( Grid grid )
		{
			return _actionValues[grid];
		}

		public void SetActionValue( Grid grid, int value )
		{
			_actionValues[grid] = value;
		}

		private void CalculateAvailableActions()
		{
			this.AvailableActions = new List<Grid>();

			var size = this.Board.Size;
			for( int x = 0; x < size.X; x++ )
			{
				for( int y = 0; y < size.Y; y++ )
				{
					if( this.Board[x, y] == null )
					{
						this.AvailableActions.Add( new Grid( x, y ) );
					}
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public class Game
	{
		public static Grid DefaultSize = new Grid( 3, 3 );

		public GameBoard Board;

		public Game()
		{
			this.Board = new GameBoard( DefaultSize );
		}

		public bool Play( bool tile, Grid position )
		{
			if( this.Board[position] != null )
			{
				throw new Exception();
			}

			this.Board[position] = tile;

			return this.CheckWinner( position );
		}

		private bool CheckWinner( Grid position )
		{
			var tile = this.Board[position];

			// Check horizontal tiles
			var won = true;
			for( int i = 0; i < this.Board.Size.X; i++ )
			{
				if( this.Board[i, position.Y] != tile )
				{
					won = false;
					break;
				}
			}

			if( won )
			{
				return true;
			}

			// Check horizontal tiles
			won = true;
			for( int i = 0; i < this.Board.Size.Y; i++ )
			{
				if( this.Board[position.X, i] != tile )
				{
					won = false;
					break;
				}
			}

			if( won )
			{
				return true;
			}

			// Check diagonal tiles
			if( position.X == position.Y )
			{
				won = true;
				for( int i = 0; i < this.Board.Size.X; i++ )
				{
					if( this.Board[i, i] != tile )
					{
						won = false;
						break;
					}
				}

				if( won )
				{
					return true;
				}
			}

			if( position.X + position.Y == this.Board.Size.X - 1 )
			{
				won = true;
				for( int i = 0; i < this.Board.Size.X; i++ )
				{
					if( this.Board[i, this.Board.Size.X - i - 1] != tile )
					{
						won = false;
						break;
					}
				}

				if( won )
				{
					return true;
				}
			}

			return false;
		}
	}
}

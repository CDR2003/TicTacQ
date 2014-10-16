using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public class GameBoard
	{
		private bool?[,] _tiles;

		public Grid Size
		{
			get
			{
				return new Grid( _tiles.GetLength( 0 ), _tiles.GetLength( 1 ) );
			}
		}

		public GameBoard( Grid size )
		{
			_tiles = new bool?[size.X, size.Y];
			for( int i = 0; i < _tiles.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < _tiles.GetLength( 1 ); j++ )
				{
					_tiles[i, j] = null;
				}
			}
		}

		public GameBoard Revert()
		{
			var board = new GameBoard( this.Size );
			for( int i = 0; i < this.Size.X; i++ )
			{
				for( int j = 0; j < this.Size.Y; j++ )
				{
					if( this[i, j] == null )
					{
						board[i, j] = null;
					}
					else
					{
						board[i, j] = !this[i, j];
					}
				}
			}
			return board;
		}

		public bool? this[int x, int y]
		{
			get
			{
				return _tiles[x, y];
			}
			set
			{
				_tiles[x, y] = value;
			}
		}

		public bool? this[Grid grid]
		{
			get
			{
				return this[grid.X, grid.Y];
			}
			set
			{
				this[grid.X, grid.Y] = value;
			}
		}

		public static bool operator==( GameBoard left, GameBoard right )
		{
			if( object.ReferenceEquals( left, right ) )
			{
				return true;
			}

			if( (object)left == null || (object)right == null )
			{
				return false;
			}

			if( left.Size != right.Size )
			{
				return false;
			}

			for( int i = 0; i < left.Size.X; i++ )
			{
				for( int j = 0; j < left.Size.Y; j++ )
				{
					if( left[i, j] != right[i, j] )
					{
						return false;
					}
				}
			}

			return true;
		}

		public static bool operator!=( GameBoard left, GameBoard right )
		{
			return !( left == right );
		}

		public override bool Equals( object obj )
		{
			if( obj == null || obj.GetType() != typeof( GameBoard ) )
			{
				return false;
			}

			return this == (GameBoard)obj;
		}

		public override int GetHashCode()
		{
			return _tiles.GetHashCode();
		}

		public GameBoard Clone()
		{
			var board = new GameBoard( this.Size );
			for( int i = 0; i < this.Size.X; i++ )
			{
				for( int j = 0; j < this.Size.Y; j++ )
				{
					board[i, j] = this[i, j];
				}
			}
			return board;
		}
	}
}

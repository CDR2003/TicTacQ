using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public class GameBoard
	{
		private Tile[,] _tiles;

		public Grid Size
		{
			get
			{
				return new Grid( _tiles.GetLength( 0 ), _tiles.GetLength( 1 ) );
			}
		}

		public GameBoard( Grid size )
		{
			_tiles = new Tile[size.X, size.Y];
			for( int i = 0; i < _tiles.GetLength( 0 ); i++ )
			{
				for( int j = 0; j < _tiles.GetLength( 1 ); j++ )
				{
					_tiles[i, j] = Tile.Empty;
				}
			}
		}

		public Tile this[int x, int y]
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

		public Tile this[Grid grid]
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
	}
}

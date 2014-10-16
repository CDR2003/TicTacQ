using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public struct Grid
	{
		public int X;

		public int Y;

		public Grid( int x, int y )
		{
			this.X = x;
			this.Y = y;
		}

		public static bool operator==( Grid left, Grid right )
		{
			return left.X == right.X && left.Y == right.Y;
		}

		public static bool operator!=( Grid left, Grid right )
		{
			return !( left == right );
		}

		public override bool Equals( object obj )
		{
			if( obj.GetType() != typeof( Grid ) )
			{
				return false;
			}

			var that = (Grid)obj;
			return this == that;
		}

		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode();
		}
	}
}

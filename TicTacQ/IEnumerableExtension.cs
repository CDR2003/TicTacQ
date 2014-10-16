using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public static class IEnumerableExtension
	{
		public static List<T> MaxElements<T, TValue>( this IEnumerable<T> list, Func<T, TValue> maxFunc ) where TValue : IComparable
		{
			var maxElements = new List<T>();
			maxElements.Add( list.First() );

			var maxValue = maxFunc( list.First() );
			foreach( var item in list )
			{
				var currentValue = maxFunc( item );
				if( currentValue.CompareTo( maxValue ) == 0 )
				{
					maxElements.Add( item );
				}
				else if( currentValue.CompareTo( maxValue ) > 0 )
				{
					maxElements.Clear();
					maxElements.Add( item );
					maxValue = currentValue;
				}
			}

			return maxElements;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public static class IListExtension
	{
		private static Random _random = new Random();

		public static T RandomOne<T>( this ICollection<T> collection )
		{
			if( collection.Count == 0 )
			{
				throw new Exception();
			}

			var index = _random.Next( collection.Count );
			if( collection is IList<T> )
			{
				var list = collection as IList<T>;
				return list[index];
			}
			else
			{
				var currentIndex = 0;
				foreach( var item in collection )
				{
					if( currentIndex == index )
					{
						return item;
					}
					currentIndex++;
				}
			}

			return default( T );
		}
	}
}

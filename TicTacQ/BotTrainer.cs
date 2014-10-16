using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public class BotTrainer
	{
		public const int IterationCount = 30000;

		public Bot Bot { get; private set; }

		public BotTrainer()
		{
			this.Bot = new Bot();
		}

		public void Train()
		{
			for( int i = 0; i < IterationCount; i++ )
			{
				if( i % ( IterationCount / 100 ) == 0 )
				{
					Debug.Write( i * 100 / IterationCount );
					Debug.WriteLine( "%" );
				}
				this.TrainOnce();
			}
		}

		private void TrainOnce()
		{
			var game = new Game();

			var ended = false;
			do
			{
				Grid? action = null;
				ended = this.Bot.Play( game, out action );
				game.Board = game.Board.Revert();
			} while( ended == false );
		}
	}
}

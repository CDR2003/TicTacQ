using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public class Bot
	{
		public const float FinalReward = 100.0f;

		public const float LearningRate = 0.8f;

		private HashSet<GameState> _states;

		public Bot()
		{
			_states = new HashSet<GameState>();
		}
	}
}

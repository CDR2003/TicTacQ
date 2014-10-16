using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacQ
{
	public class Bot
	{
		public const int WinReward = 100;

		public const int LoseReward = -100;

		public const float LearningRate = 0.9f;

		private HashSet<GameState> _states;

		public Bot()
		{
			_states = new HashSet<GameState>();
		}

		public bool Play( Game game, out Grid? action, bool isTraining = true )
		{
			var oldBoard = game.Board.Clone();
			var currentState = this.FindState( game.Board );

			if( currentState.AvailableActions.Count == 0 )
			{
				action = null;
				return true;
			}

			action = isTraining ? currentState.UntrainedAction : currentState.BestAction;
			var won = game.Play( true, action.Value );
			var reward = won ? WinReward : 0;

			var nextBoard = game.Board.Revert();
			var nextState = this.FindState( nextBoard );
			var nextMaxValue = nextState.AvailableActions.Count != 0 ? nextState.MaxValue : 0;
			currentState.SetActionValue( action.Value, (int)( reward + LearningRate * nextMaxValue ) );

			if( won )
			{
				var loseBoard = oldBoard.Revert();
				var loseState = this.FindState( loseBoard );
				foreach( var loseAction in loseState.AvailableActions )
				{
					loseState.SetActionValue( loseAction, (int)LoseReward );
				}
			}

			return won;
		}

		public GameState FindState( GameBoard gameBoard )
		{
			foreach( var state in _states )
			{
				if( state.Board == gameBoard )
				{
					return state;
				}
			}

			var newState = new GameState( gameBoard.Clone() );
			_states.Add( newState );
			return newState;
		}
	}
}

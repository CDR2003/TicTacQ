using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacQ
{
	public partial class Form1 : Form
	{
		private BotTrainer _trainer;

		private Game _game;

		private Button[,] _buttons;

		private GameBoard _lastBoard;

		private Grid _lastAction;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			_trainer = new BotTrainer();
			_trainer.Train();

			_game = new Game();
			var size = _game.Board.Size;

			_buttons = new Button[size.X, size.Y];
			for( int i = 0; i < size.X; i++ )
			{
				for( int j = 0; j < size.Y; j++ )
				{
					var button = new Button();
					button.Location = new Point( 20 + i * 120, 20 + j * 120 );
					button.Size = new Size( 100, 100 );
					button.Font = new Font( "Arial", 30 );
					button.BackColor = Color.White;
					button.ForeColor = Color.Black;
					button.Tag = new Grid( i, j );
					button.Click += button_Click;
					this.Controls.Add( button );
					_buttons[i, j] = button;
				}
			}
		}

		void button_Click( object sender, EventArgs e )
		{
			var button = sender as Button;
			var grid = (Grid)button.Tag;
			if( _game.Board[grid] != null )
			{
				return;
			}

			button.Text = "X";

			if( _game.Play( false, grid ) )
			{
				var lastState = _trainer.Bot.FindState( _lastBoard );
				lastState.SetActionValue( _lastAction, Bot.LoseReward );

				MessageBox.Show( "You won!" );
				this.RestartGame();
				return;
			}

			var size = _game.Board.Size;
			for( int i = 0; i < size.X; i++ )
			{
				for( int j = 0; j < size.Y; j++ )
				{
					_buttons[i, j].BackColor = Color.White;
				}
			}

			var state = _trainer.Bot.FindState( _game.Board );
			foreach( var availableAction in state.AvailableActions )
			{
				var value = state.GetActionValue( availableAction );
				var color = Color.White;
				if( value > 0 )
				{
					var colorValue = 255 - 255 * value / Bot.WinReward;
					color = Color.FromArgb( colorValue, 255, colorValue );
				}
				else if( value < 0 )
				{
					var colorValue = 255 - 255 * value / Bot.LoseReward;
					color = Color.FromArgb( 255, colorValue, colorValue );
				}

				var currentButton = _buttons[availableAction.X, availableAction.Y];
				currentButton.BackColor = color;
			}

			_lastBoard = _game.Board.Clone();
			Grid? action = null;
			var won = _trainer.Bot.Play( _game, out action, false );
			if( action == null )
			{
				MessageBox.Show( "Draw!" );
				this.RestartGame();
				return;
			}

			_buttons[action.Value.X, action.Value.Y].Text = "O";
			_lastAction = action.Value;

			if( won )
			{
				MessageBox.Show( "Computer won!" );
				this.RestartGame();
				return;
			}
		}

		private void RestartGame()
		{
			_game = new Game();
			var size = _game.Board.Size;

			for( int i = 0; i < size.X; i++ )
			{
				for( int j = 0; j < size.Y; j++ )
				{
					_buttons[i, j].Text = "";
					_buttons[i, j].BackColor = Color.White;
				}
			}
		}
	}
}

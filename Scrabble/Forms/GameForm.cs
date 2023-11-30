using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scrabble.Logic;
using System.IO;
using System.Reflection;
using Scrabble.Forms;
using Scrabble.Graphics;
using Scrabble.Logic.Errors;
using System.Net;
using System.Net.Sockets;
using System.Media;

namespace Scrabble
{

	
	public partial class GameForm : Form
	{
		bool isGame;
		const int playerChipsCount = 7;
		private Label[,] GameField;

		private LettersControl DownedLetter;
		private Label TempLabel;
		private Label LastLabel;

		private List<Player> Players;
		private Player TempPlayer;
		private int parts = 15;
		int count;
		List<Label> PlayerScore;
		List<LettersControl> FieldLetters;
		Types gameType;

		public GameForm(List<Player> players, Types type)
		{
			gameType = type;
			FieldLetters = new List<LettersControl>();
			InitializeComponent();
			count = -1;
			PlayerScore = new List<Label>();
			Players = players;
			TempPlayer = Players[0];
			label1.Location = new Point(Field.Location.X + Field.Width / 2, label1.Location.Y);
			label1.BackColor = Color.Transparent;
			label1.Text = "Player: "+TempPlayer.Name;
			Legend.BackColor = Color.Transparent;
			Field.BackColor = Color.Transparent;
			PropertyInfo prp = Field.GetType().GetProperty("DoubleBuffered",
				BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
			prp.SetValue(Field, true);
			this.FormBorderStyle = FormBorderStyle.None;
			Field.BorderStyle = BorderStyle.Fixed3D;
		    GameField = new Label[parts, parts];
			DownedLetter = null;
		}


		private void Socket()
		{
			if (gameType == Types.HotSeat || gameType == Types.Load)
				return;
			if (gameType == Types.Client)
			{
				Field.Enabled = false;
			}

		}


		#region LetterEventsHandlers
		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			SystemSounds.Question.Play();
			if (DownedLetter == null)
				return;
			if (TempLabel != null)
			{
				DownedLetter.Letter.Line = Components.ReturnLine(TempLabel.Location);
				DownedLetter.Letter.Column = Components.ReturnColumn(TempLabel.Location);
				DownedLetter.Location = TempLabel.Location;

			}
			else
			{
				DownedLetter.Location = DownedLetter.StartPosition;
				DownedLetter.Letter.Line = -1;
				DownedLetter.Letter.Column = -1;
			}
			DownedLetter = null;
			TempLabel = null;
		}

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			DownedLetter = sender as LettersControl;
			SystemSounds.Asterisk.Play();
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			if(DownedLetter!=null)
			{
				DownedLetter.BringToFront();
				DownedLetter.Location = Field.PointToClient(MousePosition);
				int[] coord = FindLabel(new Point(MousePosition.X - Field.Location.X, MousePosition.Y - Field.Location.Y));
				if (Components.Check(coord[0]) && Components.Check(coord[1]))
					TempLabel = GameField[coord[0], coord[1]];
				else
					TempLabel = null;
				if(LastLabel!=TempLabel)
				{
					ChangeColor(LastLabel);
					LastLabel = TempLabel;
					ChangeColor(TempLabel);
				}
			}
		}
		#endregion LetterEventsHandlers

		private void panel1_Resize(object sender, EventArgs e)
		{
			Field.Left = Legend.Width + Legend.Left + 10;
		}


		/// <summary>
		/// Returns label under the current letter
		/// </summary>
		/// <param name="e">Letter position</param>
		/// <returns>int[] - coordinates of the label in array</returns>
		private int[] FindLabel(Point e)
		{
			int i = Components.ReturnLine(e);
			int j = Components.ReturnColumn(e);
			return new int[] { i, j };
		}


		/// <summary>
		/// For changing color
		/// </summary>
		/// <param name="l"></param>
		private void ChangeColor(Label l)
		{
			if (l == null)
				return;
			if (l.BackColor == Color.Red)
			{
				l.BackColor = Color.Pink;
				return;
			}
			if (l.BackColor == Color.Pink)
			{
				l.BackColor = Color.Red;
				return;
			}
			if (l.BackColor == Color.SteelBlue)
			{
				l.BackColor = Color.Blue;
				return;
			}
			if (l.BackColor == Color.Blue)
			{
				l.BackColor = Color.SteelBlue;
				return;
			}
			if (l.BackColor == Color.Orange)
			{
				l.BackColor = Color.OrangeRed;
				return;
			}
			if (l.BackColor == Color.OrangeRed)
			{
				l.BackColor = Color.Orange;
				return;
			}
			if (l.BackColor == Color.Indigo)
			{
				l.BackColor = Color.Purple;
				return;
			}
			if (l.BackColor == Color.Purple)
			{
				l.BackColor = Color.Indigo;
				return;
			}
			if (l.BackColor == Color.Green)
			{
				l.BackColor = Color.GreenYellow;
				return;
			}
			if (l.BackColor == Color.GreenYellow)
			{
				l.BackColor = Color.Green;
				return;
			}
		}


		/// <summary>
		/// Filling main field
		/// </summary>
		private void FillField()
		{
			Field.Size = Components.fieldSize;
			Legend.Top = Field.Top;
			Legend.Left = 20;
			Legend.Width = Width / 6;
			Field.Location = Components.fieldPosition;
			for (int i = 0; i < parts; i++)
				for (int j = 0; j < parts; j++)
				{
					GameField[i, j] = Components.GetLabel(i, j);
					GameField[i, j].SendToBack();
					Field.Controls.Add(GameField[i, j]);
				}
			var currentDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\", @"AppData\Files\MainField.txt");
			using (StreamReader Field = new StreamReader(currentDirectory))
			{
				string temp;
				int count = 0;
				while (!Field.EndOfStream)
				{
					temp = Field.ReadLine();
					for (int k = 0; k < temp.Length; k++)
					{
						switch (temp[k])
						{
							case 'G':
								GameField[count, k].BackColor = Color.Green;
								GameField[parts - count - 1, k].BackColor = Color.Green;
								break;
							case 'O':
								GameField[count, k].BackColor = Color.Orange;
								GameField[parts - count - 1, k].BackColor = Color.Orange;
								break;
							case 'P':
								GameField[count, k].BackColor = Color.Indigo;
								GameField[parts - count - 1, k].BackColor = Color.Indigo;
								break;
							case 'R':
								GameField[count, k].BackColor = Color.Red;
								GameField[parts - count - 1, k].BackColor = Color.Red;
								break;
							case 'B':
								GameField[count, k].BackColor = Color.Blue;
								GameField[parts - count - 1, k].BackColor = Color.Blue;
								break;
							default:
								break;
						}
					}
					count++;
				}
				for (int k = 0; k < parts; k++)
					GameField[parts / 2, k].BackColor = GameField[0, k].BackColor;
				GameField[parts / 2, parts / 2].BackColor = Color.Yellow;
			}
			ScorePanel.Left = Field.Left + Field.Width + 40;
			ScorePanel.Width = Width - Legend.Width - Field.Width;
			ScorePanel.BackColor = Color.Transparent;
			Panel DrawingPanel = new Panel();
			DrawingPanel.Name = "DrawingPanel";
			DrawingPanel.Location = Field.Location;
			DrawingPanel.Size = Field.Size;
			this.Controls.Add(DrawingPanel);
			DrawingPanel.BackColor = Color.Transparent;
			DrawingPanel.MouseMove += OnMouseMove;
			DrawingPanel.MouseDown += OnMouseDown;
			DrawingPanel.MouseUp += OnMouseUp;
			PropertyInfo prp = DrawingPanel.GetType().GetProperty("DoubleBuffered",
				BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
			prp.SetValue(DrawingPanel, true);
			Field.Size = Components.fieldSize;
		}
		
		/// <summary>
		/// Draw new letters
		/// </summary>
		private void CreateLetters()
		{
			int count = 0;
			if (TempPlayer.Letters.Count == 0)
			{
				TempPlayer.Letters.Add(Components.GetChip(Components.CreateNextLetterPoint(count), 'T'));
				TempPlayer.Letters.Add(Components.GetChip(Components.CreateNextLetterPoint(count + 1), 'O'));
			}
			foreach (var item in TempPlayer.Letters)
			{
				item.StartPosition = Components.CreateNextLetterPoint(count++);
				item.Location = item.StartPosition;
			}
			while(TempPlayer.Letters.Count<playerChipsCount)
				TempPlayer.Letters.Add(Components.GetChip(Components.CreateNextLetterPoint(count++)));
			foreach(var item in TempPlayer.Letters)
			{
				Field.Controls.Add(item);
				item.MouseDown += OnMouseDown;
				item.MouseUp += OnMouseUp;
				item.MouseMove += OnMouseMove;
				item.BringToFront();
			}
		}


		

		/// <summary>
		/// End of the turn
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NextTurnButton_Click(object sender, EventArgs e)
		{
			List<Letter> letters = new List<Letter>();
			foreach (var item in TempPlayer.Letters)
				if (item.Location != item.StartPosition)
					letters.Add(item.Letter);
			if (letters.Count == 0)
			{
				if (MessageBox.Show("Do you want to skip your turn?", "Skip turn", MessageBoxButtons.OKCancel) == DialogResult.OK)
					NewTurn();
				return;
			}
			else
			{
				LetterContainer.NewLetters(letters);
				Exception ex = LetterContainer.Check();
				if (ex != null)
				{
					ShowWarning warning = null;
					Type type = ex.GetType();
					if (ex is FirstWordException)
						warning = new ShowWarning("First word should contains cental cell");
					else if (ex is NewWordDisconnectWithOldException)
						warning = new ShowWarning("New words should be connected with old words");
					else if (ex is WordNotFoundException)
						warning = new ShowWarning("No such word in the dictionary");
					else if (ex is WordWasUsedException)
						warning = new ShowWarning("Word has been already used");
					else if (ex is NoNewWords)
						warning = new ShowWarning("No new words was added");
					warning.ShowDialog();
					SystemSounds.Exclamation.Play();
				}
				else
				{
					TempPlayer.Score += LetterContainer.tempScore;
					NewTurn();
				}
			}
		}

		/// <summary>
		/// Begin of the turn
		/// </summary>
		private void NewTurn()
		{
			count++;
			for (int i = 0; i < Players.Count; i++)
				PlayerScore[i].Text = Convert.ToString(Players[i].Score);
			foreach (var item in TempPlayer.Letters)
			{
				if (item.Location != item.StartPosition)
				{
					FieldLetters.Add(item);
					item.MouseMove -= OnMouseMove;
					item.MouseDown -= OnMouseDown;
					item.MouseUp -= OnMouseUp;
				}
				else
					Field.Controls.Remove(item);
			}
			foreach (var item in FieldLetters)
				TempPlayer.Letters.Remove(item);
			TempPlayer = Players[count % Players.Count];
			label1.Text = "Player: " + TempPlayer.Name;
			
			CreateLetters();
			SystemSounds.Beep.Play();
			

		}

		private void ChangeState()
		{
			if (count > 0)
			{
				if (gameType == Types.Server)
				{
					Field.Enabled = false;
					Server.SendAll(Players[count % Players.Count]);
					while (true)
					{
						if (Server.handler.Available > 0)
						{
							Server.GetAll(TempPlayer);
							break;
						}
					}
				}
			}
			if (gameType == Types.Client)
			{
				Field.Enabled = false;
				while (true)
				{
					if (Client.listenSocket.Available > 0)
					{
						Server.GetAll(TempPlayer);
						break;
					}
				}
			}
		}

		private void ScorePanelInit()
		{
			int i = 0;
			ScorePanel.Height = Players.Count * 50;
			foreach (var item in Players)
			{
				Label temp = new Label();
				ScorePanel.Controls.Add(temp);
				temp.Location = new Point(0, i*50);
				temp.Height = 50;
				temp.Width = ScorePanel.Width / 3;
				temp.Font = new Font("Old English Text MT", 15f);
				temp.Text = item.Name;
				Label score = new Label();
				ScorePanel.Controls.Add(score);
				score.Location = new Point(temp.Width + 10,i*50 );
				score.Height = 50;
				score.Width = ScorePanel.Width / 3;
				score.Font = new Font("Old English Text MT", 15f);
				PlayerScore.Add(score);
				i++;

			}
		}

		private void GameForm_Load(object sender, EventArgs e)
		{
			FillField();
			ScorePanelInit();
			NewTurn();
			//Socket();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			SaveForm save = new SaveForm();
			save.ShowDialog();
			if (Saver.wasFile)
				Saver.Save(Players);
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("You want to exit?", "Exit ask", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
				return;
				if (MessageBox.Show("Do you want to save game?","Saving ask",MessageBoxButtons.OKCancel) == DialogResult.OK)
				SaveButton_Click(sender, e);
			Close();
		}
	}
}

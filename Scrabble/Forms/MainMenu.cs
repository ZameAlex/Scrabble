using Scrabble.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Scrabble.Forms
{

	public partial class MainMenu : Form
	{
		MediaPlayer p = new MediaPlayer();
		private Panel TempPanel;
		private Panel RulesPanel;
		private Panel NewGamePanel;
		private Panel LoadGamePanel;
		private Panel MainPanel;
		Button NewGame;
		Button LoadGame;
		Button Rules;
		Button Exit;
		Button Begin;
		Button Connect;
		Button CreateServer;
		TextBox tb1, tb2, tb3, tb4;
		public MainMenu()
		{
			
			InitializeComponent();
			MainPanel = new Panel();
			NewGamePanel = new Panel();
			RulesPanel = new Panel();
			LoadGamePanel = new Panel();
			Controls.Add(MainPanel);
			Controls.Add(NewGamePanel);
			Controls.Add(RulesPanel);
			Controls.Add(LoadGamePanel);
			NewGame = new Button();
			LoadGame = new Button();
			Rules = new Button();
			Exit = new Button();
			Connect = new Button();
			CreateServer = new Button();
			ButtonInit(NewGame, "New game");
			ButtonInit(LoadGame, "Load game");
			ButtonInit(Rules, "Rules");
			ButtonInit(Exit, "Exit");
			ButtonInit(CreateServer, "Create game");
			ButtonInit(Connect, "Connect to existing game");
			Exit.Click += OnExit;
			PropertyInfo prp = MainPanel.GetType().GetProperty("DoubleBuffered",
				BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
			prp.SetValue(MainPanel, true);

			Begin = new Button();
			tb1 = new TextBox();
			tb2 = new TextBox();
			tb3 = new TextBox();
			tb4 = new TextBox();
			tb1.Font= new Font("Old English Text MT", 15f);
			tb2.Font = new Font("Old English Text MT", 15f);
			tb3.Font = new Font("Old English Text MT", 15f);
			tb4.Font = new Font("Old English Text MT", 15f);
			ButtonInit(Begin,"Start game");
			NewGame.Click += OnNewGame;
			Begin.Click += OnBegin;
			button1.Click += OnBack;
			LoadGame.Click += OnLoad;
			CreateServer.Click += OnServer;
			Connect.Click += OnClient;
			button1.Visible = false;
			prp = NewGamePanel.GetType().GetProperty("DoubleBuffered",
				BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
			prp.SetValue(NewGamePanel, true);
			prp = LoadGamePanel.GetType().GetProperty("DoubleBuffered",
				BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
			prp.SetValue(LoadGamePanel, true);
			RulesPanel.Visible = false;
		}

		private void OnServer(object sender, EventArgs e)
		{
			List<Player> players = new List<Player>();
			players.Add(new Player(tb1.Text));
			players.Add(new Player(tb2.Text));
			if (!String.IsNullOrEmpty(tb3.Text))
				players.Add(new Player(tb3.Text));
			if (!String.IsNullOrEmpty(tb4.Text))
				players.Add(new Player(tb4.Text));
			Server.Create();
			while(!Server.isConnect)
			{ }
			foreach (var item in players)
			{
				Server.SendPlayer(item);
			}
			GameForm Game = new GameForm(players, Types.Server);
			Game.ShowDialog();
		}

		private void OnClient(object sender, EventArgs e)
		{
			Client.Connect();
			List<Player> players = Client.GetPlayers();
			GameForm Game = new GameForm(players, Types.Client);
			Game.ShowDialog();
		}

		private void ButtonInit(Button button,string Text)
		{
			button.Text = Text;
			button.Font = new Font("Old English Text MT", 24f);
			button.BackColor = System.Drawing.Color.AliceBlue;
		}

		private void OnBack(object sender, EventArgs e)
		{
			MainPanel.Visible = true;
			TempPanel.Visible = false;
			TempPanel = null;
			button1.Visible = false;
		}

		private void OnExit(object sender,EventArgs e)
		{
			Close();
		}

		private void OnNewGame(object sender, EventArgs e)
		{
			MainPanel.Visible = false;
			button1.Visible = true;
			NewGamePanel.Visible = true;
			TempPanel = NewGamePanel;
		}

		private void OnBegin(object sender,EventArgs e)
		{
			List<Player> players = new List<Player>();
			players.Add(new Player(tb1.Text));
			players.Add(new Player(tb2.Text));
			if(!String.IsNullOrEmpty(tb3.Text))
				players.Add(new Player(tb3.Text));
			if (!String.IsNullOrEmpty(tb4.Text))
				players.Add(new Player(tb4.Text));
			GameForm Game = new GameForm(players,Types.HotSeat);
			Game.ShowDialog();
		}


		private void OnLoad(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = "D:\\study\\5-th\\M\\Scrabble\\Scrabble\\AppData\\SaveGame";
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				GameForm Game = new GameForm(Saver.Load(openFileDialog1.FileName),Types.Load);
				Game.ShowDialog();
			}
		}

		private void MainMenu_Load(object sender, EventArgs e)
		{
			int i = 0;
			MainPanel.Size = Size;
			MainPanel.Location = new Point(0, 0);
			MainPanel.BackColor = System.Drawing.Color.Transparent;
			RulesPanel.Size = Size;
			RulesPanel.Location = new Point(0, 0);
			RulesPanel.Controls.Add(CreateServer);
			RulesPanel.Controls.Add(Connect);
			Connect.Width = RulesPanel.Width / 3;
			Connect.Height = 50;
			CreateServer.Width = RulesPanel.Width / 3;
			CreateServer.Height = RulesPanel.Height / 4;
			Connect.Location = new Point(RulesPanel.Width / 3, RulesPanel.Height / 4);
			CreateServer.Location = new Point(RulesPanel.Width / 3, RulesPanel.Height / 2);
			NewGamePanel.BackColor = System.Drawing.Color.Transparent;
			NewGamePanel.Size = Size;
			NewGamePanel.Location = new Point(0, 0);
			NewGamePanel.BackColor = System.Drawing.Color.Transparent;
			NewGamePanel.Controls.Add(Begin);
			Begin.Height = 50;
			Begin.Width = 100;
			NewGamePanel.Controls.Add(tb1);
			NewGamePanel.Controls.Add(tb2);
			NewGamePanel.Controls.Add(tb3);
			NewGamePanel.Controls.Add(tb4);
			NewGamePanel.Visible = false;
			tb1.Size = new Size(MainPanel.Width / 3, 50);
			tb1.Location = new Point(MainPanel.Width / 3, (MainPanel.Height / 4) * i);
			i++;
			tb2.Size = new Size(MainPanel.Width / 3, 50);
			tb2.Location = new Point(MainPanel.Width / 3, (MainPanel.Height / 4) * i);
			i++;
			tb3.Size = new Size(MainPanel.Width / 3, 50);
			tb3.Location = new Point(MainPanel.Width / 3, (MainPanel.Height / 4) * i);
			i++;
			tb4.Size = new Size(MainPanel.Width / 3, 50);
			tb4.Location = new Point(MainPanel.Width / 3, (MainPanel.Height / 4) * i);
			i++;
			Begin.Location = new Point(tb4.Location.X + 50, tb4.Location.Y+20+tb4.Height);
			tb1.Text = "Player1";
			tb2.Text = "Player2";
			MainPanel.Controls.Add(NewGame);
			MainPanel.Controls.Add(LoadGame);
			MainPanel.Controls.Add(Rules);
			MainPanel.Controls.Add(Exit);
			i = 0;
			foreach (Button item in MainPanel.Controls)
			{
				item.Size = new Size(MainPanel.Width / 3, 50);
				item.Location = new Point(MainPanel.Width / 3, (MainPanel.Height / 4) * i);
				i++;
			}
			p.Open(new Uri(@"D:\study\5-th\M\Scrabble\Scrabble\AppData\Космические Рейнджеры 2(Игра) - Музыка Фэян.mp3"));
			p.Volume = 50;
			p.Play();
		}
	}
}

namespace Scrabble
{
	partial class GameForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
			this.RedDescription = new System.Windows.Forms.Label();
			this.OrangeDescription = new System.Windows.Forms.Label();
			this.PurpleDescription = new System.Windows.Forms.Label();
			this.BlueDescription = new System.Windows.Forms.Label();
			this.RedBox = new System.Windows.Forms.Label();
			this.OrangeBox = new System.Windows.Forms.Label();
			this.PurpleBox = new System.Windows.Forms.Label();
			this.BlueBox = new System.Windows.Forms.Label();
			this.Legend = new System.Windows.Forms.Panel();
			this.Field = new System.Windows.Forms.Panel();
			this.NextTurnButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.ScorePanel = new System.Windows.Forms.Panel();
			this.SaveButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.Legend.SuspendLayout();
			this.SuspendLayout();
			// 
			// RedDescription
			// 
			this.RedDescription.AutoSize = true;
			this.RedDescription.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RedDescription.Location = new System.Drawing.Point(57, 181);
			this.RedDescription.MaximumSize = new System.Drawing.Size(80, 50);
			this.RedDescription.MinimumSize = new System.Drawing.Size(35, 35);
			this.RedDescription.Name = "RedDescription";
			this.RedDescription.Size = new System.Drawing.Size(80, 35);
			this.RedDescription.TabIndex = 8;
			this.RedDescription.Text = "Third score for word";
			// 
			// OrangeDescription
			// 
			this.OrangeDescription.AutoSize = true;
			this.OrangeDescription.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OrangeDescription.Location = new System.Drawing.Point(57, 128);
			this.OrangeDescription.MaximumSize = new System.Drawing.Size(80, 50);
			this.OrangeDescription.MinimumSize = new System.Drawing.Size(35, 35);
			this.OrangeDescription.Name = "OrangeDescription";
			this.OrangeDescription.Size = new System.Drawing.Size(70, 42);
			this.OrangeDescription.TabIndex = 7;
			this.OrangeDescription.Text = "Double score for  word";
			// 
			// PurpleDescription
			// 
			this.PurpleDescription.AutoSize = true;
			this.PurpleDescription.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PurpleDescription.Location = new System.Drawing.Point(57, 73);
			this.PurpleDescription.MaximumSize = new System.Drawing.Size(80, 50);
			this.PurpleDescription.MinimumSize = new System.Drawing.Size(35, 35);
			this.PurpleDescription.Name = "PurpleDescription";
			this.PurpleDescription.Size = new System.Drawing.Size(80, 35);
			this.PurpleDescription.TabIndex = 6;
			this.PurpleDescription.Text = "Third score for letter";
			// 
			// BlueDescription
			// 
			this.BlueDescription.AutoSize = true;
			this.BlueDescription.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BlueDescription.Location = new System.Drawing.Point(57, 22);
			this.BlueDescription.MaximumSize = new System.Drawing.Size(80, 50);
			this.BlueDescription.MinimumSize = new System.Drawing.Size(35, 35);
			this.BlueDescription.Name = "BlueDescription";
			this.BlueDescription.Size = new System.Drawing.Size(68, 42);
			this.BlueDescription.TabIndex = 4;
			this.BlueDescription.Text = "Double score for letter";
			// 
			// RedBox
			// 
			this.RedBox.AutoSize = true;
			this.RedBox.BackColor = System.Drawing.Color.Red;
			this.RedBox.Location = new System.Drawing.Point(16, 181);
			this.RedBox.MaximumSize = new System.Drawing.Size(35, 35);
			this.RedBox.MinimumSize = new System.Drawing.Size(35, 35);
			this.RedBox.Name = "RedBox";
			this.RedBox.Size = new System.Drawing.Size(35, 35);
			this.RedBox.TabIndex = 3;
			// 
			// OrangeBox
			// 
			this.OrangeBox.AutoSize = true;
			this.OrangeBox.BackColor = System.Drawing.Color.Orange;
			this.OrangeBox.Location = new System.Drawing.Point(16, 128);
			this.OrangeBox.MaximumSize = new System.Drawing.Size(35, 35);
			this.OrangeBox.MinimumSize = new System.Drawing.Size(35, 35);
			this.OrangeBox.Name = "OrangeBox";
			this.OrangeBox.Size = new System.Drawing.Size(35, 35);
			this.OrangeBox.TabIndex = 2;
			// 
			// PurpleBox
			// 
			this.PurpleBox.AutoSize = true;
			this.PurpleBox.BackColor = System.Drawing.Color.Indigo;
			this.PurpleBox.Location = new System.Drawing.Point(16, 73);
			this.PurpleBox.MaximumSize = new System.Drawing.Size(35, 35);
			this.PurpleBox.MinimumSize = new System.Drawing.Size(35, 35);
			this.PurpleBox.Name = "PurpleBox";
			this.PurpleBox.Size = new System.Drawing.Size(35, 35);
			this.PurpleBox.TabIndex = 1;
			// 
			// BlueBox
			// 
			this.BlueBox.AutoSize = true;
			this.BlueBox.BackColor = System.Drawing.Color.SteelBlue;
			this.BlueBox.Location = new System.Drawing.Point(16, 22);
			this.BlueBox.MaximumSize = new System.Drawing.Size(35, 35);
			this.BlueBox.MinimumSize = new System.Drawing.Size(35, 35);
			this.BlueBox.Name = "BlueBox";
			this.BlueBox.Size = new System.Drawing.Size(35, 35);
			this.BlueBox.TabIndex = 0;
			// 
			// Legend
			// 
			this.Legend.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Legend.Controls.Add(this.BlueBox);
			this.Legend.Controls.Add(this.RedDescription);
			this.Legend.Controls.Add(this.RedBox);
			this.Legend.Controls.Add(this.OrangeDescription);
			this.Legend.Controls.Add(this.OrangeBox);
			this.Legend.Controls.Add(this.BlueDescription);
			this.Legend.Controls.Add(this.PurpleBox);
			this.Legend.Controls.Add(this.PurpleDescription);
			this.Legend.Location = new System.Drawing.Point(49, 78);
			this.Legend.MaximumSize = new System.Drawing.Size(250, 200);
			this.Legend.MinimumSize = new System.Drawing.Size(150, 250);
			this.Legend.Name = "Legend";
			this.Legend.Size = new System.Drawing.Size(150, 250);
			this.Legend.TabIndex = 9;
			this.Legend.Resize += new System.EventHandler(this.panel1_Resize);
			// 
			// Field
			// 
			this.Field.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.Field.Location = new System.Drawing.Point(206, 81);
			this.Field.Name = "Field";
			this.Field.Size = new System.Drawing.Size(400, 500);
			this.Field.TabIndex = 10;
			// 
			// NextTurnButton
			// 
			this.NextTurnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.NextTurnButton.BackColor = System.Drawing.Color.Sienna;
			this.NextTurnButton.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NextTurnButton.Location = new System.Drawing.Point(671, 554);
			this.NextTurnButton.Name = "NextTurnButton";
			this.NextTurnButton.Size = new System.Drawing.Size(75, 48);
			this.NextTurnButton.TabIndex = 11;
			this.NextTurnButton.Text = "Next Turn";
			this.NextTurnButton.UseVisualStyleBackColor = false;
			this.NextTurnButton.Click += new System.EventHandler(this.NextTurnButton_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Old English Text MT", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(336, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 26);
			this.label1.TabIndex = 12;
			this.label1.Text = "label1";
			// 
			// ScorePanel
			// 
			this.ScorePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ScorePanel.Location = new System.Drawing.Point(612, 82);
			this.ScorePanel.Name = "ScorePanel";
			this.ScorePanel.Size = new System.Drawing.Size(200, 100);
			this.ScorePanel.TabIndex = 13;
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SaveButton.BackColor = System.Drawing.Color.Sienna;
			this.SaveButton.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SaveButton.Location = new System.Drawing.Point(623, 5);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 48);
			this.SaveButton.TabIndex = 15;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = false;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// ExitButton
			// 
			this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ExitButton.BackColor = System.Drawing.Color.Sienna;
			this.ExitButton.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ExitButton.Location = new System.Drawing.Point(704, 5);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(75, 48);
			this.ExitButton.TabIndex = 16;
			this.ExitButton.Text = "Exit";
			this.ExitButton.UseVisualStyleBackColor = false;
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(781, 733);
			this.ControlBox = false;
			this.Controls.Add(this.ExitButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.ScorePanel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.NextTurnButton);
			this.Controls.Add(this.Field);
			this.Controls.Add(this.Legend);
			this.DoubleBuffered = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GameForm";
			this.Text = "Scrabble";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.GameForm_Load);
			this.Legend.ResumeLayout(false);
			this.Legend.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label BlueDescription;
		private System.Windows.Forms.Label RedBox;
		private System.Windows.Forms.Label OrangeBox;
		private System.Windows.Forms.Label PurpleBox;
		private System.Windows.Forms.Label BlueBox;
		private System.Windows.Forms.Label RedDescription;
		private System.Windows.Forms.Label OrangeDescription;
		private System.Windows.Forms.Label PurpleDescription;
		private System.Windows.Forms.Panel Legend;
		public System.Windows.Forms.Panel Field;
		private System.Windows.Forms.Button NextTurnButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel ScorePanel;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button ExitButton;
	}
}


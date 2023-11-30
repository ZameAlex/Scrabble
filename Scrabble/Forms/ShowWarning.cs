using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble.Forms
{
	public partial class ShowWarning : Form
	{
		public ShowWarning(string message)
		{
			InitializeComponent();
			Label.Text = message;
			Size = Label.Size+new Size(40,button1.Height+Label.Height+70);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

using Scrabble.Logic;
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
	public partial class SaveForm : Form
	{
		public SaveForm()
		{
			InitializeComponent();
		}

		private void Ok_Click(object sender, EventArgs e)
		{

			if(String.IsNullOrEmpty(textBox1.Text))
			{
				MessageBox.Show("Please, enter file name!");
				return;
			}
			Saver.SaveFile(textBox1.Text);
			Close();
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

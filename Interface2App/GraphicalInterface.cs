using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace Interface2App
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		
		/// <summary>
		/// Opening a thread that indicates mouse's position
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			flickerBindingSource.DataSource = new List<Flicker>();
			Thread trackerThread = new Thread(Tracker);

			trackerThread.Start();
			
		}

		private bool condition = true; // consition to detect when the Thread should stop 
		/// <summary>
		/// Setting mouse's position 
		/// </summary>
		private async void Tracker()
		{

			while (condition) // do it repeatly
			{
				int x = (int)MousePosition.X ;
				int y = (int)MousePosition.Y ;
				SetText(labelX, x.ToString());
				SetText(labelY, y.ToString());
				await Task.Delay(10);
			}

		}
		delegate void SetTextCallback(Label label, string text);
		private void SetText(Label l, string text)
		{
			if (l.InvokeRequired)
			{
				SetTextCallback d = new SetTextCallback(SetText);
				Invoke(d, new object[] { l, text });
			}
			else
			{
				l.Text = text;
			}
		}

		/// <summary>
		/// Saving all informations which were written in the interface to the file.txt.<br/>
		/// The file path is "C:\\Users\\"Your computer's name"\\Desktop\\test_file.txt";
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bt_save(object sender, EventArgs e)
		{
			//StreamWriter file = new StreamWriter("C:\\Users\\Lenovo\\Desktop\\test_file.txt");// change here 
			DateTime now = DateTime.Now;
			string path = "C:\\Users\\Lenovo\\Desktop\\test2_file.txt";

			using (StreamWriter s = File.AppendText(path))
			{
				for (int i = 0; i < dataGridView1.Rows.Count - 2; i++)
				{
					for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
					{
						s.Write(dataGridView1.Rows[i].Cells[j].Value?.ToString());
						s.Write(" ");
					}
					s.Write("\t"); s.Write(now.ToString());
					s.Write("\n");
				}
				s.Close();
			}
			

			return;
			
		}
		/// <summary>
		/// Indicating the three elements of color 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bar_Scroll(object sender, EventArgs e)
		{
			int redValue = red.Value;
			int greenValue = green.Value;
			int blueValue = blue.Value;

			try
			{
				pnl.BackColor = Color.FromArgb(redValue, greenValue, blueValue);
			}
			catch (Exception)
			{

				throw;
			}
		}
		

		// Closing Appliacation anyway

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			condition = false; // we must stop the thread before doing any tasks

			System.Windows.Forms.Application.Exit();
			
		}
		/// <summary>
		/// Indicating instructures 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_help_Click(object sender, EventArgs e)
		{
			MessageBox.Show("All the TextBox should be filled by a number as flowing instructions \n\n" +
				"I.\n" +
				"X (Horizontal), Y (Vertical) repectively corresspond to the possition of center of flicker\n\n" +
				"II.\n" +
				"Width, Height defined how many pixels you want to put in\n\n" +
				"III.\n" +
				"Frequence in Hz and Phase in degrees\n\n"+ 
				"IV.\n"+ 
				"You can choose in Type (1 - 5)\n" +
				"1: Random \n" +
				"2: Sinous \n" +
				"3: Square \n" +
				"4: Root Square\n"+
				"5: Maximum length sequencen\n\n" +
				"V.\n" +
				"After completing each all TextBox, you can click to New to create a new data \n" +
				"Click to Create File to save permentaly data to the file, Click to Save to just use the instance data\n\n" +
				
				"VI.\n" +
				"Finally, Click to RUN to run program or PRE to re-run privous configuration\n\n" +
				"THANK FOR READING !!!");
		}
		/// <summary>
		/// Run the previous configuration 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_pre_Click(object sender, EventArgs e)
		{
			condition = false; // we must stop the thread before doing any tasks

			System.Windows.Forms.Application.Exit();
			
		}
		/// <summary>
		/// Run the program
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bt_run_Click(object sender, EventArgs e)
		{
			// we must stop the thread before doing any tasks
			btn_save_imediatly_Click(sender, e);
			

			if (this.ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled))
			{
				condition = false;
				System.Windows.Forms.Application.Exit();
			}
			else
			{
				MessageBox.Show("Fault, TRY AGAIN!" );
				
			}
			
		}


		// errorProvider 
		//----------------------------------------------- Input validation ----------------------------------------------//

		public int resX = Screen.PrimaryScreen.Bounds.Width;
		public int resY = Screen.PrimaryScreen.Bounds.Height;
		
		private void flickerBindingNavigator_RefreshItems(object sender, EventArgs e)
		{

		}

		private void btn_new_Click(object sender, EventArgs e)
		{
			flickerBindingSource.AddNew();
			//flickerBindingSource.DataSource = new Flicker();
		}

		private void btn_save_imediatly_Click(object sender, EventArgs e)
		{
			flickerBindingSource.EndEdit();
			Flicker flicker = flickerBindingSource.Current as Flicker;
			if (flicker != null)
			{
				if (flicker.IsValid)
				{
					using (TextWriter file = new StreamWriter("C:\\Users\\Lenovo\\Desktop\\test1_file.txt"))
					{

						for (int i = 0; i < dataGridView1.Rows.Count - 2; i++)
						{
							for (int j = 0; j < dataGridView1.Columns.Count - 1 ; j++)
							{
								file.Write(dataGridView1.Rows[i].Cells[j].Value?.ToString());
								file.Write(" ");
							}
							file.Write(dataGridView1.Rows[i].Cells[dataGridView1.Columns.Count - 1].Value?.ToString());
							file.Write("\n");
						}
						file.Close();
					}

				}
			}
		}
	}
}

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
using VisualStimuli;

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
			flickerBindingSource.DataSource = new List<Check>();
			Thread trackerThread = new Thread(Tracker);
			try
			{
				trackerThread.Start();
			}
			catch (ThreadStateException)
			{
				trackerThread.Abort();
			}
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
			DateTime now = DateTime.Now;
			//string path = "D:\\MANIPS\\FlickersOnTop\\test1_file.txt";
			string path = Application.StartupPath;
			path = path.Substring(0, path.LastIndexOf('\\'));
			path = path.Substring(0, path.LastIndexOf('\\'));
			path += "\\test1_file.txt";
			//StreamWriter file = new StreamWriter(path);// change here 

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
			MessageBox.Show("Save file successfully");

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
			MessageBox.Show("All the TextBox should be filled by a number as flowing instructions. \n\n" +
				"I.\n" +
				"X (Horizontal), Y (Vertical) repectively corresspond to the possition of center of flicker.\n\n" +
				"II.\n" +
				"Width, Height defined how many pixels you want to put in.\n\n" +
				"III.\n" +
				"Frequence in Hz and Phase in degrees.\n\n"+ 
				"IV.\n"+ 
				"You can choose in Type (0 - 4)\n" +
				"0: Random \n" +
				"1: Sinous \n" +
				"2: Square \n" +
				"3: Root Square\n"+
				"4: Maximum length sequencen\n\n" +
				"V.\n" +
				"After completing each all TextBox, you can click to New to create a new data/ \n" +
				"Click to Create File to save permentaly data to the file, Click to Save to just use the instance data.\n\n" +
				
				"VI.\n" +
				"Finally, Click to RUN to run program or PRE to re-run privous configuration.\n" +
				"Click to Image to take an image and it will flick with defined Type anf Frequence you have met.\n\n" +
				"THANK FOR READING !!!");
		}
		/// <summary>
		/// Run the previous configuration 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_pre_Click(object sender, EventArgs e)
		{

			//condition = false; // we must stop the thread before doing any tasks
			this.WindowState = FormWindowState.Minimized;
			CPlay oPlay = new CPlay();
			oPlay.flexibleSin();
			
			oPlay.Close();
			//System.Windows.Forms.Application.Exit();
			
		}
		/// <summary>
		/// Run the program
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bt_run_Click(object sender, EventArgs e)
		{
			
			btn_save_immediatly_Click(sender, e);
			

			if (this.ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled))
			{
				condition = false; // we must stop the thread before doing any tasks
				//System.Windows.Forms.Application.Exit();
				this.WindowState = FormWindowState.Minimized;
				CPlay oPlay = new CPlay();
				oPlay.flexibleSin();
				Application.Exit();

			}
			else
			{
				MessageBox.Show("Fault, TRY AGAIN!");
				
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
			
		}

		private void btn_save_immediatly_Click(object sender, EventArgs e)
		{
			flickerBindingSource.EndEdit();
			Check flicker = flickerBindingSource.Current as Check;
			if (flicker != null)
			{
				if (flicker.IsValid)
				{
					string path = Application.StartupPath;
					path = path.Substring(0, path.LastIndexOf('\\'));
					path = path.Substring(0, path.LastIndexOf('\\'));
					path += "\\test1_file.txt";
					using (TextWriter file = new StreamWriter(path))
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

		

		private void btn_delete_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
			{
				dataGridView1.Rows.RemoveAt(item.Index);
			}
		}

		
		public void btn_image(object sender, EventArgs e)
		{
			
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "bmp file (*.bmp)|*.bmp|All files (*.*)|*.*";
				
				if(ofd.ShowDialog() == DialogResult.OK)
				{
					string filename = ofd.FileName;
					string path = "C:\\Users\\Lenovo\\Desktop\\image_file.txt";
					StreamWriter a = new StreamWriter(path);
					a.Write(filename);
					a.Close();
				}
			}
			//this.WindowState = FormWindowState.Minimized;
			CPlay oPlay = new CPlay();
			oPlay.ImageFlicker();
			
			
		}
		
		private void btn_imp(object sender, EventArgs e)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("X-11 ", typeof(string));
			dataTable.Columns.Add("Y ", typeof(string));
			dataTable.Columns.Add("Width-11 ", typeof(string));
			dataTable.Columns.Add("Height ", typeof(string));
			dataTable.Columns.Add("Frequence ", typeof(string));
			dataTable.Columns.Add("Phase ", typeof(string));
			dataTable.Columns.Add("Opacity ", typeof(string));
			dataTable.Columns.Add("Type ", typeof(string));
			dataTable.Columns.Add("Suplement ", typeof(string));

			dataGridView1.DataSource = dataTable;

			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "txt file (*.txt)|*.txt|All files (*.*)|*.*";

				if(ofd.ShowDialog() == DialogResult.OK)
				{
					string filename = ofd.FileName;
					//StreamReader file = new StreamReader(filename);

					string[] lines = File.ReadAllLines(filename);

					string[] data;
					for(int i = 0; i < lines.Length; i++)
					{
						data = lines[i].ToString().Split('|');
						string[] row = new string[data.Length];
						for(int j = 0; j < data.Length; j++)
						{
							row[j] = data[j];
						}
						dataTable.Rows.Add(row);
					}


					/*
					string[] columnnames = file.ReadLine().Split(' ');
					
					foreach(string c in columnnames)
					{
						dataTable.Columns.Add(c);
					}

					string newline;
					while((newline = file.ReadLine())!= null)
					{
						DataRow dr = dataTable.NewRow();
						string[] values = newline.Split(' ');	
						for(int i = 0; i <values.Length; i++)
						{
							dr[i] = values[i];
						}
						dataTable.Rows.Add(dr);
					}
					file.Close();
					dataGridView1.DataSource = dataTable;
					//flickerBindingSource.DataSource = dataTable;
					*/
				}
				
			}
		}
	}
}

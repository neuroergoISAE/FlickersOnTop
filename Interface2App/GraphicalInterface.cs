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
		/// The file path is "C:\\Users\\Lenovo\\Desktop\\test_file.txt";
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bt_save(object sender, EventArgs e)
		{
			StreamWriter file = new StreamWriter("C:\\Users\\Lenovo\\Desktop\\test_file.txt");// change here 
			//StreamWriter file = new StreamWriter("test_file.txt");
			//flicker 1

			string t1 = text1.Text;
			string t2 = text2.Text;
			string t3 = text3.Text;
			string t4 = text4.Text;
			string t5 = text5.Text;
			string t6 = text6.Text;
			string tAlpha1 = textAlpha1.Text;
			string type1 = textType1.Text;
			

			file.Write(t1 + " "); file.Write(t2 + " "); file.Write(t3 + " ");
			file.Write(t4 + " "); file.Write(t5 + " "); file.Write(t6 + " ");
			file.Write(tAlpha1 + " ");
			file.Write(type1 + " ");
			if (red.Value == 0 && green.Value == 0 && blue.Value == 0)
			{
				file.Write("255" + " "); file.Write("255" + " "); file.Write("255" + "\n");
			}
			else
			{
				file.Write(red.Value + " "); file.Write(green.Value + " "); file.Write(blue.Value + "\n"); 
			}
			
			//flicker 2
			string t7 = text7.Text; // x
			string t8 = text8.Text; // y
			string t9 = text9.Text; // widht
			string t10 = text10.Text; // height
			string t11 = text11.Text; // freq 
			string t12 = text12.Text; // pharse
			string tAlpha2 = textAlpha2.Text; // opacity
			string type2 = textType2.Text;
			
			
			file.Write(t7 + " "); file.Write(t8 + " "); file.Write(t9 + " ");
			file.Write(t10 + " "); file.Write(t11 + " "); file.Write(t12 + " ");
			file.Write(tAlpha2 + " ");
			//file.Write(red.Value + " "); file.Write(green.Value + " "); file.Write(blue.Value + " ");
			file.Write(type2 + "\n");

			//flicker 3
			string t13 = text13.Text;
			string t14 = text14.Text;
			string t15 = text15.Text;
			string t16 = text16.Text;
			string t17 = text17.Text;
			string t18 = text18.Text;
			string tAlpha3 = textAlpha3.Text;
			string type3 = textType3.Text;

			file.Write(t13 + " "); file.Write(t14 + " "); file.Write(t15 + " ");
			file.Write(t16 + " "); file.Write(t17 + " "); file.Write(t18 + " ");
			file.Write(tAlpha3 + " ");
			//file.Write(red.Value + " "); file.Write(green.Value + " "); file.Write(blue.Value + " ");
			file.Write(type3 + "\n");

			//flicker 4
			string t19 = text19.Text;
			string t20 = text20.Text;
			string t21 = text21.Text;
			string t22 = text22.Text;
			string t23 = text23.Text;
			string t24 = text24.Text;
			string tAlpha4 = textAlpha4.Text;
			string type4 = textType4.Text;


			file.Write(t19 + " "); file.Write(t20 + " "); file.Write(t21 + " ");
			file.Write(t22 + " "); file.Write(t23 + " "); file.Write(t24 + " ");
			file.Write(tAlpha4 + " ");
			//file.Write(red.Value + " "); file.Write(green.Value + " "); file.Write(blue.Value + " "); 
			file.Write(type4 + "\n");

			
			file.Close();
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
		/// <summary>
		/// Open other form to save more flickers
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_expand_Click(object sender, EventArgs e)
		{
			Form2 f2 = new Form2();
			f2.ShowDialog();
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
				"After completing each line, you must recheck that your texts are correctly in forms \n" +
				"Finally, Click to RUN button to run program of PRE to run previous configuration\n\n" +
				
				"VI.\n" +
				"Each column corresponds to characteristics and each line corresponds to flickers\n\n" +
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
			bt_save(sender, e);

			if (this.ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled))
			{
				condition = false;
				System.Windows.Forms.Application.Exit();
			}
			else
			{
				MessageBox.Show("YOU MUST COMPLETE ONE LINE, TRY AGAIN!");
				
			}
			
		}


		// errorProvider 
		//----------------------------------------------- Input validation ----------------------------------------------//

		private int resX = Screen.PrimaryScreen.Bounds.Width;
		private int resY = Screen.PrimaryScreen.Bounds.Height;
		// X - Text1
		private void text1_Validating(object sender, CancelEventArgs e)
		{
			
			if (string.IsNullOrEmpty(text1.Text) )
			{
				e.Cancel = true;
				
				errorProvider1.SetError(text1, "Please fill a number");
			}
			else
			{
				e.Cancel = false;
				int a;
				bool check = int.TryParse(text1.Text, out a);

				if (check) { 
					if(a>=0 && a <= resX)
					{
						errorProvider1.SetError(text1, null);
					}
					else
					{
						errorProvider1.SetError(text1, "X must be in range [0-" + resX.ToString() + "]") ;
					}
				}
				else
				{
					errorProvider1.SetError(text1, "Wrong format");
				}
				
			}
				
			
		}
		// Y - Text2
		private void text2_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(text2.Text))
			{
				e.Cancel = true;

				errorProvider1.SetError(text2, "Please fill a number");
			}
			else
			{
				e.Cancel = false;
				int a;
				bool check = int.TryParse(text2.Text, out a);

				if (check)
				{
					if (a >= 0 && a <= resY)
					{
						errorProvider1.SetError(text2, null);
					}
					else
					{
						errorProvider1.SetError(text2, "Y must be in range [0-" + resY.ToString() + "]");
					}
				}
				else
				{
					errorProvider1.SetError(text2, "Wrong format");
				}

			}
		}

		// Width - Text3
		private void text3_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(text3.Text))
			{
				e.Cancel = true;

				errorProvider1.SetError(text3, "Please fill a number");
			}
			else
			{
				e.Cancel = false;
				int a;
				bool check = int.TryParse(text3.Text, out a);

				if (check)
				{
					if (a > 0 && a <= resX)
					{
						errorProvider1.SetError(text3, null);
					}
					else
					{
						errorProvider1.SetError(text3, "Width must be in range[0 - " + resX.ToString() + "]");
					}
				}
				else
				{
					errorProvider1.SetError(text3, "Wrong format");
				}
			}
		}
		// Height - Text4
		private void text4_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(text4.Text))
			{
				e.Cancel = true;

				errorProvider1.SetError(text4, "Please fill a number");
			}
			else
			{
				e.Cancel = false;
				int a;
				bool check = int.TryParse(text4.Text, out a);

				if (check)
				{
					if (a > 0 && a <= resY)
					{
						errorProvider1.SetError(text4, null);
					}
					else
					{
						errorProvider1.SetError(text4, "Height must be in range [0-" + resY.ToString() + "]");
					}
				}
				else
				{
					errorProvider1.SetError(text4, "Wrong format");
				}
			}
		}
		//Frequence - Text5
		private void text5_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(text5.Text))
			{
				e.Cancel = true;

				errorProvider1.SetError(text5, "Please fill a number");
			}
			else
			{
				e.Cancel = false;
				int a;
				bool check = int.TryParse(text5.Text, out a);

				if (check)
				{
					if (a >=1 && a <= 30)
					{
						errorProvider1.SetError(text5, null);
					}
					else
					{
						errorProvider1.SetError(text5, "Frequence must be in range [1-30]");
					}
				}
				else
				{
					errorProvider1.SetError(text5, "Wrong format");
				}
			}
		}
		//Pharse - Text6
		private void text6_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(text6.Text))
			{
				e.Cancel = true;

				errorProvider1.SetError(text6, "Please fill a number");
			}
			else
			{
				e.Cancel = false;
				int a;
				bool check = int.TryParse(text6.Text, out a);

				if (check)
				{
					if (a >= 0 && a <= 180)
					{
						errorProvider1.SetError(text6, null);
					}
					else
					{
						errorProvider1.SetError(text6, "Pharse must be in range [0-180]");
					}
				}
				else
				{
					errorProvider1.SetError(text6, "Wrong format");
				}
			}
		}
		// Opacity - textAlpha1
		private void textAlpha1_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(textAlpha1.Text))
			{
				e.Cancel = true;

				errorProvider1.SetError(textAlpha1, "Please fill a number");
			}
			else
			{
				e.Cancel = false;
				int a;
				bool check = int.TryParse(textAlpha1.Text, out a);

				if (check)
				{
					if (a >= 0 && a <= 100)
					{
						errorProvider1.SetError(textAlpha1, null);
					}
					else
					{
						errorProvider1.SetError(textAlpha1, "Opacity must be in range [0-100]");
					}
				}
				else
				{
					errorProvider1.SetError(textAlpha1, "Wrong format");
				}
			}
		}

		// Type - textType1
		private void textType1_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(textType1.Text))
			{
				e.Cancel = true;

				errorProvider1.SetError(textType1, "Please fill a number");
			}
			else
			{
				e.Cancel = false;
				int a;
				bool check = int.TryParse(textType1.Text, out a);

				if (check)
				{
					if (a >= 1 && a <= 5)
					{
						errorProvider1.SetError(textType1, null);
					}
					else
					{
						errorProvider1.SetError(textType1, "Type must be in range [1-5]");
					}
				}
				else
				{
					errorProvider1.SetError(textType1, "Wrong format");
				}
				
			}
		}

		
	}
}

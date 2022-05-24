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



namespace Interface2App
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void bt_save(object sender, EventArgs e)
		{
			StreamWriter file = new StreamWriter("C:\\Users\\Lenovo\\Desktop\\test_file.txt");// change here 
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
			file.Write(red.Value + " "); file.Write(green.Value + " "); file.Write(blue.Value + " ");file.Write(type1 + "\n");
			//flicker 2
			string t7 = text7.Text;
			string t8 = text8.Text;
			string t9 = text9.Text;
			string t10 = text10.Text;
			string t11 = text11.Text;
			string t12 = text12.Text;
			string tAlpha2 = textAlpha2.Text;
			string type2 = textType2.Text;
			
			
			file.Write(t7 + " "); file.Write(t8 + " "); file.Write(t9 + " ");
			file.Write(t10 + " "); file.Write(t11 + " "); file.Write(t12 + " ");
			file.Write(tAlpha2 + " ");
			file.Write(red.Value + " "); file.Write(green.Value + " "); file.Write(blue.Value + " ");file.Write(type2 + "\n");

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
			file.Write(red.Value + " "); file.Write(green.Value + " "); file.Write(blue.Value + " "); file.Write(type3 + "\n");

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
			file.Write(red.Value + " "); file.Write(green.Value + " "); file.Write(blue.Value + " "); file.Write(type4 + "\n");


			// Warnted when users does not input right chacracters

			if(Double.TryParse(t1, out _) != true) {
				warnted.Text = "Click HELP !!!";	
					
			}
			if (Double.TryParse(t7, out _) != true)
			{
				warnted.Text = "Click HELP !!!";

			}
			if (Double.TryParse(t2, out _) != true)
			{
				warnted.Text = "Click HELP !!!";

			}

			file.Close();
		}

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

		private void label6_Click(object sender, EventArgs e)
		{

		}

		

		private void text1_TextChanged(object sender, EventArgs e)
		{

		}

		private void form_warnted(object sender, EventArgs e)
		{
			
			
		}

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
				"You can choose in Type (1 - 4)\n" +
				"1: Random \n" +
				"2: Sinous \n" +
				"3: Square \n" +
				"4: Root Square\n"+
				"5: Maximum length sequencen\n\n" +
				"V.\n" +
				"After finishing one line, you can click to Create File and run Visual Stimuli project \n\n" +
				
				"VI.\n" +
				"Each column corresponds to characteristics and each line corresponds to flickers\n\n" +
				"HAVE FUN !!!");
		}
	}
}

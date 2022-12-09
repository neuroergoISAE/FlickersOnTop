using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using System.Xml;
using VisualStimuli;
using System.Xml.Serialization;

namespace Interface2App
{
	public partial class Form1 : Form
	{
		string path;
		string default_save_file;
		private static Color convertColor(System.Windows.Media.Color c)
		{
			return Color.FromArgb(c.A,c.R,c.G,c.B);
		}
        public Form1()
		{
			InitializeComponent();
            path = Application.StartupPath;
            path = path.Substring(0, path.LastIndexOf('\\'));
            path = path.Substring(0, path.LastIndexOf('\\'));
			default_save_file = path + "\\Flickers.xml";
        }
		private List<Flicker> FlickerList = new List<Flicker>();
		private List<Flicker> CopyList = new List<Flicker>();
        /// <summary>
        /// Loading the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
		{
            flickerBindingSource.DataSource = FlickerList;
			//screenViewer1.DataBindings.Add("DataSource",FlickerList , "", true, DataSourceUpdateMode.OnPropertyChanged);
			// Get the path of the selected file
            string filePath = default_save_file;

			loadFile(default_save_file);
        }
		delegate void SetTextCallback(Label label, string text);
		public void SetText(Label l, string text)
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
		private void loadFile(string filePath)
		{
            XmlSerializer serializer = new XmlSerializer(typeof(List<Flicker>));
            using (StreamReader s = new StreamReader(filePath))
            {
                FlickerList = (List<Flicker>)serializer.Deserialize(s);
                flickerBindingSource.DataSource = FlickerList;
                FlickerDataGridView.Update();
                SetText(labelTest, FlickerList.Count.ToString());
                s.Close();
				for(int i=0; i < FlickerList.Count; i++)
				{
                    FlickerDataGridView.Rows[i].Cells["color"].Style.BackColor = convertColor(FlickerList[i].color1);
                }
            }
        }
		/// <summary>
		/// Saving all informations which were written in the interface to an xml file.<br/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bt_save(object sender, EventArgs e)
		{
			try
			{
                string file = default_save_file;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Flicker>));
				using (StreamWriter s = new StreamWriter(file))
				{
					serializer.Serialize(s, FlickerList);
					s.Close();
				}
                SetText(labelTest, string.Format("File saved Succesfully at: {0}", file));
			}
			catch
			{
				SetText(labelTest, "An Error Occured While Trying To Save");
			}
            
			return;
		}
        private void bt_save_as(object sender, EventArgs e)
        {

            try
            {
                // Create an instance of the SaveFileDialog class
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // Set the filter to only show files with the .txt extension
                saveFileDialog.Filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*";
				saveFileDialog.DefaultExt = "xml";

                // Set the default directory to the App directory
                saveFileDialog.InitialDirectory = path;

				string file;
                // Show the dialog and check if the user clicked the OK button
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the selected file
                    file = (string)saveFileDialog.FileName;
				}
				else
				{
					file = path + "\\Flickers.xml";
				}
                XmlSerializer serializer = new XmlSerializer(typeof(List<Flicker>));
                using (StreamWriter s = new StreamWriter(file))
                {
                    serializer.Serialize(s, FlickerList);
                    s.Close();
                }
                SetText(labelTest, string.Format("File saved Succesfully at: {0}", file));
				default_save_file = file;
            }
            catch
            {
                SetText(labelTest, "An Error Occured While Trying To Save");
            }

            return;

        }
		

		// Closing Application anyway
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			System.Windows.Forms.Application.Exit();
		}
		/// <summary>
		/// Indicating instructures 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_help_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.MessageBox.Show("All the TextBox should be filled by a number as flowing instructions. \n\n" +
				"I.\n" +
				"X (Horizontal), Y (Vertical) correspond to the position of top-left point of the flicker (in pixel).\n\n" +
				"II.\n" +
				"Width, Height is the size of the Flicker (in pixel).\n\n" +
				"III.\n" +
				"Frequency in Hz and Phase in degrees.\n\n"+ 
				"IV.\n"+ 
				"You can choose in Type\n" +
				"Random \n" +
				"Sinous \n" +
				"Square \n" +
				"Root Square\n"+
				"Maximum length sequencen\n\n" +
				"V.\n" +
				"You can click on New to create a new Flicker/ \n" +
				".\n\n" +
				
				"VI.\n" +
				"Finally, click on RUN to run the Flicker program or PRE to re-run previous configuration.\n" +
				"THANK FOR READING !!!");
		}
		/// <summary>
		/// Run the previous configuration 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_pre_Click(object sender, EventArgs e)
		{
			CPlay oPlay = new CPlay();
			oPlay.flexibleSin();
			oPlay.Close();
			//Application.Exit();
		}
		/// <summary>
		/// Run the program
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bt_run_Click(object sender, EventArgs e)
		{
			bt_save(sender, e);
			if (this.ValidateChildren(ValidationConstraints.ImmediateChildren | ValidationConstraints.Enabled))
			{
				CPlay oPlay = new CPlay();
				oPlay.flexibleSin();
				//Application.Exit();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Fault, TRY AGAIN!");
			}
		}


		// errorProvider 
		//----------------------------------------------- Input validation ----------------------------------------------//

		public int resX = Screen.PrimaryScreen.Bounds.Width;
		public int resY = Screen.PrimaryScreen.Bounds.Height;


		private void btn_new_Click(object sender, EventArgs e)
		{
			flickerBindingSource.AddNew();
			FlickerDataGridView.Rows[FlickerList.Count-1].Cells["color1"].Style.BackColor = convertColor(FlickerList[FlickerList.Count - 1].color1);
        }

		private void btn_delete_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow item in this.FlickerDataGridView.SelectedRows)
			{
				FlickerDataGridView.Rows.RemoveAt(item.Index);
			}
		}
		
		private void btn_imp(object sender, EventArgs e)
		{
            // Create an instance of the OpenFileDialog class
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to only show files with the .txt extension
            openFileDialog.Filter = "Xml files (*.xml)|*.xml|All files (*.*)|*.*";

			// Set the default directory to the user's My Documents folder
			openFileDialog.InitialDirectory = path;

            // Show the dialog and check if the user clicked the OK button
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of the selected file
                string filePath = openFileDialog.FileName;
				loadFile(filePath);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
		private void onDataChanged(object sender, EventArgs e)
		{
			screenViewer1.DataSource= FlickerList;
			screenViewer1.Invalidate();
		}
        private void FlickerDataGridCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			try
			{
				if (e.RowIndex >= 0 && e.ColumnIndex == FlickerDataGridView.Columns["color"].Index)
				{
					ColorDialog colorPickerDialog= new ColorDialog();
					var c = FlickerList[e.RowIndex].color1;
                    colorPickerDialog.Color = Color.FromArgb(c.A,c.R,c.G,c.B);
                    if (colorPickerDialog.ShowDialog()==DialogResult.OK)
					{
                        var c1 = colorPickerDialog.Color;
                        FlickerList[e.RowIndex].color1 = System.Windows.Media.Color.FromArgb(c1.A, c1.R, c1.G, c1.B);
                        FlickerDataGridView.Rows[e.RowIndex].Cells["color1"].Style.BackColor= colorPickerDialog.Color;
					}
				}
                onDataChanged(sender, e);
            }
			catch { }
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            System.Windows.Forms.KeyEventArgs e = new System.Windows.Forms.KeyEventArgs(keyData);
            SetText(labelTest, "Key pressed down");
            // Check if the pressed key combination matches a defined shortcut
            if (e.Control && e.KeyCode == Keys.N)
            {
                // The pressed key combination matches the Ctrl+N shortcut
                // Simulate a click on the "new" button
                btn_new.PerformClick();
				return true;
            }
            // Check if the pressed key combination matches a defined shortcut
            if (e.Control && e.KeyCode == Keys.S)
            {
                // The pressed key combination matches the Ctrl+S shortcut
                // Simulate a click on the save button
                btn_save.PerformClick();
				return true;
            }
			if (e.Control && e.KeyCode == Keys.C) { 
				CopyList.Clear();
				if(this.FlickerDataGridView.SelectedRows.Count > 0 && flickerBindingSource.Count>0) {
                    foreach (DataGridViewRow item in this.FlickerDataGridView.SelectedRows)
                    {
                        CopyList.Add(FlickerList[item.Index]);
                    }
					Clipboard.SetDataObject(CopyList); //add to clipboard but not used inside this code, useful if you want to send it to other people
                }
				
			}
            if (e.Control && e.KeyCode == Keys.V)
            {
                if(CopyList.Count > 0)
				{
					//FlickerList.AddRange(CopyList);
					foreach(Flicker f in CopyList) { flickerBindingSource.Add(f); }
				}
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

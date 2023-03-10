
using SDL2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Interface2App
{
    public class SequenceBlock : UserControl
    {
        public sequenceValue sequence;
        private TableLayoutPanel tableLayoutPanelHeader;
        private Button ButtonAdd;
        private Button ButtonRemove;
        private Label LabelSequenceBlock;
        private TableLayoutPanel tableLayoutPanelSubSequence;
        private TableLayoutPanel tableLayoutPanelCentral;
        private TableLayoutPanel tableLayoutPanelType;
        private Label labelType;
        private TableLayoutPanel tableLayoutPanelCondition;
        private Label labelCondition;
        private TableLayoutPanel tableLayoutPanelValue;
        private Label labelValue;
        private ComboBox comboBoxType;
        private ComboBox comboBoxCondition;
        private TextBox textBoxValue;
        private List<SequenceBlock> SubSequence = new List<SequenceBlock>();

        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.LabelSequenceBlock = new System.Windows.Forms.Label();
            this.tableLayoutPanelCentral = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelSubSequence = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelType = new System.Windows.Forms.TableLayoutPanel();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelCondition = new System.Windows.Forms.TableLayoutPanel();
            this.labelCondition = new System.Windows.Forms.Label();
            this.comboBoxCondition = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelValue = new System.Windows.Forms.TableLayoutPanel();
            this.labelValue = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.tableLayoutPanelCentral.SuspendLayout();
            this.tableLayoutPanelType.SuspendLayout();
            this.tableLayoutPanelCondition.SuspendLayout();
            this.tableLayoutPanelValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelHeader, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelCentral, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(409, 319);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelHeader.AutoSize = true;
            this.tableLayoutPanelHeader.ColumnCount = 3;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHeader.Controls.Add(this.ButtonAdd, 1, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.ButtonRemove, 2, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.LabelSequenceBlock, 0, 0);
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 1;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(403, 29);
            this.tableLayoutPanelHeader.TabIndex = 0;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.AutoSize = true;
            this.ButtonAdd.Location = new System.Drawing.Point(244, 3);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 0;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.AutoSize = true;
            this.ButtonRemove.Location = new System.Drawing.Point(325, 3);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(75, 23);
            this.ButtonRemove.TabIndex = 1;
            this.ButtonRemove.Text = "Delete";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // LabelSequenceBlock
            // 
            this.LabelSequenceBlock.AutoSize = true;
            this.LabelSequenceBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSequenceBlock.Location = new System.Drawing.Point(3, 0);
            this.LabelSequenceBlock.Name = "LabelSequenceBlock";
            this.LabelSequenceBlock.Size = new System.Drawing.Size(235, 29);
            this.LabelSequenceBlock.TabIndex = 2;
            this.LabelSequenceBlock.Text = "Sequence Block";
            this.LabelSequenceBlock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelCentral
            // 
            this.tableLayoutPanelCentral.ColumnCount = 1;
            this.tableLayoutPanelCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCentral.Controls.Add(this.tableLayoutPanelSubSequence, 0, 3);
            this.tableLayoutPanelCentral.Controls.Add(this.tableLayoutPanelType, 0, 0);
            this.tableLayoutPanelCentral.Controls.Add(this.tableLayoutPanelCondition, 0, 1);
            this.tableLayoutPanelCentral.Controls.Add(this.tableLayoutPanelValue, 0, 2);
            this.tableLayoutPanelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCentral.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanelCentral.Name = "tableLayoutPanelCentral";
            this.tableLayoutPanelCentral.RowCount = 4;
            this.tableLayoutPanelCentral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCentral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCentral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCentral.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCentral.Size = new System.Drawing.Size(403, 278);
            this.tableLayoutPanelCentral.TabIndex = 2;
            // 
            // tableLayoutPanelSubSequence
            // 
            this.tableLayoutPanelSubSequence.AutoSize = true;
            this.tableLayoutPanelSubSequence.ColumnCount = 1;
            this.tableLayoutPanelSubSequence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSubSequence.Location = new System.Drawing.Point(3, 101);
            this.tableLayoutPanelSubSequence.Name = "tableLayoutPanelSubSequence";
            this.tableLayoutPanelSubSequence.RowCount = 1;
            this.tableLayoutPanelSubSequence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSubSequence.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanelSubSequence.TabIndex = 1;
            // 
            // tableLayoutPanelType
            // 
            this.tableLayoutPanelType.AutoSize = true;
            this.tableLayoutPanelType.ColumnCount = 2;
            this.tableLayoutPanelType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelType.Controls.Add(this.labelType, 0, 0);
            this.tableLayoutPanelType.Controls.Add(this.comboBoxType, 1, 0);
            this.tableLayoutPanelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelType.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelType.Name = "tableLayoutPanelType";
            this.tableLayoutPanelType.RowCount = 1;
            this.tableLayoutPanelType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelType.Size = new System.Drawing.Size(397, 27);
            this.tableLayoutPanelType.TabIndex = 2;
            // 
            // labelType
            // 
            this.labelType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(3, 0);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(95, 27);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Type of Sequence";
            this.labelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DataSource = new Interface2App.sequenceValue.type[] {
        Interface2App.sequenceValue.type.Block,
        Interface2App.sequenceValue.type.Loop,
        Interface2App.sequenceValue.type.Active,
        Interface2App.sequenceValue.type.Inactive};
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(201, 3);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // tableLayoutPanelCondition
            // 
            this.tableLayoutPanelCondition.AutoSize = true;
            this.tableLayoutPanelCondition.ColumnCount = 2;
            this.tableLayoutPanelCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCondition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCondition.Controls.Add(this.labelCondition, 0, 0);
            this.tableLayoutPanelCondition.Controls.Add(this.comboBoxCondition, 1, 0);
            this.tableLayoutPanelCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCondition.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanelCondition.Name = "tableLayoutPanelCondition";
            this.tableLayoutPanelCondition.RowCount = 1;
            this.tableLayoutPanelCondition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCondition.Size = new System.Drawing.Size(397, 27);
            this.tableLayoutPanelCondition.TabIndex = 3;
            // 
            // labelCondition
            // 
            this.labelCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCondition.AutoSize = true;
            this.labelCondition.Location = new System.Drawing.Point(3, 0);
            this.labelCondition.Name = "labelCondition";
            this.labelCondition.Size = new System.Drawing.Size(148, 27);
            this.labelCondition.TabIndex = 0;
            this.labelCondition.Text = "Condition to move to the next Sequence";
            this.labelCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxCondition
            // 
            this.comboBoxCondition.DataSource = new Interface2App.sequenceValue.CondType[] {
        Interface2App.sequenceValue.CondType.KeyPress,
        Interface2App.sequenceValue.CondType.KeyPress,
        Interface2App.sequenceValue.CondType.KeyPress,
        Interface2App.sequenceValue.CondType.Always,
        Interface2App.sequenceValue.CondType.Always};
            this.comboBoxCondition.FormattingEnabled = true;
            this.comboBoxCondition.Location = new System.Drawing.Point(201, 3);
            this.comboBoxCondition.Name = "comboBoxCondition";
            this.comboBoxCondition.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCondition.TabIndex = 1;
            this.comboBoxCondition.SelectedIndexChanged += new System.EventHandler(this.comboBoxCondition_SelectedIndexChanged);
            // 
            // tableLayoutPanelValue
            // 
            this.tableLayoutPanelValue.AutoSize = true;
            this.tableLayoutPanelValue.ColumnCount = 2;
            this.tableLayoutPanelValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelValue.Controls.Add(this.labelValue, 0, 0);
            this.tableLayoutPanelValue.Controls.Add(this.textBoxValue, 1, 0);
            this.tableLayoutPanelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelValue.Location = new System.Drawing.Point(3, 69);
            this.tableLayoutPanelValue.Name = "tableLayoutPanelValue";
            this.tableLayoutPanelValue.RowCount = 1;
            this.tableLayoutPanelValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelValue.Size = new System.Drawing.Size(397, 26);
            this.tableLayoutPanelValue.TabIndex = 4;
            // 
            // labelValue
            // 
            this.labelValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(3, 0);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(186, 26);
            this.labelValue.TabIndex = 0;
            this.labelValue.Text = "Value to verify for the above condition";
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(201, 3);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(120, 20);
            this.textBoxValue.TabIndex = 1;
            this.textBoxValue.TextChanged += new System.EventHandler(this.textBoxValue_TextChanged);
            // 
            // SequenceBlock
            // 
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "SequenceBlock";
            this.Size = new System.Drawing.Size(409, 319);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.tableLayoutPanelCentral.ResumeLayout(false);
            this.tableLayoutPanelCentral.PerformLayout();
            this.tableLayoutPanelType.ResumeLayout(false);
            this.tableLayoutPanelType.PerformLayout();
            this.tableLayoutPanelCondition.ResumeLayout(false);
            this.tableLayoutPanelCondition.PerformLayout();
            this.tableLayoutPanelValue.ResumeLayout(false);
            this.tableLayoutPanelValue.PerformLayout();
            this.ResumeLayout(false);

        }

        private TableLayoutPanel tableLayoutPanelMain;
        public SequenceBlock(sequenceValue seq)
        {
            sequence = seq;
            InitializeComponent();


            comboBoxType.SelectedItem = sequence.Type;
            comboBoxCondition.SelectedItem = sequence.cond;
            foreach(sequenceValue s in sequence.contained_sequence)
            {
                Add(s);
            }

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }
        public void SetAsRoot(bool b)
        {
            ButtonRemove.Enabled = b;
        }
        public void SetAsRoot()
        {
            SetAsRoot(true);
        }
        public void Remove()
        {

            this.Parent.Controls.Remove(this);
            foreach(SequenceBlock sub in SubSequence)
            {
                sub.Remove();
                SubSequence.Remove(sub);
            }
            this.Dispose();
        }
        public void Add()
        {
            Add(new sequenceValue(sequenceValue.type.Block, sequenceValue.CondType.Never));
            
        }
        public void Add(sequenceValue seq)
        {
            var seqBlock = new SequenceBlock(seq);
            tableLayoutPanelSubSequence.RowCount++;
            tableLayoutPanelSubSequence.Controls.Add(seqBlock,tableLayoutPanelSubSequence.RowCount-1,0);
            SubSequence.Add(seqBlock);
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            sequence.Type = (sequenceValue.type) comboBoxType.SelectedItem;
        }

        private void comboBoxCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            sequence.cond = (sequenceValue.CondType) comboBoxCondition.SelectedItem;
        }

        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            if(sequence.cond == sequenceValue.CondType.Time)
            {
                var result = double.TryParse(textBoxValue.Text, out double value);
                if (result)
                {
                    sequence.value = value;
                }
            }
            if(sequence.cond == sequenceValue.CondType.KeyPress)
            {
                sequence.value=(double)SDL.SDL_GetKeyFromName(textBoxValue.Text);
            }
        }
    }
}
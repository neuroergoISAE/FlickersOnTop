namespace Interface2App
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			System.Windows.Forms.Label frequenceLabel;
			System.Windows.Forms.Label heightLabel;
			System.Windows.Forms.Label opacityLabel;
			System.Windows.Forms.Label phaseLabel;
			System.Windows.Forms.Label suplementLabel;
			System.Windows.Forms.Label typeLabel;
			System.Windows.Forms.Label widthLabel;
			System.Windows.Forms.Label xLabel;
			System.Windows.Forms.Label yLabel;
			this.button1 = new System.Windows.Forms.Button();
			this.red = new System.Windows.Forms.TrackBar();
			this.green = new System.Windows.Forms.TrackBar();
			this.blue = new System.Windows.Forms.TrackBar();
			this.pnl = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.warnted = new System.Windows.Forms.Label();
			this.bt_run = new System.Windows.Forms.Button();
			this.labelxPos = new System.Windows.Forms.Label();
			this.labelyPos = new System.Windows.Forms.Label();
			this.labelX = new System.Windows.Forms.Label();
			this.labelY = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.button_pre = new System.Windows.Forms.Button();
			this.button_help = new System.Windows.Forms.Button();
			this.frequenceTextBox = new System.Windows.Forms.TextBox();
			this.heightTextBox = new System.Windows.Forms.TextBox();
			this.opacityTextBox = new System.Windows.Forms.TextBox();
			this.phaseTextBox = new System.Windows.Forms.TextBox();
			this.suplementTextBox = new System.Windows.Forms.TextBox();
			this.typeTextBox = new System.Windows.Forms.TextBox();
			this.widthTextBox = new System.Windows.Forms.TextBox();
			this.xTextBox = new System.Windows.Forms.TextBox();
			this.yTextBox = new System.Windows.Forms.TextBox();
			this.btn_new = new System.Windows.Forms.Button();
			this.btn_save_imediatly = new System.Windows.Forms.Button();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.widthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.heightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.frequenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.opacityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.suplementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flickerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			frequenceLabel = new System.Windows.Forms.Label();
			heightLabel = new System.Windows.Forms.Label();
			opacityLabel = new System.Windows.Forms.Label();
			phaseLabel = new System.Windows.Forms.Label();
			suplementLabel = new System.Windows.Forms.Label();
			typeLabel = new System.Windows.Forms.Label();
			widthLabel = new System.Windows.Forms.Label();
			xLabel = new System.Windows.Forms.Label();
			yLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.flickerBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(38, 469);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(209, 69);
			this.button1.TabIndex = 15;
			this.button1.Text = "     Create File";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.bt_save);
			// 
			// red
			// 
			this.red.Location = new System.Drawing.Point(343, 397);
			this.red.Maximum = 255;
			this.red.Name = "red";
			this.red.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.red.RightToLeftLayout = true;
			this.red.Size = new System.Drawing.Size(230, 69);
			this.red.TabIndex = 12;
			this.red.Scroll += new System.EventHandler(this.bar_Scroll);
			// 
			// green
			// 
			this.green.Location = new System.Drawing.Point(343, 448);
			this.green.Maximum = 255;
			this.green.Name = "green";
			this.green.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.green.RightToLeftLayout = true;
			this.green.Size = new System.Drawing.Size(230, 69);
			this.green.TabIndex = 13;
			this.green.Scroll += new System.EventHandler(this.bar_Scroll);
			// 
			// blue
			// 
			this.blue.Location = new System.Drawing.Point(343, 497);
			this.blue.Maximum = 255;
			this.blue.Name = "blue";
			this.blue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.blue.RightToLeftLayout = true;
			this.blue.Size = new System.Drawing.Size(230, 69);
			this.blue.TabIndex = 14;
			this.blue.Scroll += new System.EventHandler(this.bar_Scroll);
			// 
			// pnl
			// 
			this.pnl.BackColor = System.Drawing.SystemColors.HighlightText;
			this.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl.Location = new System.Drawing.Point(625, 397);
			this.pnl.Name = "pnl";
			this.pnl.Size = new System.Drawing.Size(291, 159);
			this.pnl.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(311, 405);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(39, 20);
			this.label8.TabIndex = 18;
			this.label8.Text = "Red";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(296, 461);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(54, 20);
			this.label9.TabIndex = 19;
			this.label9.Text = "Green";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(309, 511);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 20);
			this.label10.TabIndex = 20;
			this.label10.Text = "Blue";
			// 
			// warnted
			// 
			this.warnted.AutoSize = true;
			this.warnted.Location = new System.Drawing.Point(100, 48);
			this.warnted.Name = "warnted";
			this.warnted.Size = new System.Drawing.Size(0, 20);
			this.warnted.TabIndex = 62;
			// 
			// bt_run
			// 
			this.bt_run.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bt_run.ForeColor = System.Drawing.Color.Red;
			this.bt_run.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bt_run.Location = new System.Drawing.Point(137, 309);
			this.bt_run.Name = "bt_run";
			this.bt_run.Size = new System.Drawing.Size(110, 67);
			this.bt_run.TabIndex = 16;
			this.bt_run.Text = "RUN";
			this.bt_run.UseVisualStyleBackColor = true;
			this.bt_run.Click += new System.EventHandler(this.bt_run_Click);
			// 
			// labelxPos
			// 
			this.labelxPos.AutoSize = true;
			this.labelxPos.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelxPos.Location = new System.Drawing.Point(1007, 448);
			this.labelxPos.Name = "labelxPos";
			this.labelxPos.Size = new System.Drawing.Size(31, 36);
			this.labelxPos.TabIndex = 70;
			this.labelxPos.Text = "X:";
			// 
			// labelyPos
			// 
			this.labelyPos.AutoSize = true;
			this.labelyPos.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelyPos.Location = new System.Drawing.Point(1008, 497);
			this.labelyPos.Name = "labelyPos";
			this.labelyPos.Size = new System.Drawing.Size(30, 36);
			this.labelyPos.TabIndex = 71;
			this.labelyPos.Text = "Y:";
			// 
			// labelX
			// 
			this.labelX.AutoSize = true;
			this.labelX.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelX.Location = new System.Drawing.Point(1053, 448);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(37, 36);
			this.labelX.TabIndex = 72;
			this.labelX.Text = "00";
			// 
			// labelY
			// 
			this.labelY.AutoSize = true;
			this.labelY.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelY.Location = new System.Drawing.Point(1053, 492);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(37, 36);
			this.labelY.TabIndex = 73;
			this.labelY.Text = "00";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label23.Location = new System.Drawing.Point(693, 360);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(147, 22);
			this.label23.TabIndex = 0;
			this.label23.Text = "Color of Flicker";
			// 
			// button_pre
			// 
			this.button_pre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_pre.ForeColor = System.Drawing.Color.OrangeRed;
			this.button_pre.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button_pre.Location = new System.Drawing.Point(38, 309);
			this.button_pre.Name = "button_pre";
			this.button_pre.Size = new System.Drawing.Size(93, 67);
			this.button_pre.TabIndex = 17;
			this.button_pre.Text = "PRE";
			this.button_pre.UseVisualStyleBackColor = true;
			this.button_pre.Click += new System.EventHandler(this.button_pre_Click);
			// 
			// button_help
			// 
			this.button_help.Cursor = System.Windows.Forms.Cursors.Help;
			this.button_help.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_help.Image = ((System.Drawing.Image)(resources.GetObject("button_help.Image")));
			this.button_help.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button_help.Location = new System.Drawing.Point(38, 397);
			this.button_help.Name = "button_help";
			this.button_help.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.button_help.Size = new System.Drawing.Size(209, 61);
			this.button_help.TabIndex = 0;
			this.button_help.Text = "   HELP";
			this.button_help.UseVisualStyleBackColor = true;
			this.button_help.Click += new System.EventHandler(this.button_help_Click);
			// 
			// frequenceLabel
			// 
			frequenceLabel.AutoSize = true;
			frequenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			frequenceLabel.Location = new System.Drawing.Point(10, 197);
			frequenceLabel.Name = "frequenceLabel";
			frequenceLabel.Size = new System.Drawing.Size(100, 20);
			frequenceLabel.TabIndex = 75;
			frequenceLabel.Text = "Frequence:";
			// 
			// frequenceTextBox
			// 
			this.frequenceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flickerBindingSource, "Frequence", true));
			this.frequenceTextBox.Location = new System.Drawing.Point(120, 194);
			this.frequenceTextBox.Name = "frequenceTextBox";
			this.frequenceTextBox.Size = new System.Drawing.Size(100, 26);
			this.frequenceTextBox.TabIndex = 5;
			// 
			// heightLabel
			// 
			heightLabel.AutoSize = true;
			heightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			heightLabel.Location = new System.Drawing.Point(10, 148);
			heightLabel.Name = "heightLabel";
			heightLabel.Size = new System.Drawing.Size(67, 20);
			heightLabel.TabIndex = 77;
			heightLabel.Text = "Height:";
			// 
			// heightTextBox
			// 
			this.heightTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flickerBindingSource, "Height", true));
			this.heightTextBox.Location = new System.Drawing.Point(120, 148);
			this.heightTextBox.Name = "heightTextBox";
			this.heightTextBox.Size = new System.Drawing.Size(100, 26);
			this.heightTextBox.TabIndex = 4;
			// 
			// opacityLabel
			// 
			opacityLabel.AutoSize = true;
			opacityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			opacityLabel.Location = new System.Drawing.Point(237, 67);
			opacityLabel.Name = "opacityLabel";
			opacityLabel.Size = new System.Drawing.Size(74, 20);
			opacityLabel.TabIndex = 79;
			opacityLabel.Text = "Opacity:";
			// 
			// opacityTextBox
			// 
			this.opacityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flickerBindingSource, "Opacity", true));
			this.opacityTextBox.Location = new System.Drawing.Point(343, 64);
			this.opacityTextBox.Name = "opacityTextBox";
			this.opacityTextBox.Size = new System.Drawing.Size(100, 26);
			this.opacityTextBox.TabIndex = 7;
			// 
			// phaseLabel
			// 
			phaseLabel.AutoSize = true;
			phaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			phaseLabel.Location = new System.Drawing.Point(237, 24);
			phaseLabel.Name = "phaseLabel";
			phaseLabel.Size = new System.Drawing.Size(64, 20);
			phaseLabel.TabIndex = 81;
			phaseLabel.Text = "Phase:";
			// 
			// phaseTextBox
			// 
			this.phaseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flickerBindingSource, "Phase", true));
			this.phaseTextBox.Location = new System.Drawing.Point(343, 24);
			this.phaseTextBox.Name = "phaseTextBox";
			this.phaseTextBox.Size = new System.Drawing.Size(100, 26);
			this.phaseTextBox.TabIndex = 6;
			// 
			// suplementLabel
			// 
			suplementLabel.AutoSize = true;
			suplementLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			suplementLabel.Location = new System.Drawing.Point(237, 146);
			suplementLabel.Name = "suplementLabel";
			suplementLabel.Size = new System.Drawing.Size(100, 20);
			suplementLabel.TabIndex = 83;
			suplementLabel.Text = "Suplement:";
			// 
			// suplementTextBox
			// 
			this.suplementTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flickerBindingSource, "Suplement", true));
			this.suplementTextBox.Location = new System.Drawing.Point(343, 145);
			this.suplementTextBox.Name = "suplementTextBox";
			this.suplementTextBox.Size = new System.Drawing.Size(100, 26);
			this.suplementTextBox.TabIndex = 9;
			// 
			// typeLabel
			// 
			typeLabel.AutoSize = true;
			typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			typeLabel.Location = new System.Drawing.Point(237, 109);
			typeLabel.Name = "typeLabel";
			typeLabel.Size = new System.Drawing.Size(52, 20);
			typeLabel.TabIndex = 85;
			typeLabel.Text = "Type:";
			// 
			// typeTextBox
			// 
			this.typeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flickerBindingSource, "Type", true));
			this.typeTextBox.Location = new System.Drawing.Point(343, 103);
			this.typeTextBox.Name = "typeTextBox";
			this.typeTextBox.Size = new System.Drawing.Size(100, 26);
			this.typeTextBox.TabIndex = 8;
			// 
			// widthLabel
			// 
			widthLabel.AutoSize = true;
			widthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			widthLabel.Location = new System.Drawing.Point(10, 106);
			widthLabel.Name = "widthLabel";
			widthLabel.Size = new System.Drawing.Size(60, 20);
			widthLabel.TabIndex = 87;
			widthLabel.Text = "Width:";
			// 
			// widthTextBox
			// 
			this.widthTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flickerBindingSource, "Width", true));
			this.widthTextBox.Location = new System.Drawing.Point(120, 106);
			this.widthTextBox.Name = "widthTextBox";
			this.widthTextBox.Size = new System.Drawing.Size(100, 26);
			this.widthTextBox.TabIndex = 3;
			// 
			// xLabel
			// 
			xLabel.AutoSize = true;
			xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			xLabel.Location = new System.Drawing.Point(10, 33);
			xLabel.Name = "xLabel";
			xLabel.Size = new System.Drawing.Size(26, 20);
			xLabel.TabIndex = 89;
			xLabel.Text = "X:";
			// 
			// xTextBox
			// 
			this.xTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flickerBindingSource, "X", true));
			this.xTextBox.Location = new System.Drawing.Point(120, 24);
			this.xTextBox.Name = "xTextBox";
			this.xTextBox.Size = new System.Drawing.Size(100, 26);
			this.xTextBox.TabIndex = 1;
			// 
			// yLabel
			// 
			yLabel.AutoSize = true;
			yLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			yLabel.Location = new System.Drawing.Point(10, 70);
			yLabel.Name = "yLabel";
			yLabel.Size = new System.Drawing.Size(26, 20);
			yLabel.TabIndex = 91;
			yLabel.Text = "Y:";
			// 
			// yTextBox
			// 
			this.yTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.flickerBindingSource, "Y", true));
			this.yTextBox.Location = new System.Drawing.Point(120, 64);
			this.yTextBox.Name = "yTextBox";
			this.yTextBox.Size = new System.Drawing.Size(100, 26);
			this.yTextBox.TabIndex = 2;
			// 
			// btn_new
			// 
			this.btn_new.Location = new System.Drawing.Point(1059, 335);
			this.btn_new.Name = "btn_new";
			this.btn_new.Size = new System.Drawing.Size(75, 47);
			this.btn_new.TabIndex = 10;
			this.btn_new.Text = "New";
			this.btn_new.UseVisualStyleBackColor = true;
			this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
			// 
			// btn_save_imediatly
			// 
			this.btn_save_imediatly.Location = new System.Drawing.Point(1144, 335);
			this.btn_save_imediatly.Name = "btn_save_imediatly";
			this.btn_save_imediatly.Size = new System.Drawing.Size(83, 47);
			this.btn_save_imediatly.TabIndex = 11;
			this.btn_save_imediatly.Text = "Save";
			this.btn_save_imediatly.UseVisualStyleBackColor = true;
			this.btn_save_imediatly.Click += new System.EventHandler(this.btn_save_imediatly_Click);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			this.errorProvider.DataSource = this.flickerBindingSource;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xDataGridViewTextBoxColumn,
            this.yDataGridViewTextBoxColumn,
            this.widthDataGridViewTextBoxColumn,
            this.heightDataGridViewTextBoxColumn,
            this.frequenceDataGridViewTextBoxColumn,
            this.phaseDataGridViewTextBoxColumn,
            this.opacityDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.suplementDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.flickerBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(503, 27);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 62;
			this.dataGridView1.RowTemplate.Height = 28;
			this.dataGridView1.Size = new System.Drawing.Size(724, 285);
			this.dataGridView1.TabIndex = 95;
			// 
			// xDataGridViewTextBoxColumn
			// 
			this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
			this.xDataGridViewTextBoxColumn.HeaderText = "X";
			this.xDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
			this.xDataGridViewTextBoxColumn.Width = 150;
			// 
			// yDataGridViewTextBoxColumn
			// 
			this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
			this.yDataGridViewTextBoxColumn.HeaderText = "Y";
			this.yDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
			this.yDataGridViewTextBoxColumn.Width = 150;
			// 
			// widthDataGridViewTextBoxColumn
			// 
			this.widthDataGridViewTextBoxColumn.DataPropertyName = "Width";
			this.widthDataGridViewTextBoxColumn.HeaderText = "Width";
			this.widthDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.widthDataGridViewTextBoxColumn.Name = "widthDataGridViewTextBoxColumn";
			this.widthDataGridViewTextBoxColumn.Width = 150;
			// 
			// heightDataGridViewTextBoxColumn
			// 
			this.heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
			this.heightDataGridViewTextBoxColumn.HeaderText = "Height";
			this.heightDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
			this.heightDataGridViewTextBoxColumn.Width = 150;
			// 
			// frequenceDataGridViewTextBoxColumn
			// 
			this.frequenceDataGridViewTextBoxColumn.DataPropertyName = "Frequence";
			this.frequenceDataGridViewTextBoxColumn.HeaderText = "Frequence";
			this.frequenceDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.frequenceDataGridViewTextBoxColumn.Name = "frequenceDataGridViewTextBoxColumn";
			this.frequenceDataGridViewTextBoxColumn.Width = 150;
			// 
			// phaseDataGridViewTextBoxColumn
			// 
			this.phaseDataGridViewTextBoxColumn.DataPropertyName = "Phase";
			this.phaseDataGridViewTextBoxColumn.HeaderText = "Phase";
			this.phaseDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.phaseDataGridViewTextBoxColumn.Name = "phaseDataGridViewTextBoxColumn";
			this.phaseDataGridViewTextBoxColumn.Width = 150;
			// 
			// opacityDataGridViewTextBoxColumn
			// 
			this.opacityDataGridViewTextBoxColumn.DataPropertyName = "Opacity";
			this.opacityDataGridViewTextBoxColumn.HeaderText = "Opacity";
			this.opacityDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.opacityDataGridViewTextBoxColumn.Name = "opacityDataGridViewTextBoxColumn";
			this.opacityDataGridViewTextBoxColumn.Width = 150;
			// 
			// typeDataGridViewTextBoxColumn
			// 
			this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
			this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
			this.typeDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
			this.typeDataGridViewTextBoxColumn.Width = 150;
			// 
			// suplementDataGridViewTextBoxColumn
			// 
			this.suplementDataGridViewTextBoxColumn.DataPropertyName = "Suplement";
			this.suplementDataGridViewTextBoxColumn.HeaderText = "Suplement";
			this.suplementDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.suplementDataGridViewTextBoxColumn.Name = "suplementDataGridViewTextBoxColumn";
			this.suplementDataGridViewTextBoxColumn.Width = 150;
			// 
			// flickerBindingSource
			// 
			this.flickerBindingSource.DataSource = typeof(Interface2App.Flicker);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.MenuBar;
			this.ClientSize = new System.Drawing.Size(1264, 590);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btn_save_imediatly);
			this.Controls.Add(this.btn_new);
			this.Controls.Add(frequenceLabel);
			this.Controls.Add(this.frequenceTextBox);
			this.Controls.Add(heightLabel);
			this.Controls.Add(this.heightTextBox);
			this.Controls.Add(opacityLabel);
			this.Controls.Add(this.opacityTextBox);
			this.Controls.Add(phaseLabel);
			this.Controls.Add(this.phaseTextBox);
			this.Controls.Add(suplementLabel);
			this.Controls.Add(this.suplementTextBox);
			this.Controls.Add(typeLabel);
			this.Controls.Add(this.typeTextBox);
			this.Controls.Add(widthLabel);
			this.Controls.Add(this.widthTextBox);
			this.Controls.Add(xLabel);
			this.Controls.Add(this.xTextBox);
			this.Controls.Add(yLabel);
			this.Controls.Add(this.yTextBox);
			this.Controls.Add(this.button_pre);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.labelY);
			this.Controls.Add(this.labelX);
			this.Controls.Add(this.labelyPos);
			this.Controls.Add(this.labelxPos);
			this.Controls.Add(this.bt_run);
			this.Controls.Add(this.warnted);
			this.Controls.Add(this.button_help);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.pnl);
			this.Controls.Add(this.blue);
			this.Controls.Add(this.green);
			this.Controls.Add(this.red);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FlickerOnTop";
			this.TransparencyKey = System.Drawing.Color.Linen;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.red)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.green)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.flickerBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TrackBar red;
		private System.Windows.Forms.TrackBar green;
		private System.Windows.Forms.TrackBar blue;
		private System.Windows.Forms.Panel pnl;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button button_help;
		private System.Windows.Forms.Label warnted;
		private System.Windows.Forms.Button bt_run;
		private System.Windows.Forms.Label labelY;
		private System.Windows.Forms.Label labelX;
		private System.Windows.Forms.Label labelyPos;
		private System.Windows.Forms.Label labelxPos;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Button button_pre;
		private System.Windows.Forms.TextBox frequenceTextBox;
		private System.Windows.Forms.BindingSource flickerBindingSource;
		private System.Windows.Forms.TextBox heightTextBox;
		private System.Windows.Forms.TextBox opacityTextBox;
		private System.Windows.Forms.TextBox phaseTextBox;
		private System.Windows.Forms.TextBox suplementTextBox;
		private System.Windows.Forms.TextBox typeTextBox;
		private System.Windows.Forms.TextBox widthTextBox;
		private System.Windows.Forms.TextBox xTextBox;
		private System.Windows.Forms.TextBox yTextBox;
		private System.Windows.Forms.Button btn_save_imediatly;
		private System.Windows.Forms.Button btn_new;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn widthDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn frequenceDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn phaseDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn opacityDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn suplementDataGridViewTextBoxColumn;
	}
}


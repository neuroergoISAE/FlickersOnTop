using System;

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
            this.warnted = new System.Windows.Forms.Label();
            this.bt_run = new System.Windows.Forms.Button();
            this.button_pre = new System.Windows.Forms.Button();
            this.button_help = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.flickerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FlickerDataGridView = new System.Windows.Forms.DataGridView();
            this.btn_delete = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTest = new System.Windows.Forms.Label();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.screenViewer1 = new Interface2App.ScreenViewer();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.NameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.widthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opacityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opacity2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flickerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlickerDataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // warnted
            // 
            this.warnted.AutoSize = true;
            this.warnted.Location = new System.Drawing.Point(67, 31);
            this.warnted.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.warnted.Name = "warnted";
            this.warnted.Size = new System.Drawing.Size(0, 13);
            this.warnted.TabIndex = 62;
            // 
            // bt_run
            // 
            this.bt_run.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_run.AutoSize = true;
            this.bt_run.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_run.ForeColor = System.Drawing.Color.Red;
            this.bt_run.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_run.Location = new System.Drawing.Point(77, 2);
            this.bt_run.Margin = new System.Windows.Forms.Padding(2);
            this.bt_run.Name = "bt_run";
            this.bt_run.Size = new System.Drawing.Size(71, 28);
            this.bt_run.TabIndex = 16;
            this.bt_run.Text = "RUN";
            this.bt_run.UseVisualStyleBackColor = true;
            this.bt_run.Click += new System.EventHandler(this.bt_run_Click);
            // 
            // button_pre
            // 
            this.button_pre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_pre.AutoSize = true;
            this.button_pre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pre.ForeColor = System.Drawing.Color.OrangeRed;
            this.button_pre.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_pre.Location = new System.Drawing.Point(2, 2);
            this.button_pre.Margin = new System.Windows.Forms.Padding(2);
            this.button_pre.Name = "button_pre";
            this.button_pre.Size = new System.Drawing.Size(71, 28);
            this.button_pre.TabIndex = 17;
            this.button_pre.Text = "PRE";
            this.button_pre.UseVisualStyleBackColor = true;
            this.button_pre.Click += new System.EventHandler(this.button_pre_Click);
            // 
            // button_help
            // 
            this.button_help.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_help.Cursor = System.Windows.Forms.Cursors.Help;
            this.button_help.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_help.Image = ((System.Drawing.Image)(resources.GetObject("button_help.Image")));
            this.button_help.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_help.Location = new System.Drawing.Point(2, 34);
            this.button_help.Margin = new System.Windows.Forms.Padding(2);
            this.button_help.Name = "button_help";
            this.button_help.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_help.Size = new System.Drawing.Size(146, 35);
            this.button_help.TabIndex = 0;
            this.button_help.Text = "   HELP";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(2, 2);
            this.btn_new.Margin = new System.Windows.Forms.Padding(2);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(50, 31);
            this.btn_new.TabIndex = 10;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_save.Location = new System.Drawing.Point(56, 2);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(69, 31);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.bt_save);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.flickerBindingSource;
            // 
            // flickerBindingSource
            // 
            this.flickerBindingSource.DataSource = typeof(Interface2App.Flicker);
            this.flickerBindingSource.CurrentChanged += new System.EventHandler(this.onDataChanged);
            // 
            // FlickerDataGridView
            // 
            this.FlickerDataGridView.AutoGenerateColumns = false;
            this.FlickerDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FlickerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FlickerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameDataGridViewTextBoxColumn,
            this.xDataGridViewTextBoxColumn,
            this.yDataGridViewTextBoxColumn,
            this.widthDataGridViewTextBoxColumn,
            this.heightDataGridViewTextBoxColumn,
            this.frequenceDataGridViewTextBoxColumn,
            this.phaseDataGridViewTextBoxColumn,
            this.opacityDataGridViewTextBoxColumn,
            this.Opacity2DataGridViewTextBoxColumn,
            this.color,
            this.typeDataGridViewComboBoxColumn});
            this.FlickerDataGridView.DataSource = this.flickerBindingSource;
            this.FlickerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlickerDataGridView.Location = new System.Drawing.Point(2, 2);
            this.FlickerDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.FlickerDataGridView.Name = "FlickerDataGridView";
            this.FlickerDataGridView.RowHeadersWidth = 62;
            this.FlickerDataGridView.RowTemplate.Height = 28;
            this.FlickerDataGridView.Size = new System.Drawing.Size(980, 194);
            this.FlickerDataGridView.TabIndex = 95;
            this.FlickerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FlickerDataGridCellContentClick);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(170, 2);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(56, 31);
            this.btn_delete.TabIndex = 97;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btn_new);
            this.flowLayoutPanel1.Controls.Add(this.btn_save);
            this.flowLayoutPanel1.Controls.Add(this.labelTest);
            this.flowLayoutPanel1.Controls.Add(this.btn_delete);
            this.flowLayoutPanel1.Controls.Add(this.buttonSaveAs);
            this.flowLayoutPanel1.Controls.Add(this.buttonImport);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 201);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(374, 35);
            this.flowLayoutPanel1.TabIndex = 99;
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(130, 0);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(35, 13);
            this.labelTest.TabIndex = 98;
            this.labelTest.Text = "label1";
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSaveAs.Location = new System.Drawing.Point(230, 2);
            this.buttonSaveAs.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(69, 31);
            this.buttonSaveAs.TabIndex = 99;
            this.buttonSaveAs.Text = "Save as...";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.bt_save_as);
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonImport.Location = new System.Drawing.Point(303, 2);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(69, 31);
            this.buttonImport.TabIndex = 100;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.btn_imp);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.FlickerDataGridView, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(273, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(984, 239);
            this.tableLayoutPanel5.TabIndex = 104;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.bt_run, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.button_pre, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(150, 32);
            this.tableLayoutPanel6.TabIndex = 105;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel9.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.screenViewer1, 1, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1089, 534);
            this.tableLayoutPanel9.TabIndex = 107;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.button_help, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(60, 384);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(60, 0, 60, 40);
            this.tableLayoutPanel10.MaximumSize = new System.Drawing.Size(150, 120);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(150, 71);
            this.tableLayoutPanel10.TabIndex = 107;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 4;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Location = new System.Drawing.Point(267, 242);
            this.tableLayoutPanel7.MaximumSize = new System.Drawing.Size(0, 200);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel7.TabIndex = 108;
            // 
            // screenViewer1
            // 
            this.screenViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenViewer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.screenViewer1.Location = new System.Drawing.Point(273, 248);
            this.screenViewer1.Name = "screenViewer1";
            this.screenViewer1.Size = new System.Drawing.Size(984, 244);
            this.screenViewer1.TabIndex = 109;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(91, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(8, 8);
            this.elementHost1.TabIndex = 108;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // NameDataGridViewTextBoxColumn
            // 
            this.NameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.NameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn";
            this.NameDataGridViewTextBoxColumn.ToolTipText = "Remove that flicker?";
            this.NameDataGridViewTextBoxColumn.Width = 60;
            // 
            // xDataGridViewTextBoxColumn
            // 
            this.xDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
            this.xDataGridViewTextBoxColumn.HeaderText = "X";
            this.xDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            this.xDataGridViewTextBoxColumn.Width = 39;
            // 
            // yDataGridViewTextBoxColumn
            // 
            this.yDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
            this.yDataGridViewTextBoxColumn.HeaderText = "Y";
            this.yDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
            this.yDataGridViewTextBoxColumn.Width = 39;
            // 
            // widthDataGridViewTextBoxColumn
            // 
            this.widthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.widthDataGridViewTextBoxColumn.DataPropertyName = "Width";
            this.widthDataGridViewTextBoxColumn.HeaderText = "Width";
            this.widthDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.widthDataGridViewTextBoxColumn.Name = "widthDataGridViewTextBoxColumn";
            this.widthDataGridViewTextBoxColumn.Width = 60;
            // 
            // heightDataGridViewTextBoxColumn
            // 
            this.heightDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
            this.heightDataGridViewTextBoxColumn.HeaderText = "Height";
            this.heightDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
            this.heightDataGridViewTextBoxColumn.Width = 63;
            // 
            // frequenceDataGridViewTextBoxColumn
            // 
            this.frequenceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.frequenceDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
            this.frequenceDataGridViewTextBoxColumn.HeaderText = "Frequency";
            this.frequenceDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.frequenceDataGridViewTextBoxColumn.Name = "frequenceDataGridViewTextBoxColumn";
            this.frequenceDataGridViewTextBoxColumn.Width = 82;
            // 
            // phaseDataGridViewTextBoxColumn
            // 
            this.phaseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phaseDataGridViewTextBoxColumn.DataPropertyName = "Phase";
            this.phaseDataGridViewTextBoxColumn.HeaderText = "Phase";
            this.phaseDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.phaseDataGridViewTextBoxColumn.Name = "phaseDataGridViewTextBoxColumn";
            // 
            // opacityDataGridViewTextBoxColumn
            // 
            this.opacityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.opacityDataGridViewTextBoxColumn.DataPropertyName = "Opacity_Min";
            this.opacityDataGridViewTextBoxColumn.HeaderText = "Opacity Min";
            this.opacityDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.opacityDataGridViewTextBoxColumn.Name = "opacityDataGridViewTextBoxColumn";
            this.opacityDataGridViewTextBoxColumn.ToolTipText = "Opacity of the flicker on screen";
            // 
            // Opacity2DataGridViewTextBoxColumn
            // 
            this.Opacity2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Opacity2DataGridViewTextBoxColumn.DataPropertyName = "Opacity_Max";
            this.Opacity2DataGridViewTextBoxColumn.HeaderText = "Opacity Max";
            this.Opacity2DataGridViewTextBoxColumn.Name = "Opacity2DataGridViewTextBoxColumn";
            this.Opacity2DataGridViewTextBoxColumn.ToolTipText = "Opacity of the flicker on screen";
            // 
            // color
            // 
            this.color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.color.DataPropertyName = "color1";
            this.color.HeaderText = "Color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.ToolTipText = "Flicker Color";
            // 
            // typeDataGridViewComboBoxColumn
            // 
            this.typeDataGridViewComboBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.typeDataGridViewComboBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewComboBoxColumn.DataSource = new Interface2App.Flicker.Signal_Type[] {
        Interface2App.Flicker.Signal_Type.Random,
        Interface2App.Flicker.Signal_Type.Sinuous,
        Interface2App.Flicker.Signal_Type.Square,
        Interface2App.Flicker.Signal_Type.Root_Square,
        Interface2App.Flicker.Signal_Type.Maximum_Lenght_Sequence};
            this.typeDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.typeDataGridViewComboBoxColumn.HeaderText = "Type";
            this.typeDataGridViewComboBoxColumn.Name = "typeDataGridViewComboBoxColumn";
            this.typeDataGridViewComboBoxColumn.ToolTipText = "Signal type for the Flicker";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1089, 534);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.tableLayoutPanel9);
            this.Controls.Add(this.warnted);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlickerOnTop";
            this.TransparencyKey = System.Drawing.Color.Linen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flickerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlickerDataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button_help;
		private System.Windows.Forms.Label warnted;
		private System.Windows.Forms.Button bt_run;
		private System.Windows.Forms.Button button_pre;
		private System.Windows.Forms.BindingSource flickerBindingSource;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_new;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.DataGridView FlickerDataGridView;
		private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private ScreenViewer screenViewer1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn widthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opacityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opacity2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeDataGridViewComboBoxColumn;
    }
}


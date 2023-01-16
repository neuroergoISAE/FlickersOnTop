using System;
using System.Drawing;

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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.screenViewer1 = new Interface2App.ScreenViewer();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
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
            this.ImageCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.typeDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Sequence = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flickerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlickerDataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.button_pre.Text = "TEST";
            this.button_pre.UseVisualStyleBackColor = true;
            this.button_pre.Click += new System.EventHandler(this.button_test_Click);
            // 
            // button_help
            // 
            this.button_help.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_help.Cursor = System.Windows.Forms.Cursors.Help;
            this.button_help.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_help.Image = ((System.Drawing.Image)(resources.GetObject("button_help.Image")));
            this.button_help.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_help.Location = new System.Drawing.Point(2, 139);
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
            this.btn_save.AutoSize = true;
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_save.Location = new System.Drawing.Point(2, 34);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(146, 31);
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
            this.flickerBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.flickerBindingSource_ListChanged);
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
            this.ImageCheckBox,
            this.typeDataGridViewComboBoxColumn,
            this.Sequence});
            this.FlickerDataGridView.DataSource = this.flickerBindingSource;
            this.FlickerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlickerDataGridView.Location = new System.Drawing.Point(2, 2);
            this.FlickerDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.FlickerDataGridView.Name = "FlickerDataGridView";
            this.FlickerDataGridView.RowHeadersWidth = 100;
            this.FlickerDataGridView.RowTemplate.Height = 28;
            this.FlickerDataGridView.Size = new System.Drawing.Size(1079, 194);
            this.FlickerDataGridView.TabIndex = 95;
            this.FlickerDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FlickerDataGridCellContentClick);
            this.FlickerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FlickerDataGridCellContentClick);
            this.FlickerDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.FlickerDataGridView_RowsRemoved);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(56, 2);
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
            this.flowLayoutPanel1.Controls.Add(this.btn_delete);
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 201);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(369, 34);
            this.flowLayoutPanel1.TabIndex = 99;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(117, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(249, 17);
            this.checkBox1.TabIndex = 98;
            this.checkBox1.Text = "Add a Black Screen Background when running";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveAs.Location = new System.Drawing.Point(2, 69);
            this.buttonSaveAs.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(146, 31);
            this.buttonSaveAs.TabIndex = 99;
            this.buttonSaveAs.Text = "Save as...";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.bt_save_as);
            // 
            // buttonImport
            // 
            this.buttonImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonImport.Location = new System.Drawing.Point(2, 104);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(146, 31);
            this.buttonImport.TabIndex = 100;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.btn_imp);
            // 
            // labelTest
            // 
            this.labelTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(3, 498);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(0, 40);
            this.labelTest.TabIndex = 98;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.FlickerDataGridView, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1083, 238);
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
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.btn_save, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.buttonImport, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.buttonSaveAs, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.button_help, 0, 4);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(33, 33);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(30);
            this.tableLayoutPanel10.MaximumSize = new System.Drawing.Size(150, 176);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 5;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(150, 176);
            this.tableLayoutPanel10.TabIndex = 107;
            // 
            // screenViewer1
            // 
            this.screenViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenViewer1.BackColor = System.Drawing.Color.Transparent;
            this.screenViewer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("screenViewer1.BackgroundImage")));
            this.screenViewer1.Location = new System.Drawing.Point(50, 5);
            this.screenViewer1.Margin = new System.Windows.Forms.Padding(50, 5, 40, 5);
            this.screenViewer1.MaximumSize = new System.Drawing.Size(384, 9999);
            this.screenViewer1.Name = "screenViewer1";
            this.screenViewer1.Size = new System.Drawing.Size(384, 226);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTest, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(922, 520);
            this.tableLayoutPanel1.TabIndex = 109;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 247);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1083, 248);
            this.tableLayoutPanel2.TabIndex = 105;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.screenViewer1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(219, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(568, 236);
            this.tableLayoutPanel3.TabIndex = 110;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelX, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelY, 0, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(477, 194);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(88, 39);
            this.tableLayoutPanel4.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mouse Position:";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(3, 13);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(0, 13);
            this.labelX.TabIndex = 1;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(3, 26);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(0, 13);
            this.labelY.TabIndex = 2;
            // 
            // NameDataGridViewTextBoxColumn
            // 
            this.NameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.NameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn";
            this.NameDataGridViewTextBoxColumn.ToolTipText = "Name of the Flicker";
            this.NameDataGridViewTextBoxColumn.Width = 60;
            // 
            // xDataGridViewTextBoxColumn
            // 
            this.xDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
            this.xDataGridViewTextBoxColumn.HeaderText = "X";
            this.xDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            this.xDataGridViewTextBoxColumn.ToolTipText = "Top-left X coordinate";
            this.xDataGridViewTextBoxColumn.Width = 39;
            // 
            // yDataGridViewTextBoxColumn
            // 
            this.yDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
            this.yDataGridViewTextBoxColumn.HeaderText = "Y";
            this.yDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
            this.yDataGridViewTextBoxColumn.ToolTipText = "Top-left Y Coordinate";
            this.yDataGridViewTextBoxColumn.Width = 39;
            // 
            // widthDataGridViewTextBoxColumn
            // 
            this.widthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.widthDataGridViewTextBoxColumn.DataPropertyName = "Width";
            this.widthDataGridViewTextBoxColumn.HeaderText = "Width";
            this.widthDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.widthDataGridViewTextBoxColumn.Name = "widthDataGridViewTextBoxColumn";
            this.widthDataGridViewTextBoxColumn.ToolTipText = "Width of the Flicker";
            this.widthDataGridViewTextBoxColumn.Width = 60;
            // 
            // heightDataGridViewTextBoxColumn
            // 
            this.heightDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
            this.heightDataGridViewTextBoxColumn.HeaderText = "Height";
            this.heightDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
            this.heightDataGridViewTextBoxColumn.ToolTipText = "Height of the Flicker";
            this.heightDataGridViewTextBoxColumn.Width = 63;
            // 
            // frequenceDataGridViewTextBoxColumn
            // 
            this.frequenceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.frequenceDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
            this.frequenceDataGridViewTextBoxColumn.HeaderText = "Frequency";
            this.frequenceDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.frequenceDataGridViewTextBoxColumn.Name = "frequenceDataGridViewTextBoxColumn";
            this.frequenceDataGridViewTextBoxColumn.ToolTipText = "Frequency of the Flicker";
            this.frequenceDataGridViewTextBoxColumn.Width = 82;
            // 
            // phaseDataGridViewTextBoxColumn
            // 
            this.phaseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phaseDataGridViewTextBoxColumn.DataPropertyName = "Phase";
            this.phaseDataGridViewTextBoxColumn.HeaderText = "Phase";
            this.phaseDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.phaseDataGridViewTextBoxColumn.Name = "phaseDataGridViewTextBoxColumn";
            this.phaseDataGridViewTextBoxColumn.ToolTipText = "Phase of the Flicker";
            // 
            // opacityDataGridViewTextBoxColumn
            // 
            this.opacityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.opacityDataGridViewTextBoxColumn.DataPropertyName = "Opacity_Min";
            this.opacityDataGridViewTextBoxColumn.HeaderText = "Opacity Min";
            this.opacityDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.opacityDataGridViewTextBoxColumn.Name = "opacityDataGridViewTextBoxColumn";
            this.opacityDataGridViewTextBoxColumn.ToolTipText = "Minimum Opacity during a cycle";
            // 
            // Opacity2DataGridViewTextBoxColumn
            // 
            this.Opacity2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Opacity2DataGridViewTextBoxColumn.DataPropertyName = "Opacity_Max";
            this.Opacity2DataGridViewTextBoxColumn.HeaderText = "Opacity Max";
            this.Opacity2DataGridViewTextBoxColumn.Name = "Opacity2DataGridViewTextBoxColumn";
            this.Opacity2DataGridViewTextBoxColumn.ToolTipText = "Maximum Opacity during a cycle";
            // 
            // color
            // 
            this.color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.color.HeaderText = "Texture";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.color.ToolTipText = "Flicker Color or Image, click to choose the color or image file. Image can only b" +
    "e in .bmp format!!";
            // 
            // ImageCheckBox
            // 
            this.ImageCheckBox.DataPropertyName = "IsImageFlicker";
            this.ImageCheckBox.FalseValue = "false";
            this.ImageCheckBox.HeaderText = "Image Flicker?";
            this.ImageCheckBox.Name = "ImageCheckBox";
            this.ImageCheckBox.ToolTipText = "Does that Flicker use an Image?";
            this.ImageCheckBox.TrueValue = "true";
            // 
            // typeDataGridViewComboBoxColumn
            // 
            this.typeDataGridViewComboBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.typeDataGridViewComboBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewComboBoxColumn.DataSource = new Interface2App.Flicker.Signal_Type[] {
        Interface2App.Flicker.Signal_Type.Random,
        Interface2App.Flicker.Signal_Type.Sine,
        Interface2App.Flicker.Signal_Type.Square,
        Interface2App.Flicker.Signal_Type.Root_Square,
        Interface2App.Flicker.Signal_Type.Maximum_Lenght_Sequence,
        Interface2App.Flicker.Signal_Type.None};
            this.typeDataGridViewComboBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.typeDataGridViewComboBoxColumn.HeaderText = "Type";
            this.typeDataGridViewComboBoxColumn.Name = "typeDataGridViewComboBoxColumn";
            this.typeDataGridViewComboBoxColumn.ToolTipText = "Signal type for the Flicker";
            // 
            // Sequence
            // 
            this.Sequence.HeaderText = "Sequencing";
            this.Sequence.Name = "Sequence";
            this.Sequence.ReadOnly = true;
            this.Sequence.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(922, 520);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.warnted);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlickerOnTop";
            this.TransparencyKey = System.Drawing.Color.Linen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flickerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlickerDataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private ScreenViewer screenViewer1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImageCheckBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Sequence;
    }
}


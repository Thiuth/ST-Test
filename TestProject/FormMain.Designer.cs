namespace TestProject
{
	partial class FormMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.MsMain = new System.Windows.Forms.MenuStrip();
			this.MiFile = new System.Windows.Forms.ToolStripMenuItem();
			this.MiNew = new System.Windows.Forms.ToolStripMenuItem();
			this.MiConnect = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
			this.GbSideMenu = new System.Windows.Forms.GroupBox();
			this.BtnDeleteRecord = new System.Windows.Forms.Button();
			this.BtnEditRecord = new System.Windows.Forms.Button();
			this.BtnAddRecord = new System.Windows.Forms.Button();
			this.LvMain = new System.Windows.Forms.ListView();
			this.ColumnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnRecDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColumnBaseSalary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ColummnRealSalary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.BtnGetCurrentDate = new System.Windows.Forms.Button();
			this.DpSetDate = new System.Windows.Forms.DateTimePicker();
			this.LblSetDate = new System.Windows.Forms.Label();
			this.MsMain.SuspendLayout();
			this.GbSideMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// MsMain
			// 
			this.MsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiFile});
			this.MsMain.Location = new System.Drawing.Point(0, 0);
			this.MsMain.Name = "MsMain";
			this.MsMain.Size = new System.Drawing.Size(784, 24);
			this.MsMain.TabIndex = 0;
			this.MsMain.Text = "menuStrip1";
			// 
			// MiFile
			// 
			this.MiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiNew,
            this.MiConnect,
            this.toolStripSeparator1,
            this.MiExit});
			this.MiFile.Name = "MiFile";
			this.MiFile.Size = new System.Drawing.Size(48, 20);
			this.MiFile.Text = "Файл";
			// 
			// MiNew
			// 
			this.MiNew.Name = "MiNew";
			this.MiNew.Size = new System.Drawing.Size(174, 22);
			this.MiNew.Text = "Создать новую БД";
			this.MiNew.Click += new System.EventHandler(this.MiNew_Click);
			// 
			// MiConnect
			// 
			this.MiConnect.Name = "MiConnect";
			this.MiConnect.Size = new System.Drawing.Size(174, 22);
			this.MiConnect.Text = "Подключить БД";
			this.MiConnect.Click += new System.EventHandler(this.MiConnect_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
			// 
			// MiExit
			// 
			this.MiExit.Name = "MiExit";
			this.MiExit.Size = new System.Drawing.Size(174, 22);
			this.MiExit.Text = "Выход";
			this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
			// 
			// GbSideMenu
			// 
			this.GbSideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GbSideMenu.Controls.Add(this.BtnDeleteRecord);
			this.GbSideMenu.Controls.Add(this.BtnEditRecord);
			this.GbSideMenu.Controls.Add(this.BtnAddRecord);
			this.GbSideMenu.Location = new System.Drawing.Point(572, 28);
			this.GbSideMenu.Name = "GbSideMenu";
			this.GbSideMenu.Size = new System.Drawing.Size(200, 521);
			this.GbSideMenu.TabIndex = 1;
			this.GbSideMenu.TabStop = false;
			this.GbSideMenu.Text = "Меню";
			// 
			// BtnDeleteRecord
			// 
			this.BtnDeleteRecord.Location = new System.Drawing.Point(7, 92);
			this.BtnDeleteRecord.Name = "BtnDeleteRecord";
			this.BtnDeleteRecord.Size = new System.Drawing.Size(187, 30);
			this.BtnDeleteRecord.TabIndex = 0;
			this.BtnDeleteRecord.Text = "Удалить запись";
			this.BtnDeleteRecord.UseVisualStyleBackColor = true;
			this.BtnDeleteRecord.Click += new System.EventHandler(this.BtnDeleteRecord_Click);
			// 
			// BtnEditRecord
			// 
			this.BtnEditRecord.Location = new System.Drawing.Point(7, 56);
			this.BtnEditRecord.Name = "BtnEditRecord";
			this.BtnEditRecord.Size = new System.Drawing.Size(187, 30);
			this.BtnEditRecord.TabIndex = 0;
			this.BtnEditRecord.Text = "Изменить запись";
			this.BtnEditRecord.UseVisualStyleBackColor = true;
			this.BtnEditRecord.Click += new System.EventHandler(this.BtnEditRecord_Click);
			// 
			// BtnAddRecord
			// 
			this.BtnAddRecord.Location = new System.Drawing.Point(7, 20);
			this.BtnAddRecord.Name = "BtnAddRecord";
			this.BtnAddRecord.Size = new System.Drawing.Size(187, 30);
			this.BtnAddRecord.TabIndex = 0;
			this.BtnAddRecord.Text = "Добавить запись";
			this.BtnAddRecord.UseVisualStyleBackColor = true;
			this.BtnAddRecord.Click += new System.EventHandler(this.BtnAddRecord_Click);
			// 
			// LvMain
			// 
			this.LvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnGroup,
            this.ColumnHead,
            this.ColumnRecDate,
            this.ColumnBaseSalary,
            this.ColummnRealSalary});
			this.LvMain.FullRowSelect = true;
			this.LvMain.GridLines = true;
			this.LvMain.Location = new System.Drawing.Point(12, 28);
			this.LvMain.MultiSelect = false;
			this.LvMain.Name = "LvMain";
			this.LvMain.Size = new System.Drawing.Size(554, 492);
			this.LvMain.TabIndex = 2;
			this.LvMain.UseCompatibleStateImageBehavior = false;
			this.LvMain.View = System.Windows.Forms.View.Details;
			// 
			// ColumnId
			// 
			this.ColumnId.Text = "ID";
			this.ColumnId.Width = 25;
			// 
			// ColumnName
			// 
			this.ColumnName.Text = "Имя";
			this.ColumnName.Width = 34;
			// 
			// ColumnGroup
			// 
			this.ColumnGroup.Text = "Группа";
			this.ColumnGroup.Width = 47;
			// 
			// ColumnHead
			// 
			this.ColumnHead.Text = "Начальник";
			this.ColumnHead.Width = 67;
			// 
			// ColumnRecDate
			// 
			this.ColumnRecDate.Text = "Дата поступления";
			this.ColumnRecDate.Width = 105;
			// 
			// ColumnBaseSalary
			// 
			this.ColumnBaseSalary.Text = "Базовая ставка з/п";
			this.ColumnBaseSalary.Width = 113;
			// 
			// ColummnRealSalary
			// 
			this.ColummnRealSalary.Text = "Реальная з/п";
			this.ColummnRealSalary.Width = 159;
			// 
			// BtnGetCurrentDate
			// 
			this.BtnGetCurrentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnGetCurrentDate.Location = new System.Drawing.Point(466, 526);
			this.BtnGetCurrentDate.Name = "BtnGetCurrentDate";
			this.BtnGetCurrentDate.Size = new System.Drawing.Size(100, 23);
			this.BtnGetCurrentDate.TabIndex = 3;
			this.BtnGetCurrentDate.Text = "Текущая дата";
			this.BtnGetCurrentDate.UseVisualStyleBackColor = true;
			this.BtnGetCurrentDate.Click += new System.EventHandler(this.BtnGetCurrentDate_Click);
			// 
			// DpSetDate
			// 
			this.DpSetDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DpSetDate.Location = new System.Drawing.Point(135, 529);
			this.DpSetDate.Name = "DpSetDate";
			this.DpSetDate.Size = new System.Drawing.Size(325, 20);
			this.DpSetDate.TabIndex = 4;
			this.DpSetDate.ValueChanged += new System.EventHandler(this.DpSetDate_ValueChanged);
			// 
			// LblSetDate
			// 
			this.LblSetDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblSetDate.AutoSize = true;
			this.LblSetDate.Location = new System.Drawing.Point(12, 531);
			this.LblSetDate.Name = "LblSetDate";
			this.LblSetDate.Size = new System.Drawing.Size(117, 13);
			this.LblSetDate.TabIndex = 5;
			this.LblSetDate.Text = "Дата для расчета з/п";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.LblSetDate);
			this.Controls.Add(this.DpSetDate);
			this.Controls.Add(this.BtnGetCurrentDate);
			this.Controls.Add(this.LvMain);
			this.Controls.Add(this.GbSideMenu);
			this.Controls.Add(this.MsMain);
			this.MainMenuStrip = this.MsMain;
			this.MinimumSize = new System.Drawing.Size(640, 480);
			this.Name = "FormMain";
			this.Text = "Расчет зарплат";
			this.MsMain.ResumeLayout(false);
			this.MsMain.PerformLayout();
			this.GbSideMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MsMain;
		private System.Windows.Forms.ToolStripMenuItem MiFile;
		private System.Windows.Forms.ToolStripMenuItem MiNew;
		private System.Windows.Forms.ToolStripMenuItem MiConnect;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem MiExit;
		private System.Windows.Forms.GroupBox GbSideMenu;
		private System.Windows.Forms.Button BtnDeleteRecord;
		private System.Windows.Forms.Button BtnEditRecord;
		private System.Windows.Forms.Button BtnAddRecord;
		private System.Windows.Forms.ListView LvMain;
		private System.Windows.Forms.ColumnHeader ColumnId;
		private System.Windows.Forms.ColumnHeader ColumnName;
		private System.Windows.Forms.ColumnHeader ColumnGroup;
		private System.Windows.Forms.ColumnHeader ColumnHead;
		private System.Windows.Forms.ColumnHeader ColumnRecDate;
		private System.Windows.Forms.ColumnHeader ColumnBaseSalary;
		private System.Windows.Forms.ColumnHeader ColummnRealSalary;
		private System.Windows.Forms.Button BtnGetCurrentDate;
		private System.Windows.Forms.DateTimePicker DpSetDate;
		private System.Windows.Forms.Label LblSetDate;
	}
}


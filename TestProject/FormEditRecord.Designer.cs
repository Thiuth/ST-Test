namespace TestProject
{
	partial class FormEditRecord
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
			this.BtnAddRecord = new System.Windows.Forms.Button();
			this.TpLayout = new System.Windows.Forms.TableLayoutPanel();
			this.TbName = new System.Windows.Forms.TextBox();
			this.TbBaseSalary = new System.Windows.Forms.TextBox();
			this.CbGroup = new System.Windows.Forms.ComboBox();
			this.DpRecDate = new System.Windows.Forms.DateTimePicker();
			this.CbHead = new System.Windows.Forms.ComboBox();
			this.LblName = new System.Windows.Forms.Label();
			this.LblGroup = new System.Windows.Forms.Label();
			this.LblRecDate = new System.Windows.Forms.Label();
			this.LblBaseSalary = new System.Windows.Forms.Label();
			this.LblHead = new System.Windows.Forms.Label();
			this.TpLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnAddRecord
			// 
			this.BtnAddRecord.Location = new System.Drawing.Point(12, 150);
			this.BtnAddRecord.Name = "BtnAddRecord";
			this.BtnAddRecord.Size = new System.Drawing.Size(600, 30);
			this.BtnAddRecord.TabIndex = 10;
			this.BtnAddRecord.Text = "Применить изменения";
			this.BtnAddRecord.UseVisualStyleBackColor = true;
			this.BtnAddRecord.Click += new System.EventHandler(this.BtnAddRecord_Click);
			// 
			// TpLayout
			// 
			this.TpLayout.ColumnCount = 2;
			this.TpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.TpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
			this.TpLayout.Controls.Add(this.TbName, 1, 0);
			this.TpLayout.Controls.Add(this.TbBaseSalary, 1, 4);
			this.TpLayout.Controls.Add(this.CbGroup, 1, 1);
			this.TpLayout.Controls.Add(this.DpRecDate, 1, 3);
			this.TpLayout.Controls.Add(this.CbHead, 1, 2);
			this.TpLayout.Controls.Add(this.LblName, 0, 0);
			this.TpLayout.Controls.Add(this.LblGroup, 0, 1);
			this.TpLayout.Controls.Add(this.LblRecDate, 0, 3);
			this.TpLayout.Controls.Add(this.LblBaseSalary, 0, 4);
			this.TpLayout.Controls.Add(this.LblHead, 0, 2);
			this.TpLayout.Location = new System.Drawing.Point(12, 12);
			this.TpLayout.Name = "TpLayout";
			this.TpLayout.RowCount = 5;
			this.TpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.TpLayout.Size = new System.Drawing.Size(600, 130);
			this.TpLayout.TabIndex = 9;
			// 
			// TbName
			// 
			this.TbName.Location = new System.Drawing.Point(213, 3);
			this.TbName.Name = "TbName";
			this.TbName.Size = new System.Drawing.Size(384, 20);
			this.TbName.TabIndex = 0;
			// 
			// TbBaseSalary
			// 
			this.TbBaseSalary.Location = new System.Drawing.Point(213, 107);
			this.TbBaseSalary.Name = "TbBaseSalary";
			this.TbBaseSalary.Size = new System.Drawing.Size(384, 20);
			this.TbBaseSalary.TabIndex = 3;
			// 
			// CbGroup
			// 
			this.CbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbGroup.FormattingEnabled = true;
			this.CbGroup.Items.AddRange(new object[] {
            "Employee",
            "Manager",
            "Salesman"});
			this.CbGroup.Location = new System.Drawing.Point(213, 29);
			this.CbGroup.Name = "CbGroup";
			this.CbGroup.Size = new System.Drawing.Size(384, 21);
			this.CbGroup.TabIndex = 1;
			// 
			// DpRecDate
			// 
			this.DpRecDate.Location = new System.Drawing.Point(213, 81);
			this.DpRecDate.Name = "DpRecDate";
			this.DpRecDate.Size = new System.Drawing.Size(384, 20);
			this.DpRecDate.TabIndex = 2;
			// 
			// CbHead
			// 
			this.CbHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbHead.FormattingEnabled = true;
			this.CbHead.Items.AddRange(new object[] {
            "Нет"});
			this.CbHead.Location = new System.Drawing.Point(213, 55);
			this.CbHead.Name = "CbHead";
			this.CbHead.Size = new System.Drawing.Size(384, 21);
			this.CbHead.TabIndex = 1;
			// 
			// LblName
			// 
			this.LblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.LblName.AutoSize = true;
			this.LblName.Location = new System.Drawing.Point(3, 6);
			this.LblName.Name = "LblName";
			this.LblName.Size = new System.Drawing.Size(29, 13);
			this.LblName.TabIndex = 4;
			this.LblName.Text = "Имя";
			// 
			// LblGroup
			// 
			this.LblGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.LblGroup.AutoSize = true;
			this.LblGroup.Location = new System.Drawing.Point(3, 32);
			this.LblGroup.Name = "LblGroup";
			this.LblGroup.Size = new System.Drawing.Size(42, 13);
			this.LblGroup.TabIndex = 4;
			this.LblGroup.Text = "Группа";
			// 
			// LblRecDate
			// 
			this.LblRecDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.LblRecDate.AutoSize = true;
			this.LblRecDate.Location = new System.Drawing.Point(3, 84);
			this.LblRecDate.Name = "LblRecDate";
			this.LblRecDate.Size = new System.Drawing.Size(152, 13);
			this.LblRecDate.TabIndex = 4;
			this.LblRecDate.Text = "Дата поступления на работу";
			// 
			// LblBaseSalary
			// 
			this.LblBaseSalary.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.LblBaseSalary.AutoSize = true;
			this.LblBaseSalary.Location = new System.Drawing.Point(3, 110);
			this.LblBaseSalary.Name = "LblBaseSalary";
			this.LblBaseSalary.Size = new System.Drawing.Size(108, 13);
			this.LblBaseSalary.TabIndex = 4;
			this.LblBaseSalary.Text = "Базовая ставка з/п";
			// 
			// LblHead
			// 
			this.LblHead.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.LblHead.AutoSize = true;
			this.LblHead.Location = new System.Drawing.Point(3, 58);
			this.LblHead.Name = "LblHead";
			this.LblHead.Size = new System.Drawing.Size(62, 13);
			this.LblHead.TabIndex = 4;
			this.LblHead.Text = "Начальник";
			// 
			// FormEditRecord
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 192);
			this.Controls.Add(this.BtnAddRecord);
			this.Controls.Add(this.TpLayout);
			this.Name = "FormEditRecord";
			this.Text = "Изменение записи";
			this.Load += new System.EventHandler(this.FormEditRecord_Load);
			this.TpLayout.ResumeLayout(false);
			this.TpLayout.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button BtnAddRecord;
		private System.Windows.Forms.TableLayoutPanel TpLayout;
		private System.Windows.Forms.TextBox TbName;
		private System.Windows.Forms.TextBox TbBaseSalary;
		private System.Windows.Forms.ComboBox CbGroup;
		private System.Windows.Forms.DateTimePicker DpRecDate;
		private System.Windows.Forms.ComboBox CbHead;
		private System.Windows.Forms.Label LblName;
		private System.Windows.Forms.Label LblGroup;
		private System.Windows.Forms.Label LblRecDate;
		private System.Windows.Forms.Label LblBaseSalary;
		private System.Windows.Forms.Label LblHead;
	}
}
using System;
using System.Windows.Forms;
using TestProject.Models;
using TestProject.Presentation;
using TestProject.UI;
using TestProject.FileService;
using System.IO;

namespace TestProject
{
	public partial class FormMain : Form, IVMain
	{
		private IPrMain Presenter { get; set; }
		private IFileDialogs FileDlgs { get; set; }
		public FormMain()
		{
			InitializeComponent();
			DisableSideMenu();
			Presenter = new PrMain(this, new MainModel());
			FileDlgs = new FileDialogs();
		}

		/// <summary>
		/// Активирует кнопки сбоку окна
		/// </summary>
		public void EnableSideMenu()
		{
			BtnAddRecord.Enabled = true;
			BtnEditRecord.Enabled = true;
			BtnDeleteRecord.Enabled = true;
		}

		/// <summary>
		/// Деактивирует кнопки сбоку окна
		/// </summary>
		public void DisableSideMenu()
		{
			BtnAddRecord.Enabled = false;
			BtnEditRecord.Enabled = false;
			BtnDeleteRecord.Enabled = false;
		}

		/// <summary>
		/// Заполняет таблицу в главном окне
		/// </summary>
		public void UpdateListView(string[,] table)
		{
			LvMain.Items.Clear();
			ListViewItem item;
			for (var i = 0; i < table.GetLength(1); i++)
			{
				var itemString = new string[7];
				for (int j = 0; j < itemString.Length; j++)
				{
					itemString[j] = table[j, i];
				}
				item = new ListViewItem(itemString);
				LvMain.Items.Add(item);
			}
			LvMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		/// <summary>
		/// Получает ID выделенной записи
		/// </summary>
		public int GetSelectedId()
		{
			var selected = LvMain.SelectedItems[0];
			return Convert.ToInt32(selected.SubItems[0].Text);
		}

		public void SetDatePickerValue(DateTime date)
		{
			DpSetDate.Value = date;
		}

		//	Обработчики UI
		private void MiExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MiNew_Click(object sender, EventArgs e)
		{
			var fileName = FileDlgs.SFD();
			if (fileName != null)
				Presenter.DBNew(fileName);
		}

		private void MiConnect_Click(object sender, EventArgs e)
		{
			var fileName = FileDlgs.OFD();
			if (fileName != null)
				Presenter.Connect(fileName);
		}

		private void BtnAddRecord_Click(object sender, EventArgs e)
		{
			Presenter.AddRecord();
		}
		private void BtnEditRecord_Click(object sender, EventArgs e)
		{
			if (LvMain.SelectedItems.Count != 0)
				Presenter.EditRecord();
		}
		private void BtnDeleteRecord_Click(object sender, EventArgs e)
		{
			Presenter.DeleteRecord(GetSelectedId());
		}

		private void DpSetDate_ValueChanged(object sender, EventArgs e)
		{
			Presenter.SetCurrentDate(DpSetDate.Value);
		}

		private void BtnGetCurrentDate_Click(object sender, EventArgs e)
		{
			var date = DateTime.Now;
			Presenter.SetCurrentDate(date);
			DpSetDate.Value = date;
		}
	}
}

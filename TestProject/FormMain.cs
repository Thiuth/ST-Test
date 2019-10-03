using System;
using System.Windows.Forms;
using TestProject.Models;
using TestProject.Presenters;
using TestProject.Views;

namespace TestProject
{
	public partial class FormMain : Form, IMainView
	{
		private MainPresenter Presenter { get; set; }
		public FormMain()
		{
			InitializeComponent();
			DisableSideMenu();
			Presenter = new MainPresenter(this, new Model());
		}

		//	Активирует кнопки сбоку окна
		public void EnableSideMenu()
		{
			BtnAddRecord.Enabled = true;
			BtnEditRecord.Enabled = true;
			BtnDeleteRecord.Enabled = true;
		}

		//	Деактивирует кнопки сбоку окна
		public void DisableSideMenu()
		{
			BtnAddRecord.Enabled = false;
			BtnEditRecord.Enabled = false;
			BtnDeleteRecord.Enabled = false;
		}

		//	Заполняет таблицу в главном окне
		public void FillListView(string[,] table)
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

		//	Получает ID выделенной записи
		public int GetSelectedId()
		{
			var selected = LvMain.SelectedItems[0];
			return Convert.ToInt32(selected.SubItems[0].Text);
		}

		//	Обрабатывает ошибку. возникающую при неправильно указанной дате
		public void HandleDateError()
		{
			MessageBox.Show("Выбранная дата должна быть позже всех дат поступления сотрудников на работу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			DpSetDate.Value = DateTime.Now;
		}

		//	Обработчики UI
		private void MiExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MiNew_Click(object sender, EventArgs e)
		{
			Presenter.DBNew();
		}

		private void MiConnect_Click(object sender, EventArgs e)
		{
			Presenter.DBConnect();
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

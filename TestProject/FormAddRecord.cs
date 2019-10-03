using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestProject.Models;
using TestProject.Presenters;
using TestProject.Service;
using TestProject.Views;

namespace TestProject
{
	public partial class FormAddRecord : Form, IAddRecordView
	{
		private AddRecordPresenter Presenter { get; set; }
		public FormAddRecord(IModel model)
		{
			InitializeComponent();
			Presenter = new AddRecordPresenter(this, Application.OpenForms["FormMain"] as FormMain, model);
		}

		//	Перезагружает список начальников
		public void ReloadHeadList(List<ComboBoxItem> items)
		{
			CbHead.Items.Clear();
			CbHead.Items.Add(new ComboBoxItem(-1, "Нет"));
			foreach (var item in items)
			{
				CbHead.Items.Add(item);
			}
		}

		//	Обнуляет поля ввода
		public void ClearControls()
		{
			TbName.Text = "";
			TbBaseSalary.Text = "";
		}

		//	Обработчики UI
		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAddRecord_Click(object sender, EventArgs e)
		{
			Presenter.Name = TbName.Text;
			Presenter.Group = (PersonGroup)CbGroup.SelectedIndex;
			Presenter.HeadId = ((ComboBoxItem)CbHead.SelectedItem).Id;
			Presenter.RecDate = DpRecDate.Value.Date;
			Presenter.BaseSalary = Convert.ToUInt32(TbBaseSalary.Text);
			Presenter.AddRecord();
			Presenter.GenerateComboBoxItems();
		}

		private void FormAddRecord_Load(object sender, EventArgs e)
		{
			Presenter.GenerateComboBoxItems();
			CbHead.SelectedIndex = 0;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestProject.Models;
using TestProject.Presenters;
using TestProject.Service;
using TestProject.Views;

namespace TestProject
{
	public partial class FormEditRecord : Form, IEditRecordView
	{
		private EditRecordPresenter Presenter { get; set; }
		public FormEditRecord(IModel model)
		{
			InitializeComponent();
			Presenter = new EditRecordPresenter(this, Application.OpenForms["FormMain"] as FormMain, model);
		}

		//	Обновляет список начальников
		public void ReloadHeadList(List<ComboBoxItem> items)
		{
			CbHead.Items.Clear();
			CbHead.Items.Add(new ComboBoxItem(-1, "Нет"));
			foreach (var item in items)
			{
				CbHead.Items.Add(item);
			}
		}

		//	Заполняет форму данными из модели
		public void FillControls(string name, int group, int head, DateTime date, uint baseSalary)
		{
			TbName.Text = name;
			CbGroup.SelectedIndex = group;
			CbHead.SelectedIndex = 0;
			DpRecDate.Value = date;
			TbBaseSalary.Text = baseSalary.ToString();
		}

		//	Обработчики UI
		private void FormEditRecord_Load(object sender, EventArgs e)
		{
			Presenter.GenerateComboBoxItems();
			Presenter.LoadValues();
			CbHead.SelectedIndex = 0;
		}

		private void BtnAddRecord_Click(object sender, EventArgs e)
		{
			Presenter.ApplyChanges(
				TbName.Text,
				CbGroup.SelectedIndex,
				((ComboBoxItem)CbHead.SelectedItem).Id,
				DpRecDate.Value.Date,
				Convert.ToUInt32(TbBaseSalary.Text));
			Close();
		}
	}
}

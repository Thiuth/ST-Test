using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TestProject.Models;
using TestProject.Presentation;
using TestProject.Service;
using TestProject.UI;
using System.Linq;

namespace TestProject
{
	public partial class FormEditRecord : Form, IVEditRecord
	{
		private PrEditRecord Presenter { get; set; }
		private IErrorOutput ErrHandler { get; set; }
		public FormEditRecord(IModel model, IPrMain mainPresenter)
		{
			InitializeComponent();
			Presenter = new PrEditRecord(this, Application.OpenForms["FormMain"] as FormMain, model, mainPresenter);
			ErrHandler = new ErrorOutput();
		}

		/// <summary>
		/// Обновляет список начальников
		/// </summary>
		public void ReloadHeadList(List<ComboBoxItem> items)
		{
			CbHead.Items.Clear();
			CbHead.Items.Add(new ComboBoxItem(-1, "Нет"));
			foreach (var item in items)
			{
				CbHead.Items.Add(item);
			}
		}

		/// <summary>
		/// Заполняет форму данными из модели
		/// </summary>

		public void FillControls(string name, int group, int head, DateTime date, long baseSalary)
		{
			TbName.Text = name;
			CbGroup.SelectedIndex = group;
			CbHead.SelectedIndex = 0;
			DpRecDate.Value = date;
			TbBaseSalary.Text = baseSalary.ToString();
		}

		/// <summary>
		/// Проверяет поля на форме на предмет корректности введенных данных
		/// </summary>
		private bool FieldsAreValid()
		{
			if (
				TbName.Text == "" ||
				TbBaseSalary.Text == "" ||
				!TbBaseSalary.Text.All(c => char.IsDigit(c)))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		//	Обработчики UI
		private void FormEditRecord_Load(object sender, EventArgs e)
		{
			Presenter.LoadValues();
			Presenter.GenerateComboBoxItems();
			CbHead.SelectedIndex = 0;
		}

		private void BtnAddRecord_Click(object sender, EventArgs e)
		{
			if (FieldsAreValid())
			{
				Presenter.ApplyChanges(
					TbName.Text,
					CbGroup.SelectedIndex,
					((ComboBoxItem)CbHead.SelectedItem).Id,
					DpRecDate.Value.Date,
					Convert.ToUInt32(TbBaseSalary.Text));
				Close();
			}
			else
			{
				ErrHandler.ShowError(ErrorType.InvalidEDFields);
			}
		}
	}
}

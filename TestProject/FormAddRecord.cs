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
	public partial class FormAddRecord : Form, IVAddRecord
	{
		private PrAddRecord Presenter { get; set; }
		private IErrorOutput ErrHandler { get; set; }
		public FormAddRecord(IModel model, IPrMain mainPresenter)
		{
			InitializeComponent();
			Presenter = new PrAddRecord(this, Application.OpenForms["FormMain"] as FormMain, model, mainPresenter);
			ErrHandler = new ErrorOutput();
		}

		/// <summary>
		/// Перезагружает список начальников
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
		/// Обнуляет поля ввода
		/// </summary>
		public void ClearControls()
		{
			TbName.Text = "";
			TbBaseSalary.Text = "";
		}

		/// <summary>
		/// Проверяет поля на форме на предмет корректности введенных данных
		/// </summary>
		private bool FieldsAreValid()
		{
			if (
				TbName.Text == ""
				|| TbBaseSalary.Text == ""
				|| !TbBaseSalary.Text.All(c => char.IsDigit(c)))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		//	Обработчики UI
		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnAddRecord_Click(object sender, EventArgs e)
		{
			if (FieldsAreValid())
			{
				Presenter.Name = TbName.Text;
				Presenter.Group = (PersonGroup)CbGroup.SelectedIndex;
				Presenter.HeadId = ((ComboBoxItem)CbHead.SelectedItem).Id;
				Presenter.RecDate = DpRecDate.Value.Date;
				Presenter.BaseSalary = Convert.ToUInt32(TbBaseSalary.Text);
				Presenter.AddRecord();
				Presenter.GenerateComboBoxItems();
			}
			else
			{
				ErrHandler.ShowError(ErrorType.InvalidADFields);
			}
		}

		private void FormAddRecord_Load(object sender, EventArgs e)
		{
			Presenter.GenerateComboBoxItems();
			CbHead.SelectedIndex = 0;
			CbGroup.SelectedIndex = 0;
		}
	}
}

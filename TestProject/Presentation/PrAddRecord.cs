using System;
using System.Collections.Generic;
using System.Data;
using TestProject.Models;
using TestProject.Service;
using TestProject.UI;

namespace TestProject.Presentation
{
	//	
	/// <summary>
	/// Представитель, обеспечивающий связь модели и окна добавления сотрудника
	/// </summary>
	public class PrAddRecord : PrRecordDialog<IVAddRecord>
	{
		IPrMain MainPresenter { get; set; }
		IErrorOutput ErrHandler { get; set; }
		public PrAddRecord(IVAddRecord view, IVMain mainView, IModel model, IPrMain mainPresenter)
		{
			View = view;
			MainView = mainView;
			Model = model;
			MainPresenter = mainPresenter;
			ErrHandler = new ErrorOutput();
		}

		/// <summary>
		/// Добавляет запись в модель
		/// </summary>
		public void AddRecord()
		{
			if (Model.GetCurrentDate() > RecDate)
			{
				Model.AddRecord(Name, Group, RecDate, HeadId, BaseSalary);
				View.ClearControls();
				Model.RecalculateSalaries();
				MainPresenter.UpdateTable();
			}
			else
			{
				ErrHandler.ShowError(ErrorType.InvalidRecDate);
			}
		}

		/// <summary>
		/// Генерирует для формы список элементов ComboBox'а выбора начальника с привязанными ID
		/// </summary>
		public override void GenerateComboBoxItems()
		{
			var records = Model.GetRecords();
			var items = new List<ComboBoxItem>();
			foreach (var person in records)
			{
				if (person.Group != (int)PersonGroup.Employee)
				{
					items.Add(new ComboBoxItem(person.Id, person.Name));
				}
			}
			View.ReloadHeadList(items);
		}
	}
}

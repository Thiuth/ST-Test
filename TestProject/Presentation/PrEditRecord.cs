using System;
using System.Collections.Generic;
using TestProject.Models;
using TestProject.Service;
using TestProject.UI;

namespace TestProject.Presentation
{
	/// <summary>
	/// Представитель, обеспечивающий связь между моделью и формой изменения записей
	/// </summary>
	class PrEditRecord : PrRecordDialog<IVEditRecord>
	{
		IPrMain MainPresenter { get; set; }
		IErrorOutput ErrHandler { get; set; }
		private int Id { get; set; }
		public PrEditRecord(IVEditRecord view, IVMain mainView, IModel model, IPrMain mainPresenter)
		{
			View = view;
			MainView = mainView;
			Model = model;
			MainPresenter = mainPresenter;
			ErrHandler = new ErrorOutput();
		}

		/// <summary>
		/// Получает ID выделенной записи из главной формы и соответствующие данные из модели
		/// </summary>
		public void LoadValues()
		{
			Id = MainView.GetSelectedId();
			var person = Model.GetRecords().Find(p => p.Id == Id);
			Name = person.Name;
			Group = ((PersonGroup)person.Group);
			HeadId = person.Head;
			RecDate = person.RecDate;
			BaseSalary = person.BaseSalary;
			View.FillControls(Name, (int)Group, HeadId, RecDate, BaseSalary);
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

		/// <summary>
		/// Сохраняет сделанные изменения в модели
		/// </summary>
		public void ApplyChanges(string name, int groupId, int headId, DateTime date, uint baseSalary)
		{
			if (Model.GetCurrentDate() > date)
			{
				Model.EditRecord(Id, name, (PersonGroup)groupId, date, headId, baseSalary);
				Model.RecalculateSalaries();
				MainPresenter.UpdateTable();
			}
			else
			{
				ErrHandler.ShowError(ErrorType.InvalidRecDate);
			}
		}
	}
}

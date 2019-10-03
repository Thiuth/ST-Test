using System;
using System.Collections.Generic;
using System.Data;
using TestProject.Models;
using TestProject.Service;
using TestProject.Views;

namespace TestProject.Presenters
{
	//	Презентер. обеспечивающий связь между моделью и окном изменения записей
	class EditRecordPresenter : RecordDialogPresenter<IEditRecordView>
	{
		private int Id { get; set; }
		public EditRecordPresenter(IEditRecordView view, IMainView mainView, IModel model)
		{
			View = view;
			MainView = mainView;
			Model = model;
		}

		//	Забирает ID выделенной записи из главной формы и соответствующие данные из модели
		public void LoadValues()
		{
			Id = MainView.GetSelectedId();
			var row = Model.GetRow(Id);
			Name = row["Name"].ToString();
			Group = (PersonGroup)Convert.ToInt32(row["GroupId"].ToString());
			HeadId = Convert.ToInt32(row["HeadId"].ToString());
			RecDate = DateTime.Parse(row["RecDate"].ToString());
			BaseSalary = Convert.ToUInt32(row["BaseSalary"].ToString());
			View.FillControls(Name, (int)Group, HeadId, RecDate, BaseSalary);
		}

		//	Генерирует для формы список элементов ComboBox'а выбора начальника с привязанными Id
		public override void GenerateComboBoxItems()
		{
			var table = Model.GetTable("Employees");
			List<ComboBoxItem> items = new List<ComboBoxItem>();
			int personGroupId;
			int personId;
			foreach (DataRow row in table.Rows)
			{
				personGroupId = Convert.ToInt32(row["GroupId"].ToString());
				if (personGroupId != (int)PersonGroup.Employee)
				{
					personId = Convert.ToInt32(row["Id"].ToString());
					items.Add(new ComboBoxItem(personId, $"{row["name"].ToString()}"));
				}
			}
			View.ReloadHeadList(items);
		}
		//	Сохраняет сделанные изменения в модели
		public void ApplyChanges(string name, int groupId, int headId, DateTime date, uint baseSalary)
		{
			Model.ChangePerson(Id, name, (PersonGroup)groupId, date, headId, baseSalary);
			MainView.FillListView(Model.GenerateStringTable());
		}
	}
}

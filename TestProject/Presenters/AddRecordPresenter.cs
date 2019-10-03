using System;
using System.Collections.Generic;
using System.Data;
using TestProject.Models;
using TestProject.Service;
using TestProject.Views;

namespace TestProject.Presenters
{
	//	Презентер, обеспечивающий связь модели и окна добавления сотрудника
	public class AddRecordPresenter : RecordDialogPresenter<IAddRecordView>
	{
		public AddRecordPresenter(IAddRecordView view, IMainView mainView, IModel model)
		{
			View = view;
			MainView = mainView;
			Model = model;
		}

		//	Добавляет запись в модели
		public void AddRecord()
		{
			Model.AddPerson(Name, Group, RecDate, HeadId, BaseSalary);
			MainView.FillListView(Model.GenerateStringTable());
			View.ClearControls();
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
	}
}

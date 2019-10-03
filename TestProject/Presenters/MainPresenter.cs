using System;
using TestProject.Models;
using TestProject.Views;

namespace TestProject.Presenters
{
	//	Презентер, служащий для связи главной формы и модели.
	public class MainPresenter : BasePresenter<IMainView>
	{
		public MainPresenter(IMainView view, IModel model)
		{
			View = view;
			Model = model;
		}

		//	Создает новую БД
		public void DBNew()
		{
			Model.NewDatabase();
			View.EnableSideMenu();
			View.FillListView(Model.GenerateStringTable());
		}

		//	Подключает БД
		public void DBConnect()
		{
			Model.ConnectDatabase();
			View.EnableSideMenu();
			View.FillListView(Model.GenerateStringTable());
		}

		//	Открывает окно добавления записи
		public void AddRecord()
		{
			var dlg = new FormAddRecord(Model);
			dlg.ShowDialog();
		}

		//	Открывает окно изменения записи
		public void EditRecord()
		{
			var dlg = new FormEditRecord(Model);
			dlg.ShowDialog();
		}

		//	Удаляет запись
		public void DeleteRecord(int id)
		{
			Model.DeletePerson(id);
			View.FillListView(Model.GenerateStringTable());
		}

		//	Устанавливает дату для расчет з/п
		public void SetCurrentDate(DateTime date)
		{

			if (Model.SetCurrentDate(date) == 0)
				View.FillListView(Model.GenerateStringTable());
			else
				View.HandleDateError();

		}
	}
}

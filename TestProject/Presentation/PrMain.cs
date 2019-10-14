using System;
using TestProject.Models;
using TestProject.UI;
using TestProject.FileService;
using TestProject.Service;
using System.Data.Entity;
using System.IO;

namespace TestProject.Presentation
{

	/// <summary>
	/// Представитель, работающий с главной формой
	/// </summary>
	public class PrMain : PrBase<IVMain>, IPrMain
	{
		private IDbFileGenerator DatabaseGenerator { get; set; }
		private IErrorOutput ErrHandler { get; set; }

		public PrMain(IVMain view, IModel model)
		{
			View = view;
			Model = model;
			DatabaseGenerator = new DbFileGenerator();
			ErrHandler = new ErrorOutput();
		}

		/// <summary>
		/// Преобразует данные модели в строковый вид и передает их в форму для отрисовки
		/// </summary>
		public void UpdateTable()
		{
			var people = Model.GetRecords();
			var count = people.Count;
			var table = new string[7, count];
			string headName;
			MainModel.Person person;
			MainModel.Person head;
			for (var i = 0; i < count; i++)
			{
				person = people[i];
				head = people.Find(p => p.Id == person.Head);
				headName = head != null ? head.Name : "Нет";
				table[0, i] = person.Id.ToString();
				table[1, i] = person.Name;
				table[2, i] = ((PersonGroup)person.Group).ToString();
				table[3, i] = headName;
				table[4, i] = person.RecDate.ToString("dd.MM.yyyy");
				table[5, i] = person.BaseSalary.ToString();
				table[6, i] = person.RealSalary.ToString();
			}
			View.UpdateListView(table);
		}

		/// <summary>
		/// Создает новую БД
		/// </summary>
		public void DBNew(string fileName)
		{
			DatabaseGenerator.GenerateNewFile(fileName);
			Model.SetConnection(fileName);
			Model.InitializeContext();
			Model.SetCurrentDate(DateTime.Now);
			View.EnableSideMenu();
		}

		/// <summary>
		/// Производит подключение к выбранному файлу БД
		/// </summary>
		public void Connect(string fileName)
		{
			Model.SetConnection(fileName);
			Model.InitializeContext();
			Model.SetCurrentDate(DateTime.Now);
			View.EnableSideMenu();
			Model.RecalculateSalaries();
			UpdateTable();
		}

		/// <summary>
		/// Создает и отображает диалоговое окно добавления записей
		/// </summary>
		public void AddRecord()
		{
			var dlg = new FormAddRecord(Model, this);
			dlg.ShowDialog();
		}

		/// <summary>
		/// Создает и отображает диалоговое окно редактирования записей
		/// </summary>
		public void EditRecord()
		{
			var dlg = new FormEditRecord(Model, this);
			dlg.ShowDialog();
		}

		/// <summary>
		/// Вызывает в модели процедуру удаления записи с указанным ID
		/// </summary>
		public void DeleteRecord(int id)
		{
			Model.DeleteRecord(id);
			Model.RecalculateSalaries();
			UpdateTable();
		}

		/// <summary>
		/// Получает из главной формы дату для расчета з/п и устанавливает ее для модели
		/// </summary>
		public void SetCurrentDate(DateTime date)
		{
			if (date > Model.GetMaxRecDate())
			{
				Model.SetCurrentDate(date);
				Model.RecalculateSalaries();
				UpdateTable();
			}
			else
			{
				ErrHandler.ShowError(ErrorType.InvalidCurrentDate);
				View.SetDatePickerValue(DateTime.Now);
			}
		}
	}
}

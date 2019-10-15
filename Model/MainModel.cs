using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using TestProject.Service;

namespace TestProject.Models
{
	/// <summary>
	/// Основной класс модели, с которой работает приложение
	/// </summary>
	public partial class MainModel : IModel
	{
		/// <summary>
		/// Дата, на которую расчитываются з/п
		/// </summary>
		public static DateTime CurrentDate { get; set; }

		/// <summary>
		/// Экземпляр ApplicationContext:DbContext, используемый моделью
		/// </summary>
		public static ApplicationContext Context { get; set; }

		/// <summary>
		/// Подключение к БД
		/// </summary>
		public static SQLiteConnection Connection { get; set; }

		/// <summary>
		/// Создает подключение к БД по указанному имени файла
		/// </summary>
		public void SetConnection(string fileName)
		{
			var connectionString = new SQLiteConnectionStringBuilder();
			connectionString.DataSource = fileName;
			Connection = new SQLiteConnection();
			Connection.ConnectionString = connectionString.ToString();
		}

		/// <summary>
		/// Получает самую позднюю дату зачисления сотрудника
		/// </summary>
		public DateTime GetMaxRecDate()
		{
			var date = new DateTime(1, 1, 1);
			foreach(var person in Context.People)
			{
				if (person.RecDate > date)
					date = person.RecDate;
			}
			return date;
		}

		/// <summary>
		/// Получает CurrentDate
		/// </summary>
		public DateTime GetCurrentDate()
		{
			return CurrentDate;
		}

		/// <summary>
		/// Получает информацию о сотрудниках в виде списка List
		/// </summary>
		public List<Person> GetRecords()
		{
			return Context.People.ToList();
		}

		/// <summary>
		/// Устанавливает CurrentDate
		/// </summary>
		public void SetCurrentDate(DateTime date)
		{
			CurrentDate = date;
		}

		/// <summary>
		/// Инициализирует Context
		/// </summary>
		public void InitializeContext()
		{
			Context = new ApplicationContext();
			Context.People.Load();
		}

		/// <summary>
		/// Добавляет запись в БД
		/// </summary>
		public void AddRecord(string name, PersonGroup group, DateTime recDate, int head, long baseSalary)
		{
			var person = InitializePerson(group);
			person.Name = name;
			person.RecTimestamp = ((DateTimeOffset)recDate).ToUnixTimeSeconds();
			person.Head = head;
			person.BaseSalary = baseSalary;
			person.RealSalary = baseSalary;
			Context.People.Add(person);
			Context.SaveChanges();
		}

		/// <summary>
		/// Изменяет запись в БД
		/// </summary>
		public void EditRecord(int id, string name, PersonGroup group, DateTime recDate, int head, long baseSalary)
		{
			var person = Context.People.Find(id);
			person.Name = name;
			person.RecTimestamp = ((DateTimeOffset)recDate).ToUnixTimeSeconds();
			person.Head = head;
			person.BaseSalary = baseSalary;
			Context.Entry(person).State = EntityState.Modified;
			Context.SaveChanges();
		}

		/// <summary>
		/// Удаляет запись из БД
		/// </summary>
		public void DeleteRecord(int id)
		{
			var person = Context.People.Find(id);
			Context.People.Remove(person);
			Context.SaveChanges();
		}

		/// <summary>
		/// Пересчитывает все з/п
		/// </summary>
		public void RecalculateSalaries()
		{
			foreach(var person in Context.People)
			{
				person.FindHeads();
			}
			foreach (var person in Context.People)
			{
				person.CalculateRealSalary();
			}
		}

		/// <summary>
		/// Инициализирует экземпляр одного из дочерних классов Person
		/// </summary>
		private Person InitializePerson(PersonGroup group)
		{
			Person person;
			switch (group)
			{
				case PersonGroup.Employee:
					person = new Employee();
					break;
				case PersonGroup.Manager:
					person = new Manager();
					break;
				case PersonGroup.Salesman:
					person = new Salesman();
					break;
				default:
					return null;
			}
			person.Group = (int)group;
			return person;
		}
	}
}


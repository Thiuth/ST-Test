using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestProject.DatabaseIO;
using TestProject.Service;

namespace TestProject.Models
{
	//	Класс Model содержит логику приложения, отвечающую непосредственно за обработку данных
	public partial class Model : IModel, IModelIO
	{
		public Model()
		{
			CurrentDate = DateTime.Now;
			SCD = new List<SalaryCalcData>();
			IOManager = new DatabaseIOManager(this, new SqliteProcessing());
			InitializeDataset();
		}

		public DataSet Data { get; set; }
		public DatabaseIOManager IOManager { get; set; }
		public static DateTime CurrentDate { get; set; }
		public static List<SalaryCalcData> SCD { get; set; }

		//	---------------------------------
		//	Методы для инициализации объектов
		//	---------------------------------

		//	Инициализирует объект DataSet Data
		private void InitializeDataset()
		{
			Data = new DataSet("Database");
			Data.Tables.Add("Employees");
			var keys = new DataColumn[1];
			keys[0] = new DataColumn("Id", typeof(int));
			Data.Tables["Employees"].Columns.Add(keys[0]);
			Data.Tables["Employees"].Columns.Add("Name", typeof(string));
			Data.Tables["Employees"].Columns.Add("GroupId", typeof(PersonGroup));
			Data.Tables["Employees"].Columns.Add("HeadId", typeof(int));
			Data.Tables["Employees"].Columns.Add("RecDate", typeof(DateTime));
			Data.Tables["Employees"].Columns.Add("BaseSalary", typeof(uint));
			Data.Tables["Employees"].Columns.Add("RealSalary", typeof(uint));
			Data.Tables["Employees"].PrimaryKey = keys;
			Data.Tables["Employees"].Columns["Id"].AutoIncrement = true;
			Data.Tables["Employees"].Columns["Id"].Unique = true;
		}

		//	Создает экземпляр нужного дочернего класса SalaryCalcData
		private SalaryCalcData CreateSCDInstance(PersonGroup group)
		{
			switch (group)
			{
				case PersonGroup.Employee:
					return new Employee();
				case PersonGroup.Manager:
					return new Manager();
				case PersonGroup.Salesman:
					return new Salesman();
				default:
					return null;
			}
		}

		//	------------------------------
		//	Методы для взаимодействия с БД
		//	------------------------------

		//	Посылает в IOManager запрос на создание новой БД
		public void NewDatabase()
		{
			IOManager.NewDatabase();
		}

		//	Посылает в IOManager запрос на подключение к БД
		public void ConnectDatabase()
		{
			IOManager.ConnectDatabase(Data);
		}

		//	Обновляет объект DataSet Data
		public void UpdateDataset(DataSet data)
		{
			Data = data;
			RecalculateAllSalaries();
		}

		//	Пересчитывает реальные з/п сотрудников и обновляет дейтасет
		private void RecalculateAllSalaries()
		{
			SCD = new List<SalaryCalcData>();
			int groupId;
			PersonGroup group;
			SalaryCalcData scdBuffer;
			foreach (DataRow row in Data.Tables["Employees"].Rows)
			{
				groupId = Convert.ToInt32(row["GroupId"].ToString());
				group = (PersonGroup)groupId;
				scdBuffer = CreateSCDInstance(group);
				scdBuffer.Id = Convert.ToInt32(row["Id"].ToString());
				scdBuffer.HeadId = Convert.ToInt32(row["HeadId"].ToString());
				scdBuffer.RecDate = DateTime.Parse(row["RecDate"].ToString());
				scdBuffer.BaseSalary = Convert.ToUInt32(row["BaseSalary"].ToString());
				SCD.Add(scdBuffer);
			}
			foreach (var scd in SCD)
			{
				scd.GetSubIds();
			}
			foreach (var scd in SCD)
			{
				scd.CalculateRealSalary();
			}
			foreach (DataRow row in Data.Tables["Employees"].Rows)
			{
				row["RealSalary"] = GetSalaryFromSCD(Convert.ToInt32(row["Id"].ToString()));
			}
		}

		//	----------------------------
		//	Методы для работы с записями
		//	----------------------------

		//	Добавляет новую запись
		public void AddPerson(string name, PersonGroup group, DateTime recDate, int headId, uint baseSalary)
		{
			var row = Data.Tables["Employees"].NewRow();
			row["Name"] = name;
			row["GroupId"] = group;
			row["HeadId"] = headId;
			row["RecDate"] = recDate;
			row["BaseSalary"] = baseSalary;
			Data.Tables["Employees"].Rows.Add(row);
			RecalculateAllSalaries();
			IOManager.ExportDataset(Data);
		}

		//	Изменяет существующую запись
		public void ChangePerson(int id, string name, PersonGroup group, DateTime recDate, int headId, uint baseSalary)
		{
			var row = Data.Tables["Employees"].Select($"Id = {id}").FirstOrDefault();
			row["Name"] = name;
			row["GroupId"] = group;
			row["HeadId"] = headId;
			row["RecDate"] = recDate;
			row["BaseSalary"] = baseSalary;
			RecalculateAllSalaries();
			IOManager.ExportDataset(Data);
		}

		//	Удаляет существующую запись
		public void DeletePerson(int id)
		{
			var row = Data.Tables["Employees"].Select($"Id = {id}").FirstOrDefault();
			Data.Tables["Employees"].Rows.Remove(row);
			foreach (DataRow r in Data.Tables["Employees"].Rows)
			{
				if (r["HeadId"].Equals(id))
				{
					r["HeadId"] = -1;
				}
			}
			RecalculateAllSalaries();
			IOManager.ExportDataset(Data);
		}

		//	----------------------------------
		//	Прочие методы для работы с данными
		//	----------------------------------

		//	Устанавливает дату, на которую производится расчет зарплат
		public int SetCurrentDate(DateTime date)
		{
			DateTime itemDate;
			foreach (DataRow row in Data.Tables["Employees"].Rows)
			{
				itemDate = DateTime.Parse(row["recDate"].ToString());
				if (itemDate > date)
					return -1;
			}
			CurrentDate = date;
			RecalculateAllSalaries();
			IOManager.ExportDataset(Data);
			return 0;
		}

		//	Преобразует данные из Data в двухмерный массив строк для передачи оного в ListView главной формы
		public string[,] GenerateStringTable()
		{
			var table = new string[7, Data.Tables["Employees"].Rows.Count];
			int groupIdInt, headIdInt;
			string groupIdString, groupIdName, headName, headIdString;
			for (var i = 0; i < Data.Tables["Employees"].Rows.Count; i++)
			{
				groupIdString = Data.Tables["Employees"].Rows[i]["GroupId"].ToString();
				groupIdInt = Convert.ToInt32(groupIdString);
				headIdString = Data.Tables["Employees"].Rows[i]["HeadId"].ToString();
				headIdInt = Convert.ToInt32(headIdString);
				groupIdName = ((PersonGroup)groupIdInt).ToString();
				headName = GetNameById(headIdInt);
				table[0, i] = Data.Tables["Employees"].Rows[i]["Id"].ToString();
				table[1, i] = Data.Tables["Employees"].Rows[i]["Name"].ToString();
				table[2, i] = groupIdName;
				table[3, i] = headName;
				table[4, i] = Data.Tables["Employees"].Rows[i]["RecDate"].ToString();
				table[5, i] = Data.Tables["Employees"].Rows[i]["BaseSalary"].ToString();
				table[6, i] = Data.Tables["Employees"].Rows[i]["RealSalary"].ToString();
			}
			return table;
		}

		//	----------------------------------------
		//	Методы для извлечения данных из объектов
		//	----------------------------------------

		//	Получает строку из DataTable по Id записи
		public DataRow GetRow(int id)
		{
			return Data.Tables["Employees"].Rows.Find(id);
		}

		//	Получает имя сотрудника по Id записи
		private string GetNameById(int id)
		{
			if (id == -1)
				return "Нет";
			var row = Data.Tables["Employees"].Select($"Id = {id}").FirstOrDefault();
			return row["Name"].ToString();
		}

		//	Получает значение реальной з/п сотрудника по Id записи
		private uint GetSalaryFromSCD(int id)
		{
			var scd = SCD.Find(item => item.Id == id);
			return scd.RealSalary;
		}

		//	Извлекает DataTable из DataSet
		public DataTable GetTable(string name)
		{
			return Data.Tables[name];
		}
	}
}
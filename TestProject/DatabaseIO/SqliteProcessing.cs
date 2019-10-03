using System.Data;
using System.Data.SQLite;

namespace TestProject.DatabaseIO
{
	//	Класс, реализующий логику непосредственного взаимодействия с базами данных
	public class SqliteProcessing : ISqliteProcessing
	{
		private string FileName { get; set; }
		public SQLiteConnection Connection { get; set; }
		public SQLiteDataAdapter Adapter { get; set; }
		public SQLiteCommandBuilder CommandBuilder { get; set; }

		//	Инициализирует Adapter
		public void InitializeAdapter()
		{
			if (Connection != null && Connection.State == ConnectionState.Open)
				Adapter = new SQLiteDataAdapter("SELECT * FROM Employees", Connection);
		}

		//	Инициализирует CommandBuilder
		public void InitializeCmdBuilder()
		{
			if (Adapter != null)
				CommandBuilder = new SQLiteCommandBuilder(Adapter);
		}

		//	Записывает данные из DataSet в файл БД
		public void UpdateAdapter(DataSet data)
		{
			if (Adapter != null)
				Adapter.Update(data, "Employees");
		}

		//	Записывает данные из файла БД в DataSet
		public void FillAdapter(DataSet data)
		{
			if (Adapter != null)
				Adapter.Fill(data, "Employees");
		}

		//	Создает подключение
		public void OpenConnection()
		{
			Connection = new SQLiteConnection($"Data Source={FileName}; Version=3; datetimeformat=CurrentCulture;");
			if (Connection.State == ConnectionState.Closed)
				Connection.Open();
		}

		//	Закрывает подключение
		public void CloseConnection()
		{
			if (Connection != null && Connection.State == ConnectionState.Open)
				Connection.Close();
		}

		//	Выполняет SQL команду
		public void ExecuteCommand(string commandText)
		{
			if (Connection != null && Connection.State == ConnectionState.Open)
			{
				using (var command = new SQLiteCommand(commandText, Connection))
				{
					command.ExecuteNonQuery();
				}
			}
		}

		//	Задает имя файла для БД
		public void SetFileName(string fileName)
		{
			FileName = fileName;
		}
	}
}
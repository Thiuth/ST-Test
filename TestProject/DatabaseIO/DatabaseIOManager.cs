using System.Data;
using TestProject.FD;

namespace TestProject.DatabaseIO
{
	//	Класс DatabaseIOManager	содержит промежуточный слой логики между моделью и подпрограммами непосредственной работы с БД
	//	Из модели могут быть вызваны только методы этого класса
	public class DatabaseIOManager
	{
		private IModelIO Model { get; set; }
		private ISqliteProcessing Handler { get; set; }
		private IFileDialogs FileDialogs { get; set; }

		public DatabaseIOManager(IModelIO model, ISqliteProcessing handler)
		{
			Model = model;
			Handler = handler;
			FileDialogs = new FileDialogs();
		}

		//	Производит экспорт данных в БД
		public void ExportDataset(DataSet data)
		{
			Handler.InitializeAdapter();
			Handler.InitializeCmdBuilder();
			Handler.UpdateAdapter(data);
		}

		//	Производит импорт данных из БД
		private void ImportDataset(DataSet data)
		{
			Handler.InitializeAdapter();
			Handler.InitializeCmdBuilder();
			Handler.FillAdapter(data);
			Model.UpdateDataset(data);
		}

		//	Создает новую БД
		public void NewDatabase()
		{
			Handler.SetFileName(FileDialogs.SFD());
			Handler.OpenConnection();
			var commandText = "CREATE TABLE IF NOT EXISTS Employees "
				+ "("
				+ "Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, "
				+ "Name TEXT, "
				+ "GroupId INTEGER, "
				+ "HeadId INTEGER, "
				+ "RecDate DATETIME, "
				+ "BaseSalary INTEGER, "
				+ "RealSalary INTEGER"
				+ ")";
			Handler.ExecuteCommand(commandText);
		}

		//	Выполняет подключение к БД
		public void ConnectDatabase(DataSet data)
		{
			Handler.SetFileName(FileDialogs.OFD());
			Handler.OpenConnection();
			ImportDataset(data);
		}
	}
}

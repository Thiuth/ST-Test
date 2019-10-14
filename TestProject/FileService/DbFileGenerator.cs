using System.Data.SQLite;

namespace TestProject.FileService
{
	/// <summary>
	/// Содержит функционал, позволяющий создавать файлы БД с необходимой структурой
	/// </summary>
	public class DbFileGenerator : IDbFileGenerator
	{
		public void GenerateNewFile(string fileName)
		{
			var commandText = "CREATE TABLE IF NOT EXISTS \"People\" ("
				+ "\"Id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, "
				+ "\"Discriminator\" TEXT, "
				+ "\"Name\"	TEXT NOT NULL, "
				+ "\"Group\" INTEGER NOT NULL, "
				+ "\"RecTimestamp\"	INTEGER NOT NULL, "
				+ "\"Head\" INTEGER NOT NULL, "
				+ "\"BaseSalary\" INTEGER NOT NULL, "
				+ "\"RealSalary\" INTEGER NOT NULL);";
			var connection = new SQLiteConnection($"Data Source={fileName}; Version=3;");
			connection.Open();
			using (var command = new SQLiteCommand(commandText, connection))
			{
				command.ExecuteNonQuery();
			}
			connection.Close();
		}
	}
}

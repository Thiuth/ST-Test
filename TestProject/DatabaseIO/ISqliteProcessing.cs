using System.Data;

namespace TestProject.DatabaseIO
{
	//	Интефрйес, реализуемый классом Sqliteprocessing
	public interface ISqliteProcessing
	{
		void OpenConnection();
		void CloseConnection();
		void ExecuteCommand(string commandText);
		void SetFileName(string fileName);
		void InitializeAdapter();
		void InitializeCmdBuilder();
		void UpdateAdapter(DataSet data);
		void FillAdapter(DataSet data);
	}
}

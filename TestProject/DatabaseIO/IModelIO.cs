using System.Data;

namespace TestProject.DatabaseIO
{
	//	Интерфейс, реализуемый классом Model и применяемый для связывания оного с DatabaseIOManager
	public interface IModelIO
	{
		void UpdateDataset(DataSet data);
	}
}

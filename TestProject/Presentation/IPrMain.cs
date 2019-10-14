using System;

namespace TestProject.Presentation
{
	/// <summary>
	/// Интерфейс представителя главной формы.
	/// </summary>
	public interface IPrMain
	{
		void AddRecord();
		void DBNew(string fileName);
		void DeleteRecord(int id);
		void EditRecord();
		void SetCurrentDate(DateTime date);
		void UpdateTable();
		void Connect(string fileName);
	}
}

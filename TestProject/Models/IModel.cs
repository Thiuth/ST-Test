using System;
using System.Data;
using TestProject.Service;

namespace TestProject.Models
{
	//	Интерфейс, реализуемый классом модулей и служащий для привязывания модели к презентеру
	public interface IModel
	{
		void NewDatabase();
		void ConnectDatabase();
		string[,] GenerateStringTable();
		void AddPerson(string name, PersonGroup group, DateTime recDate, int headId, uint baseSalary);
		void ChangePerson(int id, string name, PersonGroup group, DateTime recDate, int headId, uint baseSalary);
		void DeletePerson(int id);
		DataTable GetTable(string name);
		int SetCurrentDate(DateTime date);
		DataRow GetRow(int id);
	}
}
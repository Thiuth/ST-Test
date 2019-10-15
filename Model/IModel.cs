using System;
using System.Collections.Generic;
using TestProject.Service;

namespace TestProject.Models
{
	/// <summary>
	/// Интерфейс модели
	/// </summary>
	public interface IModel
	{
		void SetCurrentDate(DateTime date);
		void InitializeContext();
		void AddRecord(string name, PersonGroup group, DateTime recDate, int head, long baseSalary);
		void EditRecord(int id, string name, PersonGroup group, DateTime recDate, int head, long baseSalary);
		void DeleteRecord(int id);
		List<MainModel.Person> GetRecords();
		void RecalculateSalaries();
		DateTime GetCurrentDate();
		void SetConnection(string fileName);
		DateTime GetMaxRecDate();
	}
}
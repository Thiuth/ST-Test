using System;
using System.Data;
using TestProject.Service;
using System.Collections.Generic;
using System.Data.Entity;

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
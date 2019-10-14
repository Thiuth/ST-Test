using System;
using System.Collections.Generic;
using TestProject.Service;

namespace TestProject.UI
{
	/// <summary>
	/// Интерфейс, реализуемый формой изменения записей
	/// </summary>
	public interface IVEditRecord
	{
		void ReloadHeadList(List<ComboBoxItem> items);
		void FillControls(string name, int group, int head, DateTime date, long baseSalary);
	}
}

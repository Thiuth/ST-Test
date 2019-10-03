using System;
using System.Collections.Generic;
using TestProject.Service;

namespace TestProject.Views
{
	//	Интерфейс, реализуемый формой изменения записей
	public interface IEditRecordView
	{
		void ReloadHeadList(List<ComboBoxItem> items);
		void FillControls(string name, int group, int head, DateTime date, uint baseSalary);
	}
}

using System.Collections.Generic;
using TestProject.Service;

namespace TestProject.Views
{
	// Интерфейс, реализуемый формой добавления записей
	public interface IAddRecordView
	{
		void ReloadHeadList(List<ComboBoxItem> items);
		void ClearControls();
	}
}

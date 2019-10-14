using System.Collections.Generic;
using TestProject.Service;

namespace TestProject.UI
{
	/// <summary>
	/// Интерфейс, реализуемый формой добавления записей
	/// </summary>
	public interface IVAddRecord
	{
		void ReloadHeadList(List<ComboBoxItem> items);
		void ClearControls();
	}
}

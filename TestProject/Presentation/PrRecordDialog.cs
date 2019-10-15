using System;
using TestProject.Service;
using TestProject.UI;

namespace TestProject.Presentation
{
	/// <summary>
	/// Родительский класс представителя диалогового окна, от которого наследуются PrAddRecord и PrEditRecord
	/// </summary>
	public abstract class PrRecordDialog<TView> : PrBase<TView>
	{
		protected IVMain MainView { get; set; }
		public string Name { get; set; }
		public PersonGroup Group { get; set; }
		public int HeadId { get; set; }
		public DateTime RecDate { get; set; }
		public long BaseSalary { get; set; }
		public abstract void GenerateComboBoxItems();
	}
}

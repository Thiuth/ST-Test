using System;
using TestProject.Service;
using TestProject.Views;

namespace TestProject.Presenters
{
	//	Родительский презентер диалогового окна, от которого наследуют AddRecordPresenter и EditRecordPresenter
	public abstract class RecordDialogPresenter<TView> : BasePresenter<TView>
	{
		public IMainView MainView { get; set; }
		public string Name { get; set; }
		public PersonGroup Group { get; set; }
		public int HeadId { get; set; }
		public DateTime RecDate { get; set; }
		public uint BaseSalary { get; set; }
		public abstract void GenerateComboBoxItems();
	}
}

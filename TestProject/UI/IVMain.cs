namespace TestProject.UI
{
	/// <summary>
	/// Интерфейс, реализуемый главной формой
	/// </summary>
	public interface IVMain
	{
		void EnableSideMenu();
		void DisableSideMenu();
		void UpdateListView(string[,] table);
		int GetSelectedId();
		void SetDatePickerValue(System.DateTime date);
	}

}

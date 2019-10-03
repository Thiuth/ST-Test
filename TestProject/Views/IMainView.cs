namespace TestProject.Views
{
	//	Интерфейс. реализуемый главной формой
	public interface IMainView
	{
		void EnableSideMenu();
		void DisableSideMenu();
		void FillListView(string[,] table);
		int GetSelectedId();
		void HandleDateError();
	}

}

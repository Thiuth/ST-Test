using TestProject.Models;

namespace TestProject.Presenters
{
	//	Базовый презентер, от которого наследуются все остальные
	public class BasePresenter<TView>
	{
		protected TView View { get; set; }
		protected IModel Model { get; set; }
	}
}

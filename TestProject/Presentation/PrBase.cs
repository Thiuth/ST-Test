using TestProject.Models;

namespace TestProject.Presentation
{
	/// <summary>
	/// Базовый представитель, от которого наследуются все прочие
	/// </summary>
	public class PrBase<TView>
	{
		/// <summary>
		/// Форма, с которой работает представитель
		/// </summary>
		protected TView View { get; set; }

		/// <summary>
		/// Модель, с которой работает представитель
		/// </summary>
		protected IModel Model { get; set; }
	}
}

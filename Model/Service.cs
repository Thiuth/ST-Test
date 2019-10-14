namespace TestProject.Service
{
	/// <summary>
	/// Перечисление групп сотрудников
	/// </summary>
	public enum PersonGroup
	{
		Employee,
		Manager,
		Salesman
	}

	/// <summary>
	/// Перечисление способов поиска подчиненных
	/// </summary>
	public enum SubordinateSearchMode
	{
		/// <summary>
		/// Только прямые подчиненные
		/// </summary>
		DirectOnly,

		/// <summary>
		/// Подчиненные всех уровней
		/// </summary>
		All
	}

	/// <summary>
	/// Вспомогательный класс, реализующий собственный формат элемента ComboBox'а.
	/// Обеспечивает возможность привязывать ID сотрудника к конкретному элементу выпадающего списка.
	/// </summary>
	public class ComboBoxItem
	{
		public int Id { get; set; }
		public string Text { get; set; }

		public ComboBoxItem(int id, string text)
		{
			Id = id;
			Text = text;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}

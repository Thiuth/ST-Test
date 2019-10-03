namespace TestProject.Service
{
	//	Различные вспомогательные перечисления и структуры, необходимые для работы приложения

	//	Идентификаторы групп сотрудников
	public enum PersonGroup
	{
		Employee,
		Manager,
		Salesman
	}

	//	Идентификаторы режима поиска подчиненных
	public enum SubordinateSearchMode
	{
		DirectOnly,
		All
	}

	//	Вспомогательный класс для элементов списов начальников в диалоговых окнах.
	//	Нужен для того чтобы как-то привязать ID сотрудника к элементу ComboBox'а
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

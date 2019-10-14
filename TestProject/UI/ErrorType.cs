namespace TestProject.UI
{
	/// <summary>
	/// Тип ошибки для вывода сообщения
	/// </summary>
	public enum ErrorType
	{
		/// <summary>
		/// Некорректное заполнение формы добавления записей
		/// </summary>
		InvalidADFields,

		/// <summary>
		/// Некорректное заполнения формы редактирования записей
		/// </summary>
		InvalidEDFields,

		/// <summary>
		/// Некорректная дата зачисления сотрудника
		/// </summary>
		InvalidRecDate,

		/// <summary>
		/// Некорректная дата расчета з/п
		/// </summary>
		InvalidCurrentDate
	}
}
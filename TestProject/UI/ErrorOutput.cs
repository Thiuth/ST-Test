using System.Windows.Forms;

namespace TestProject.UI
{
	/// <summary>
	/// Содержит функционал, упрощающий вывод сообщений об ошибках, 
	/// которые могут возникнуть в ходе работы приложения
	/// </summary>
	public class ErrorOutput : IErrorOutput
	{
		/// <summary>
		/// Выводит сообщение об ошибке выбранного типа
		/// </summary>
		public void ShowError(ErrorType type)
		{
			string errorMessage;
			switch (type)
			{
				case ErrorType.InvalidADFields:
					errorMessage = "Не удалось создать запись. Проверьте корректность заполнения формы.";
					break;
				case ErrorType.InvalidEDFields:
					errorMessage = "Не удалось изменить запись. Проверьте корректность заполнения формы.";
					break;
				case ErrorType.InvalidRecDate:
					errorMessage = "Дата поступления на работу не должна превышать дату, выбранную в настоящий момент для расчета з/п";
					break;
				case ErrorType.InvalidCurrentDate:
					errorMessage = "Выбранная дата должна быть позже всех дат зачисления сотрудников";
					break;
				default:
					return;
			}
			MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}

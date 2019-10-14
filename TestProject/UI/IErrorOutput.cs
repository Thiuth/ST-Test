using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.UI
{
	/// <summary>
	/// Интерфейс модуля вывода сообщений об ошибках
	/// </summary>
	public interface IErrorOutput
	{
		void ShowError(ErrorType type);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.FileService
{
	/// <summary>
	/// Интерфейс модуля создания файлов БД
	/// </summary>
	public interface IDbFileGenerator
	{
		void GenerateNewFile(string fileName);
	}
}

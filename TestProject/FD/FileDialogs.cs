using System.IO;
using System.Windows.Forms;

namespace TestProject.FD
{
	//	Вспомогательный класс, реализующий методы получения имен файлов путем вызова соответствующих диалоговых окон.
	public class FileDialogs : IFileDialogs
	{

		//	Вызывает диалоговое окно открытия
		public string OFD()
		{
			using (var dlg = new OpenFileDialog())
			{
				dlg.InitialDirectory = Directory.GetCurrentDirectory();
				dlg.Filter = "Файлы БД (*.db)|*.db|Все файлы (*.*)|*.*";
				dlg.CheckPathExists = true;
				dlg.ValidateNames = true;
				dlg.FilterIndex = 1;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					return dlg.FileName;
				}
				else
					return null;
			}
		}

		//	Вызывает диалоговое окно сохранения
		public string SFD()
		{
			using (var dlg = new SaveFileDialog())
			{
				dlg.InitialDirectory = Directory.GetCurrentDirectory();
				dlg.Filter = "Файлы БД (*.db)|*.db|Все файлы (*.*)|*.*";
				dlg.CheckPathExists = true;
				dlg.ValidateNames = true;
				dlg.FilterIndex = 1;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					return dlg.FileName;
				}
				else
					return null;
			}
		}
	}
}

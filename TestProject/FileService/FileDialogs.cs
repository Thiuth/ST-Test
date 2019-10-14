using System.IO;
using System.Windows.Forms;

namespace TestProject.FileService
{
	/// <summary>
	/// Содержит функционал, позволяющий получать имя файла с помощью диалогов открытия и сохранения
	/// </summary>
	public class FileDialogs : IFileDialogs
	{

		/// <summary>
		/// Выводит диалоговое окно открытия файла
		/// </summary>
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

		/// <summary>
		/// Выводит диалоговое окно сохранения файла
		/// </summary>
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

namespace TestProject.FileService
{
	/// <summary>
	/// Интерфейс модуля вывода диалоговых окон открытия и сохранения файлов
	/// </summary>
	public interface IFileDialogs
	{
		string OFD();
		string SFD();
	}
}

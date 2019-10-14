using TestProject.Service;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
	public partial class MainModel
	{
		/// <summary>
		/// Дочерний класс от Person, представляющий сотрудника группы Manager
		/// </summary>
		[Table("People")]
		public class Manager : Person
		{
			public override void CalculateRealSalary()
			{
				RealSalary = BaseSalary
				 + CalculateSA(0.05, 0.40)
				 + (uint)(GetSubSalaries(SubordinateSearchMode.DirectOnly) * 0.005);
			}
		}
	}
}


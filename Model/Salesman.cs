using TestProject.Service;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
	public partial class MainModel
	{
		/// <summary>
		/// Дочерний класс от Person, представляющий сотрудника группы Salesman
		/// </summary>
		[Table("People")]
		public class Salesman : Person
		{
			public override void CalculateRealSalary()
			{
				RealSalary = BaseSalary
				 + CalculateSA(0.01, 0.35)
				 + (uint)(GetSubSalaries(SubordinateSearchMode.All) * 0.003);
			}
		}
	}
}


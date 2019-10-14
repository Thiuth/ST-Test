using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
	public partial class MainModel
	{
		/// <summary>
		/// Дочерний класс от Person, представляющий сотрудника группы Employee
		/// </summary>
		[Table("People")]
		public class Employee : Person
		{
			public override void CalculateRealSalary()
			{
				RealSalary = BaseSalary
				 + CalculateSA(0.03, 0.30);
			}
		}
	}
}


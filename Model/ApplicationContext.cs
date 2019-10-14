using System.Data.Entity;

namespace TestProject.Models
{
	public partial class MainModel
	{
		/// <summary>
		/// Дочерний класс от DbContext, представяющий возможность оперировать с БД через Entity Framework
		/// </summary>
		public class ApplicationContext : DbContext
		{
			public ApplicationContext() : base(Connection, true)
			{
			}
			public DbSet<Person> People { get; set; }
			public DbSet<Employee> Employees { get; set; }
			public DbSet<Manager> Managers { get; set; }
			public DbSet<Salesman> Salesmen { get; set; }
		}
	}
}


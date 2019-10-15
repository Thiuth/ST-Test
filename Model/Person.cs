using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TestProject.Service;

namespace TestProject.Models
{
	public partial class MainModel
	{
		/// <summary>
		/// Класс, представляющий информацию об отдельном сотруднике. Часть полей привязана к ДБ.
		/// </summary>
		[Table("People")]
		public abstract class Person
		{

			// Поля, помеченные атрибутом [NotMapped], не привязаны к БД, но необходимы для произведения расчетов.
			//
			// Дата зачисления сотрудника существует в двух формах: в виде DateTime и виде Unix Timestamp.
			// Сделано так, потому что Sqlite не особо дружит с DateTime и удобнее записывать в БД метку времени.
			// Свойства реализованы таким образом, чтобы при изменении одного значения автоматически менялось другое.

			/// <summary>
			/// Идентификатор сотрудника, служащий ключевым полем БД
			/// </summary>
			public int Id { get; set; }

			/// <summary>
			/// Имя сотрудника
			/// </summary>
			public string Name { get; set; }

			/// <summary>
			/// Числовой идентификатор группы, к которой относится сотрудник, в сооветствии с Service.PersonGroup
			/// </summary>
			public int Group { get; set; }

			/// <summary>
			/// Дата зачисления сотрудника в формате метки времени Unix
			/// </summary>
			public long RecTimestamp
			{
				get => recTimestamp;
				set
				{
					recTimestamp = value;
					recDate = DateTimeOffset.FromUnixTimeSeconds(value).DateTime;
				}
			}
			private long recTimestamp;

			/// <summary>
			/// ID начальника
			/// </summary>
			public int Head { get; set; }

			/// <summary>
			/// Базовая ставка з/п
			/// </summary>
			public long BaseSalary { get; set; }

			/// <summary>
			/// Реальная з/п
			/// </summary>
			public long RealSalary { get; set; }

			/// <summary>
			/// Дата зачисления сотрудника в формате DateTime
			/// </summary>
			[NotMapped]
			public DateTime RecDate
			{
				get => recDate;
				set
				{
					recDate = value;
					recTimestamp = ((DateTimeOffset)value).ToUnixTimeSeconds();
				}
			}
			[NotMapped]
			private DateTime recDate;

			/// <summary>
			/// Список начальников всех уровней
			/// </summary>
			public List<int> AllLevelHeads { get; set; }

			/// <summary>
			/// Расчитывает количество лет, отработанных сотрудником
			/// </summary>
			private int CalculateYears()
			{
				var zeroDate = new DateTime(1, 1, 1);
				var span = CurrentDate - RecDate;
				return (zeroDate + span).Year - 1;
			}

			/// <summary>
			/// Расчитывает надбавку за стаж работы
			/// </summary>
			protected uint CalculateSA(double baseMult, double maxMult)
			{
				baseMult *= CalculateYears();
				if (baseMult > maxMult)
					baseMult = maxMult;
				var allowance = BaseSalary * baseMult;
				return (uint)allowance;
			}

			/// <summary>
			/// Выполняет поиск начальников всех уровней
			/// </summary>
			public void FindHeads()
			{
				AllLevelHeads = new List<int>();
				var personBuffer = this;
				while (personBuffer.Head != -1)
				{
					AllLevelHeads.Add(personBuffer.Head);
					personBuffer = Context.People.Find(personBuffer.Head);
				}
				if(Head == -1)
					AllLevelHeads.Add(Head);
			}

			/// <summary>
			/// Расчитывает суммарную з/п всех подчиненных в соответствии с выбранным способом поиска
			/// </summary>
			protected long GetSubSalaries(SubordinateSearchMode mode)
			{
				long total = 0;
				var selected = new List<Person>();
				switch (mode)
				{
					case SubordinateSearchMode.DirectOnly:
						foreach (var person in Context.People)
							if (person.Id != Id && person.Head == Id)
								selected.Add(person);
						break;
					case SubordinateSearchMode.All:
						foreach (var person in Context.People)
							if (person.Id != Id && person.AllLevelHeads.Contains(Id))
								selected.Add(person);
						break;
					default:
						return 0;
				}
				foreach (var person in selected)
				{
					total += person.RealSalary;
				}
				return total;
			}
			public abstract void CalculateRealSalary();
		}
	}
}


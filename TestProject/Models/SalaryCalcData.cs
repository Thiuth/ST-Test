using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.Service;

namespace TestProject.Models
{
	public partial class Model
	{
		//	Вложенный абстрактный класс, представляющий наборы данных и методов, необходимых для расчета з/п
		public abstract class SalaryCalcData
		{
			public int Id { get; set; }
			public DateTime RecDate { get; set; }
			public int HeadId { get; set; }
			public List<int> SubIds { get; set; }
			public uint BaseSalary { get; set; }
			public uint RealSalary { get; set; }

			//	Вычисляет количество отработанных лет
			private int CalculateYears()
			{
				var zeroDate = new DateTime(1, 1, 1);
				var span = CurrentDate - RecDate;
				return (zeroDate + span).Year - 1;
			}

			//	Вычисляет надбавку за отработанные годы
			protected uint CalculateSA(double baseMult, double maxMult)
			{
				baseMult *= CalculateYears();
				if (baseMult > maxMult)
					baseMult = maxMult;
				var allowance = BaseSalary * baseMult;
				return (uint)allowance;
			}

			//	Полуает ID'ы подчиненных для конкретного сотрудника
			public void GetSubIds()
			{
				SubIds = (SCD.Where(person => person.HeadId == Id).Select(person => person.Id)).ToList();
			}

			//	Вычисляет суммарные з/п подчиненных.
			//	Можно выбрать один из двух режимов: поиск либо только по прямым подчиненным, либо по подчиненным всех уровней.
			protected uint GetSubSalaries(SubordinateSearchMode mode)
			{
				uint total = 0;
				IEnumerable<SalaryCalcData> selected;
				switch (mode)
				{
					case SubordinateSearchMode.DirectOnly:
					{
						selected = SubIds.SelectMany(id => SCD.Where(person => person.Id == id).Select(person => person));
						break;
					}
					case SubordinateSearchMode.All:
					{
						var idListTotal = new List<int>();
						var idListLevel = SubIds;
						var levelBuffer = new List<int>();
						while (idListLevel.Count != 0)
						{
							idListTotal.AddRange(idListLevel);
							foreach (var id in idListLevel)
							{
								levelBuffer.AddRange(SCD.Find(p => p.Id == id).SubIds);
							}
							idListLevel = levelBuffer;
						}
						selected = idListTotal.SelectMany(id => SCD.Where(person => person.Id == id).Select(person => person));
						break;
					}
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

		//	Дочерние классы, реализующие расчет з/п для каждого типа сотрудников по отдельности
		//	Таким образом, можно расчитать з/п сотрудника, используя один и тот же метод и не уточняя параметров расчета.
		public class Employee : SalaryCalcData
		{
			public override void CalculateRealSalary()
			{
				RealSalary = BaseSalary
				 + CalculateSA(0.03, 0.30);
			}
		}

		public class Salesman : SalaryCalcData
		{
			public override void CalculateRealSalary()
			{
				RealSalary = BaseSalary
				 + CalculateSA(0.01, 0.35)
				 + (uint)(GetSubSalaries(SubordinateSearchMode.All) * 0.003);
			}
		}

		public class Manager : SalaryCalcData
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
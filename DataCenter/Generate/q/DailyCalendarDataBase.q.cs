//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

namespace table
{
	public static partial class DailyCalendarDataBaseExtensions
	{
		/// <summary>
		/// 通过[周历]二分快速查表
		/// </summary>
		/// <param name="dayIndex">周历</param>
		/// <returns></returns>
		public static DailyCalendarDataBase Query(this List<DailyCalendarDataBase> sorted, uint dayIndex)
		{
			var key = new DailyCalendarDataBase() { dayIndex = dayIndex };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(DailyCalendarDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<DailyCalendarDataBase>
		{
			public override int Compare(DailyCalendarDataBase a, DailyCalendarDataBase b)
			{
				{ var n = a.dayIndex.CompareTo(b.dayIndex); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

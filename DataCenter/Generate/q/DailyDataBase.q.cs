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
	public static partial class DailyDataBaseExtensions
	{
		/// <summary>
		/// 通过[id]二分快速查表
		/// </summary>
		/// <param name="id">id</param>
		/// <returns></returns>
		public static DailyDataBase Query(this List<DailyDataBase> sorted, uint id)
		{
			var key = new DailyDataBase() { id = id };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(DailyDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<DailyDataBase>
		{
			public override int Compare(DailyDataBase a, DailyDataBase b)
			{
				{ var n = a.id.CompareTo(b.id); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

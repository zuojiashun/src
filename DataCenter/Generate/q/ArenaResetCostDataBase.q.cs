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
	public static partial class ArenaResetCostDataBaseExtensions
	{
		/// <summary>
		/// 通过[次数]二分快速查表
		/// </summary>
		/// <param name="times">次数</param>
		/// <returns></returns>
		public static ArenaResetCostDataBase Query(this List<ArenaResetCostDataBase> sorted, uint times)
		{
			var key = new ArenaResetCostDataBase() { times = times };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(ArenaResetCostDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<ArenaResetCostDataBase>
		{
			public override int Compare(ArenaResetCostDataBase a, ArenaResetCostDataBase b)
			{
				{ var n = a.times.CompareTo(b.times); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

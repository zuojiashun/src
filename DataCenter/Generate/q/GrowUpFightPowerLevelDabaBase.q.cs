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
	public static partial class GrowUpFightPowerLevelDabaBaseExtensions
	{
		/// <summary>
		/// 通过[ID]二分快速查表
		/// </summary>
		/// <param name="dwID">ID</param>
		/// <returns></returns>
		public static GrowUpFightPowerLevelDabaBase Query(this List<GrowUpFightPowerLevelDabaBase> sorted, uint dwID)
		{
			var key = new GrowUpFightPowerLevelDabaBase() { dwID = dwID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(GrowUpFightPowerLevelDabaBase);
		}

		#region Comparer
		class Comparer1 : Comparer<GrowUpFightPowerLevelDabaBase>
		{
			public override int Compare(GrowUpFightPowerLevelDabaBase a, GrowUpFightPowerLevelDabaBase b)
			{
				{ var n = a.dwID.CompareTo(b.dwID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

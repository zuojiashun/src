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
	public static partial class HomeLandRecycleDatabaseExtensions
	{
		/// <summary>
		/// 通过[道具ID]二分快速查表
		/// </summary>
		/// <param name="wdID">道具ID</param>
		/// <returns></returns>
		public static HomeLandRecycleDatabase Query(this List<HomeLandRecycleDatabase> sorted, uint wdID)
		{
			var key = new HomeLandRecycleDatabase() { wdID = wdID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(HomeLandRecycleDatabase);
		}

		#region Comparer
		class Comparer1 : Comparer<HomeLandRecycleDatabase>
		{
			public override int Compare(HomeLandRecycleDatabase a, HomeLandRecycleDatabase b)
			{
				{ var n = a.wdID.CompareTo(b.wdID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

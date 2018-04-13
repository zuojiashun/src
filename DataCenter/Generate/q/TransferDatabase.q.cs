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
	public static partial class TransferDatabaseExtensions
	{
		/// <summary>
		/// 通过[地图ID]二分快速查表
		/// </summary>
		/// <param name="mapid">地图ID</param>
		/// <returns></returns>
		public static TransferDatabase Query(this List<TransferDatabase> sorted, uint mapid)
		{
			var key = new TransferDatabase() { mapid = mapid };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(TransferDatabase);
		}

		#region Comparer
		class Comparer1 : Comparer<TransferDatabase>
		{
			public override int Compare(TransferDatabase a, TransferDatabase b)
			{
				{ var n = a.mapid.CompareTo(b.mapid); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}
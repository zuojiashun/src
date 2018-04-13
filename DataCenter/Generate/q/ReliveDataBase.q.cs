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
	public static partial class ReliveDataBaseExtensions
	{
		/// <summary>
		/// 通过[复活ID]二分快速查表
		/// </summary>
		/// <param name="dwID">复活ID</param>
		/// <returns></returns>
		public static ReliveDataBase Query(this List<ReliveDataBase> sorted, uint dwID)
		{
			var key = new ReliveDataBase() { dwID = dwID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(ReliveDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<ReliveDataBase>
		{
			public override int Compare(ReliveDataBase a, ReliveDataBase b)
			{
				{ var n = a.dwID.CompareTo(b.dwID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}
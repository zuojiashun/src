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
	public static partial class WelfareDataBaseExtensions
	{
		/// <summary>
		/// 通过[ID]二分快速查表
		/// </summary>
		/// <param name="dwID">ID</param>
		/// <returns></returns>
		public static WelfareDataBase Query(this List<WelfareDataBase> sorted, uint dwID)
		{
			var key = new WelfareDataBase() { dwID = dwID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(WelfareDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<WelfareDataBase>
		{
			public override int Compare(WelfareDataBase a, WelfareDataBase b)
			{
				{ var n = a.dwID.CompareTo(b.dwID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

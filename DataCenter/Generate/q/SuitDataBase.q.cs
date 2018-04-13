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
	public static partial class SuitDataBaseExtensions
	{
		/// <summary>
		/// 通过[ID]二分快速查表
		/// </summary>
		/// <param name="base_id">ID</param>
		/// <returns></returns>
		public static IEnumerable<SuitDataBase> Query(this List<SuitDataBase> sorted, uint base_id)
		{
			var key = new SuitDataBase() { base_id = base_id };
			var comparer = new Comparer1();
			var from = sorted.BinarySearch(key, comparer);
			if (from < 0) yield break;
			var to = from + 1;
			while (from > 0 && comparer.Compare(key, sorted[from - 1]) == 0) from--;
			while (to < sorted.Count && comparer.Compare(key, sorted[to]) == 0) to++;
			for (var i = from; i < to; i++) yield return sorted[i];
		}
		/// <summary>
		/// 通过[ID + 时装档次]二分快速查表
		/// </summary>
		/// <param name="base_id">ID</param>
		/// <param name="suitLv">时装档次</param>
		/// <returns></returns>
		public static SuitDataBase Query(this List<SuitDataBase> sorted, uint base_id, uint suitLv)
		{
			var key = new SuitDataBase() { base_id = base_id, suitLv = suitLv };
			var comparer = new Comparer2();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(SuitDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<SuitDataBase>
		{
			public override int Compare(SuitDataBase a, SuitDataBase b)
			{
				{ var n = a.base_id.CompareTo(b.base_id); if (n != 0) return n; }
				return 0;
			}
		}
		class Comparer2 : Comparer<SuitDataBase>
		{
			public override int Compare(SuitDataBase a, SuitDataBase b)
			{
				{ var n = a.base_id.CompareTo(b.base_id); if (n != 0) return n; }
				{ var n = a.suitLv.CompareTo(b.suitLv); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}
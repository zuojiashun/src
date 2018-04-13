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
	public static partial class RSPropertyPromoteDataBaseExtensions
	{
		/// <summary>
		/// 通过[差值]二分快速查表
		/// </summary>
		/// <param name="diffValue">差值</param>
		/// <returns></returns>
		public static RSPropertyPromoteDataBase Query(this List<RSPropertyPromoteDataBase> sorted, uint diffValue)
		{
			var key = new RSPropertyPromoteDataBase() { diffValue = diffValue };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(RSPropertyPromoteDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<RSPropertyPromoteDataBase>
		{
			public override int Compare(RSPropertyPromoteDataBase a, RSPropertyPromoteDataBase b)
			{
				{ var n = a.diffValue.CompareTo(b.diffValue); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

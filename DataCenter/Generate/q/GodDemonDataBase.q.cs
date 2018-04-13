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
	public static partial class GodDemonDataBaseExtensions
	{
		/// <summary>
		/// 通过[神魔等级]二分快速查表
		/// </summary>
		/// <param name="level">神魔等级</param>
		/// <returns></returns>
		public static GodDemonDataBase Query(this List<GodDemonDataBase> sorted, uint level)
		{
			var key = new GodDemonDataBase() { level = level };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(GodDemonDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<GodDemonDataBase>
		{
			public override int Compare(GodDemonDataBase a, GodDemonDataBase b)
			{
				{ var n = a.level.CompareTo(b.level); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

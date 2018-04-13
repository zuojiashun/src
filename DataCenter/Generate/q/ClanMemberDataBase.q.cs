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
	public static partial class ClanMemberDataBaseExtensions
	{
		/// <summary>
		/// 通过[氏族等级]二分快速查表
		/// </summary>
		/// <param name="lv">氏族等级</param>
		/// <returns></returns>
		public static ClanMemberDataBase Query(this List<ClanMemberDataBase> sorted, uint lv)
		{
			var key = new ClanMemberDataBase() { lv = lv };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(ClanMemberDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<ClanMemberDataBase>
		{
			public override int Compare(ClanMemberDataBase a, ClanMemberDataBase b)
			{
				{ var n = a.lv.CompareTo(b.lv); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

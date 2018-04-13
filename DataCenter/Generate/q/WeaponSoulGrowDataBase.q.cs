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
	public static partial class WeaponSoulGrowDataBaseExtensions
	{
		/// <summary>
		/// 通过[武魂ID]二分快速查表
		/// </summary>
		/// <param name="id">武魂ID</param>
		/// <returns></returns>
		public static WeaponSoulGrowDataBase Query(this List<WeaponSoulGrowDataBase> sorted, uint id)
		{
			var key = new WeaponSoulGrowDataBase() { id = id };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(WeaponSoulGrowDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<WeaponSoulGrowDataBase>
		{
			public override int Compare(WeaponSoulGrowDataBase a, WeaponSoulGrowDataBase b)
			{
				{ var n = a.id.CompareTo(b.id); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

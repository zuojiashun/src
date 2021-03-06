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
	public static partial class EquipComposeDataBaseExtensions
	{
		/// <summary>
		/// 通过[装备ID]二分快速查表
		/// </summary>
		/// <param name="equipId">装备ID</param>
		/// <returns></returns>
		public static EquipComposeDataBase Query(this List<EquipComposeDataBase> sorted, uint equipId)
		{
			var key = new EquipComposeDataBase() { equipId = equipId };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(EquipComposeDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<EquipComposeDataBase>
		{
			public override int Compare(EquipComposeDataBase a, EquipComposeDataBase b)
			{
				{ var n = a.equipId.CompareTo(b.equipId); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

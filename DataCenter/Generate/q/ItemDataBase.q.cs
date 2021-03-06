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
	public static partial class ItemDataBaseExtensions
	{
		/// <summary>
		/// 通过[物品ID]二分快速查表
		/// </summary>
		/// <param name="itemID">物品ID</param>
		/// <returns></returns>
		public static ItemDataBase Query(this List<ItemDataBase> sorted, uint itemID)
		{
			var key = new ItemDataBase() { itemID = itemID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(ItemDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<ItemDataBase>
		{
			public override int Compare(ItemDataBase a, ItemDataBase b)
			{
				{ var n = a.itemID.CompareTo(b.itemID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

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
	public static partial class PetGuiYuanDataBaseExtensions
	{
		/// <summary>
		/// 通过[宠物品质]二分快速查表
		/// </summary>
		/// <param name="quality">宠物品质</param>
		/// <returns></returns>
		public static IEnumerable<PetGuiYuanDataBase> Query(this List<PetGuiYuanDataBase> sorted, uint quality)
		{
			var key = new PetGuiYuanDataBase() { quality = quality };
			var comparer = new Comparer1();
			var from = sorted.BinarySearch(key, comparer);
			if (from < 0) yield break;
			var to = from + 1;
			while (from > 0 && comparer.Compare(key, sorted[from - 1]) == 0) from--;
			while (to < sorted.Count && comparer.Compare(key, sorted[to]) == 0) to++;
			for (var i = from; i < to; i++) yield return sorted[i];
		}
		/// <summary>
		/// 通过[宠物品质 + 成长状态]二分快速查表
		/// </summary>
		/// <param name="quality">宠物品质</param>
		/// <param name="growStatus">成长状态</param>
		/// <returns></returns>
		public static PetGuiYuanDataBase Query(this List<PetGuiYuanDataBase> sorted, uint quality, uint growStatus)
		{
			var key = new PetGuiYuanDataBase() { quality = quality, growStatus = growStatus };
			var comparer = new Comparer2();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(PetGuiYuanDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<PetGuiYuanDataBase>
		{
			public override int Compare(PetGuiYuanDataBase a, PetGuiYuanDataBase b)
			{
				{ var n = a.quality.CompareTo(b.quality); if (n != 0) return n; }
				return 0;
			}
		}
		class Comparer2 : Comparer<PetGuiYuanDataBase>
		{
			public override int Compare(PetGuiYuanDataBase a, PetGuiYuanDataBase b)
			{
				{ var n = a.quality.CompareTo(b.quality); if (n != 0) return n; }
				{ var n = a.growStatus.CompareTo(b.growStatus); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

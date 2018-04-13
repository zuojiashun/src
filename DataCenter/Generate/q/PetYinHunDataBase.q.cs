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
	public static partial class PetYinHunDataBaseExtensions
	{
		/// <summary>
		/// 通过[修为等级]二分快速查表
		/// </summary>
		/// <param name="level">修为等级</param>
		/// <returns></returns>
		public static PetYinHunDataBase Query(this List<PetYinHunDataBase> sorted, uint level)
		{
			var key = new PetYinHunDataBase() { level = level };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(PetYinHunDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<PetYinHunDataBase>
		{
			public override int Compare(PetYinHunDataBase a, PetYinHunDataBase b)
			{
				{ var n = a.level.CompareTo(b.level); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

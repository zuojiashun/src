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
	public static partial class PetDataBaseExtensions
	{
		/// <summary>
		/// 通过[宠物ID]二分快速查表
		/// </summary>
		/// <param name="petID">宠物ID</param>
		/// <returns></returns>
		public static PetDataBase Query(this List<PetDataBase> sorted, uint petID)
		{
			var key = new PetDataBase() { petID = petID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(PetDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<PetDataBase>
		{
			public override int Compare(PetDataBase a, PetDataBase b)
			{
				{ var n = a.petID.CompareTo(b.petID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

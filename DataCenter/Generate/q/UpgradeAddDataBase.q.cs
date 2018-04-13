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
	public static partial class UpgradeAddDataBaseExtensions
	{
		/// <summary>
		/// 通过[世界等级差]二分快速查表
		/// </summary>
		/// <param name="worldlevdiff">世界等级差</param>
		/// <returns></returns>
		public static UpgradeAddDataBase Query(this List<UpgradeAddDataBase> sorted, uint worldlevdiff)
		{
			var key = new UpgradeAddDataBase() { worldlevdiff = worldlevdiff };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(UpgradeAddDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<UpgradeAddDataBase>
		{
			public override int Compare(UpgradeAddDataBase a, UpgradeAddDataBase b)
			{
				{ var n = a.worldlevdiff.CompareTo(b.worldlevdiff); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

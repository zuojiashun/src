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
	public static partial class StarQuestDataBaseExtensions
	{
		/// <summary>
		/// 通过[星级]二分快速查表
		/// </summary>
		/// <param name="dwID">星级</param>
		/// <returns></returns>
		public static StarQuestDataBase Query(this List<StarQuestDataBase> sorted, uint dwID)
		{
			var key = new StarQuestDataBase() { dwID = dwID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(StarQuestDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<StarQuestDataBase>
		{
			public override int Compare(StarQuestDataBase a, StarQuestDataBase b)
			{
				{ var n = a.dwID.CompareTo(b.dwID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

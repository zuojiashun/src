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
	public static partial class ChapterDabaBaseExtensions
	{
		/// <summary>
		/// 通过[章节ID]二分快速查表
		/// </summary>
		/// <param name="ID">章节ID</param>
		/// <returns></returns>
		public static ChapterDabaBase Query(this List<ChapterDabaBase> sorted, uint ID)
		{
			var key = new ChapterDabaBase() { ID = ID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(ChapterDabaBase);
		}

		#region Comparer
		class Comparer1 : Comparer<ChapterDabaBase>
		{
			public override int Compare(ChapterDabaBase a, ChapterDabaBase b)
			{
				{ var n = a.ID.CompareTo(b.ID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

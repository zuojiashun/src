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
	public static partial class ShowEffectExtensions
	{
		/// <summary>
		/// 通过[ID]二分快速查表
		/// </summary>
		/// <param name="TableID">ID</param>
		/// <returns></returns>
		public static ShowEffect Query(this List<ShowEffect> sorted, uint TableID)
		{
			var key = new ShowEffect() { TableID = TableID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(ShowEffect);
		}

		#region Comparer
		class Comparer1 : Comparer<ShowEffect>
		{
			public override int Compare(ShowEffect a, ShowEffect b)
			{
				{ var n = a.TableID.CompareTo(b.TableID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

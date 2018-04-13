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
	public static partial class GuideTriggerCondiDataBaseExtensions
	{
		/// <summary>
		/// 通过[ID]二分快速查表
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns></returns>
		public static GuideTriggerCondiDataBase Query(this List<GuideTriggerCondiDataBase> sorted, uint id)
		{
			var key = new GuideTriggerCondiDataBase() { id = id };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(GuideTriggerCondiDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<GuideTriggerCondiDataBase>
		{
			public override int Compare(GuideTriggerCondiDataBase a, GuideTriggerCondiDataBase b)
			{
				{ var n = a.id.CompareTo(b.id); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

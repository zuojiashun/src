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
	public static partial class AcceptTokenDataBaseExtensions
	{
		/// <summary>
		/// 通过[id]二分快速查表
		/// </summary>
		/// <param name="id">id</param>
		/// <returns></returns>
		public static AcceptTokenDataBase Query(this List<AcceptTokenDataBase> sorted, uint id)
		{
			var key = new AcceptTokenDataBase() { id = id };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(AcceptTokenDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<AcceptTokenDataBase>
		{
			public override int Compare(AcceptTokenDataBase a, AcceptTokenDataBase b)
			{
				{ var n = a.id.CompareTo(b.id); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}
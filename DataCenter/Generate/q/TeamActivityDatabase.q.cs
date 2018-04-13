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
	public static partial class TeamActivityDatabaseExtensions
	{
		/// <summary>
		/// 通过[ID]二分快速查表
		/// </summary>
		/// <param name="ID">ID</param>
		/// <returns></returns>
		public static TeamActivityDatabase Query(this List<TeamActivityDatabase> sorted, uint ID)
		{
			var key = new TeamActivityDatabase() { ID = ID };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(TeamActivityDatabase);
		}

		#region Comparer
		class Comparer1 : Comparer<TeamActivityDatabase>
		{
			public override int Compare(TeamActivityDatabase a, TeamActivityDatabase b)
			{
				{ var n = a.ID.CompareTo(b.ID); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

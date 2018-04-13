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
	public static partial class PreloadSkillResDataBaseExtensions
	{
		/// <summary>
		/// 通过[技能ID]二分快速查表
		/// </summary>
		/// <param name="skillId">技能ID</param>
		/// <returns></returns>
		public static PreloadSkillResDataBase Query(this List<PreloadSkillResDataBase> sorted, uint skillId)
		{
			var key = new PreloadSkillResDataBase() { skillId = skillId };
			var comparer = new Comparer1();
			var index = sorted.BinarySearch(key, comparer);
			return index >= 0 ? sorted[index] : default(PreloadSkillResDataBase);
		}

		#region Comparer
		class Comparer1 : Comparer<PreloadSkillResDataBase>
		{
			public override int Compare(PreloadSkillResDataBase a, PreloadSkillResDataBase b)
			{
				{ var n = a.skillId.CompareTo(b.skillId); if (n != 0) return n; }
				return 0;
			}
		}
		#endregion
	}
}

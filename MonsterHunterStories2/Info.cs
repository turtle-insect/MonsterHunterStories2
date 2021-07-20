using System;
using System.Collections.Generic;

namespace MonsterHunterStories2
{
	class Info
	{
		private static Info mThis;
		public List<KeyValuesInfo> Item { get; private set; } = new List<KeyValuesInfo>();
		public List<KeyValuesInfo> Monster { get; private set; } = new List<KeyValuesInfo>();
		public List<KeyValuesInfo> RideAction { get; private set; } = new List<KeyValuesInfo>();
		public List<KeyValuesInfo> Gene { get; private set; } = new List<KeyValuesInfo>();
		public Dictionary<uint, List<KeyValuesInfo>> Weapon { get; private set; } = new Dictionary<uint, List<KeyValuesInfo>>();
		private Info() { }

		public static Info Instance()
		{
			if (mThis == null)
			{
				mThis = new Info();
				mThis.Init();
			}
			return mThis;
		}

		public KeyValuesInfo Search<Type>(List<Type> list, uint id)
			where Type : KeyValuesInfo, new()
		{
			int min = 0;
			int max = list.Count;
			for (; min < max;)
			{
				int mid = (min + max) / 2;
				if (list[mid].Key == id) return list[mid];
				else if (list[mid].Key > id) max = mid;
				else min = mid + 1;
			}
			return null;
		}

		private void Init()
		{
			AppendList("info\\item.txt", Item);
			AppendList("info\\monster.txt", Monster);
			AppendList("info\\ride.txt", RideAction);
			AppendList("info\\gene.txt", Gene);

			String[] weapons = { "greatsword.txt", "swordshield.txt", "hammer.txt", "huntinghorn.txt", "gunlance.txt", "bow.txt" };
			for (uint i = 0; i < weapons.Length; i++)
			{
				var info = new List<KeyValuesInfo>();
				AppendList(System.IO.Path.Combine("info\\weapon", weapons[i]), info);
				info.Sort();
				Weapon.Add(i, info);
			}

			Item.Sort();
			Monster.Sort();
			RideAction.Sort();
			Gene.Sort();
		}

		private void AppendList<Type>(String filename, List<Type> items)
			where Type : ILineAnalysis, new()
		{
			if (!System.IO.File.Exists(filename)) return;
			String[] lines = System.IO.File.ReadAllLines(filename);
			foreach (String line in lines)
			{
				if (line.Length < 3) continue;
				if (line[0] == '#') continue;
				String[] values = line.Split('\t');
				if (values.Length < 2) continue;
				if (String.IsNullOrEmpty(values[0])) continue;

				Type type = new Type();
				if (type.Line(values))
				{
					items.Add(type);
				}
			}

			items.Sort();
		}
	}
}

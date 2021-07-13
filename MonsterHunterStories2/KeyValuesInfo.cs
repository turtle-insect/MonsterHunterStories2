using System;

namespace MonsterHunterStories2
{
	class KeyValuesInfo : ILineAnalysis, IComparable
	{
		public uint Key { get; private set; }
		public String[] Values { get; private set; }
		public String Value
		{
			get { return Values[Properties.Settings.Default.Langage]; }
		}

		public int CompareTo(object obj)
		{
			var dist = obj as KeyValuesInfo;
			if (dist == null) return 0;

			if (Key < dist.Key) return -1;
			else if (Key > dist.Key) return 1;
			else return 0;
		}

		public virtual bool Line(String[] oneLine)
		{
			if (oneLine[0].Length > 1 && oneLine[0][1] == 'x') Key = Convert.ToUInt32(oneLine[0], 16);
			else Key = Convert.ToUInt32(oneLine[0]);
			Values = new string[oneLine.Length - 1];
			for (int i = 0; i < oneLine.Length - 1; i++)
			{
				Values[i] = oneLine[i + 1];
			}
			return true;
		}
	}
}
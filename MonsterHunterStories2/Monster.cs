using System;
using System.ComponentModel;

namespace MonsterHunterStories2
{
	class Monster : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;

		public Monster(uint address)
		{
			mAddress = address;
		}

		public String Name
		{
			get { return SaveData.Instance().ReadText(mAddress, 18); }
			set
			{
				SaveData.Instance().WriteText(mAddress, 18, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
			}
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 52, 4); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress + 52, 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 86, 1); }
			set { Util.WriteNumber(mAddress + 86, 1, value, 1, 0xFF); }
		}

		public uint Exp
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 188, 4); }
			set { Util.WriteNumber(mAddress + 188, 4, value, 0, 99999999); }
		}
	}
}

using System.ComponentModel;

namespace MonsterHunterStories2
{
	class Talisman : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;

		public Talisman(uint address)
		{
			mAddress = address;
		}

		public uint Type
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 2); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
			}
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 2, 2); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress + 2, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 4, 2); }
			set { Util.WriteNumber(mAddress + 4, 2, value, 1, 0xFFFF); }
		}

		public uint Skill1
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 40, 2); }
			set 
			{
				Util.WriteNumber(mAddress + 40, 2, value, 0, 0xFFFF);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Skill1)));
			}
		}

		public uint Skill2
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 42, 2); }
			set
			{
				Util.WriteNumber(mAddress + 42, 2, value, 0, 0xFFFF);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Skill2)));
			}
		}

		public uint Rarity
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 36, 1); }
			set { Util.WriteNumber(mAddress + 36, 1, value, 0, 7); }
		}

	}
}

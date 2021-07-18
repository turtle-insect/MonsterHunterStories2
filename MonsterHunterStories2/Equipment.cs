using System;
using System.ComponentModel;

namespace MonsterHunterStories2
{
	class Equipment : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;

		public Equipment(uint address)
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

		public uint Skill_1
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 20, 3); }
			set { Util.WriteNumber(mAddress + 20, 3, value, 1, 0xFFFFFF); }
		}
		public string Skill_1_Hex
		{
			get { return SaveData.Instance().ReadHex(mAddress + 20, 3); }
			set { SaveData.Instance().WriteHex(mAddress + 20,  value); }
		}

		public uint Skill_2
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 24, 3); }
			set { Util.WriteNumber(mAddress + 24, 3, value, 1, 0xFFFFFF); }
		}
		public string Skill_2_Hex
		{
			get { return SaveData.Instance().ReadHex(mAddress + 24, 3); }
			set { SaveData.Instance().WriteHex(mAddress + 24, value); }
		}
	}
}

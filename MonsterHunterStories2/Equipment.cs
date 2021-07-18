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

		public uint ArmorsMainR
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 20, 1); }
			set { Util.WriteNumber(mAddress + 20, 1, value, 0, 255); }
		}

		public uint ArmorsMainG
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 21, 1); }
			set { Util.WriteNumber(mAddress + 21, 1, value, 0, 255); }
		}

		public uint ArmorsMainB
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 22, 1); }
			set { Util.WriteNumber(mAddress + 22, 1, value, 0, 255); }
		}
		public uint ArmorsDR
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 24, 1); }
			set { Util.WriteNumber(mAddress + 24, 1, value, 0, 255); }
		}

		public uint ArmorsDG
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 25, 1); }
			set { Util.WriteNumber(mAddress + 25, 1, value, 0, 255); }
		}

		public uint ArmorsDB
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 26, 1); }
			set { Util.WriteNumber(mAddress + 26, 1, value, 0, 255); }
		}
		public uint TalismansSkill_1
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 40, 2); }
			set { Util.WriteNumber(mAddress + 40, 2, value, 1, 0xFFFF); }
		}
		public uint TalismansSkill_2
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 42, 2); }
			set { Util.WriteNumber(mAddress + 42, 2, value, 1, 0xFFFF); }
		}
		
	}
}

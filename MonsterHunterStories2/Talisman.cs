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
				AddRarity(value, Skill2);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Skill1)));
				
			}
		}

		public uint Skill2
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 42, 2); }
			set
			{
				Util.WriteNumber(mAddress + 42, 2, value, 0, 0xFFFF);
				AddRarity(Skill1, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Skill2)));
			}
		}

		public uint Rarity
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 36, 1); }
			set
			{
				Util.WriteNumber(mAddress + 36, 1, value, 0, 7);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rarity)));
			}
		}
		private uint CalculateRarity(uint skill)
		{
			uint rarity = 0;
            if (skill == 3015 || skill == 3017 || skill == 3106 || skill == 3108 || skill == 3110)
            {
				rarity = 2;
			}
			else if(skill > 2999 && skill < 3014)
			{
				rarity = (skill + 1) % 5;
			}
			else if(skill > 3018 && skill < 3105)
            {
				rarity = (skill - 3) % 5;
            }
			else if(skill > 3111 && skill < 3316)
            {
				rarity = (skill - 1) % 5;
			}
			return rarity;
		}
		private void AddRarity(uint skill1,uint skill2)
        {
			uint rarity1 = CalculateRarity(skill1);
			uint rarity2 = CalculateRarity(skill2);
			if (rarity1 == 0 && rarity2 == 0) Rarity = 0;
			else Rarity = rarity1 + rarity2 - 1;
		}
	}
}

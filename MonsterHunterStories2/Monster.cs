using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			get { return SaveData.Instance().ReadNumber(mAddress + 48, 4); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress + 48, 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 86, 1); }
			set { Util.WriteNumber(mAddress + 86, 1, value, 1, 0xFF); }
		}
	}
}

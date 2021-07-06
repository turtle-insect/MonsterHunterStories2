using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterStories2
{
	class Weapon : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;

		public Weapon(uint address)
		{
			mAddress = address;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 4); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress, 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
			}
		}

		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 4, 2); }
			set { Util.WriteNumber(mAddress + 4, 2, value, 1, 0xFFFF); }
		}
	}
}

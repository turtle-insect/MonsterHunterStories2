using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MonsterHunterStories2
{
	class Armor : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;

		public Armor(uint address)
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

		public uint MainR
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 20, 1); }
			set { Util.WriteNumber(mAddress + 20, 1, value, 0, 255); }
		}

		public uint MainG
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 21, 1); }
			set { Util.WriteNumber(mAddress + 21, 1, value, 0, 255); }
		}

		public uint MainB
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 22, 1); }
			set { Util.WriteNumber(mAddress + 22, 1, value, 0, 255); }
		}
		public uint DR
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 24, 1); }
			set { Util.WriteNumber(mAddress + 24, 1, value, 0, 255); }
		}

		public uint DG
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 25, 1); }
			set { Util.WriteNumber(mAddress + 25, 1, value, 0, 255); }
		}

		public uint DB
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 26, 1); }
			set { Util.WriteNumber(mAddress + 26, 1, value, 0, 255); }
		}
	}
}

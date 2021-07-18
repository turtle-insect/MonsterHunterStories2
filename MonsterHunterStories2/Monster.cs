using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MonsterHunterStories2
{
	class Monster : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<Gene> Genes { get; set; } = new ObservableCollection<Gene>();

		private readonly uint mAddress;

		public Monster(uint address)
		{
			mAddress = address;
			for (uint i = 0; i < 9; i++)
			{
				Genes.Add(new Gene(address + 332 + 4 * i));
			}
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

		public uint RideAction1
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 60, 1); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress + 60, 1, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RideAction1)));
			}
		}

		public uint RideAction2
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 61, 1); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress + 61, 1, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RideAction2)));
			}
		}

		public void MaximizeGeneStack()
		{
			foreach(Gene gene in Genes)
			{
				gene.Stack = 2;
			}
		}
	}
}

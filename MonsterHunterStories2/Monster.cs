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
			foreach (Gene gene in Genes)
			{
				gene.Stack = 2;
			}
		}
		public uint CurrentHP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 72, 4); }
			set { Util.WriteNumber(mAddress + 72, 4, value, 0, 999999); }
		}

		public uint MaxHP
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 76, 4); }
			set { Util.WriteNumber(mAddress + 76, 4, value, 0, 999999); }
		}

		public uint Speed
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 80, 4); }
			set { Util.WriteNumber(mAddress + 80, 4, value, 0, 999999); }
		}

		public uint NormalElementAttack
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 132, 2); }
			set { Util.WriteNumber(mAddress + 132, 2, value, 0, 0xFFFF); }
		}

		public uint FireElementAttack
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 134, 2); }
			set { Util.WriteNumber(mAddress + 134, 2, value, 0, 0xFFFF); }
		}

		public uint WaterElementAttack
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 136, 2); }
			set { Util.WriteNumber(mAddress + 136, 2, value, 0, 0xFFFF); }
		}

		public uint ThunderElementAttack
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 138, 2); }
			set { Util.WriteNumber(mAddress + 138, 2, value, 0, 0xFFFF); }
		}

		public uint IceElementAttack
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 140, 2); }
			set { Util.WriteNumber(mAddress + 140, 2, value, 0, 0xFFFF); }
		}

		public uint DragonElementAttack
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 142, 2); }
			set { Util.WriteNumber(mAddress + 142, 2, value, 0, 0xFFFF); }
		}

		public uint NormalElementDefense
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 152, 2); }
			set { Util.WriteNumber(mAddress + 152, 2, value, 0, 0xFFFF); }
		}

		public uint FireElementDefense
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 154, 2); }
			set { Util.WriteNumber(mAddress + 154, 2, value, 0, 0xFFFF); }
		}

		public uint WaterElementDefense
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 156, 2); }
			set { Util.WriteNumber(mAddress + 156, 2, value, 0, 0xFFFF); }
		}

		public uint ThunderElementDefense
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 158, 2); }
			set { Util.WriteNumber(mAddress + 158, 2, value, 0, 0xFFFF); }
		}

		public uint IceElementDefense
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 160, 2); }
			set { Util.WriteNumber(mAddress + 160, 2, value, 0, 0xFFFF); }
		}

		public uint DragonElementDefense
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 162, 2); }
			set { Util.WriteNumber(mAddress + 162, 2, value, 0, 0xFFFF); }
		}

		public uint HPBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 168, 1); }
			set { Util.WriteNumber(mAddress + 168, 1, value, 0, 0xFF); }
		}

		public uint NormalElementAttackBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 169, 1); }
			set { Util.WriteNumber(mAddress + 169, 1, value, 0, 0xFF); }
		}

		public uint FireElementAttackBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 170, 1); }
			set { Util.WriteNumber(mAddress + 170, 1, value, 0, 0xFF); }
		}

		public uint WaterElementAttackBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 171, 1); }
			set { Util.WriteNumber(mAddress + 171, 1, value, 0, 0xFF); }
		}

		public uint ThunderElementAttackBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 172, 1); }
			set { Util.WriteNumber(mAddress + 172, 1, value, 0, 0xFF); }
		}

		public uint IceElementAttackBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 173, 1); }
			set { Util.WriteNumber(mAddress + 173, 1, value, 0, 0xFF); }
		}

		public uint DragonElementAttackBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 174, 1); }
			set { Util.WriteNumber(mAddress + 174, 1, value, 0, 0xFF); }
		}

		public uint NormalElementDefenseBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 175, 1); }
			set { Util.WriteNumber(mAddress + 175, 1, value, 0, 0xFF); }
		}

		public uint FireElementDefenseBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 176, 1); }
			set { Util.WriteNumber(mAddress + 176, 1, value, 0, 0xFF); }
		}

		public uint WaterElementDefenseBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 177, 1); }
			set { Util.WriteNumber(mAddress + 177, 1, value, 0, 0xFF); }
		}

		public uint ThunderElementDefenseBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 178, 1); }
			set { Util.WriteNumber(mAddress + 178, 1, value, 0, 0xFF); }
		}

		public uint IceElementDefenseBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 179, 1); }
			set { Util.WriteNumber(mAddress + 179, 1, value, 0, 0xFF); }
		}

		public uint DragonElementDefenseBonus
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 180, 1); }
			set { Util.WriteNumber(mAddress + 180, 1, value, 0, 0xFF); }
		}
	}
}

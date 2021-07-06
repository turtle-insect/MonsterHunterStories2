using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterStories2
{
	class ViewModel
	{
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<Weapon> Weapons { get; set; } = new ObservableCollection<Weapon>();
		public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
		public ObservableCollection<Monster> Monsters { get; set; } = new ObservableCollection<Monster>();
		public ViewModel()
		{
			foreach(var itemInfo in Info.Instance().Item)
			{
				uint address = Util.ItemIDAddress(itemInfo.Value);
				Item item = new Item(address);
				if (item.ID == 0) continue;
				if (item.Count == 0) continue;

				Items.Add(item);
			}

			for (uint i = 0; i < Util.WEAPON_COUNT; i++)
			{
				uint address = Util.WEAPON_ADDRESS + Util.WEAPON_SIZE * i;
				Weapon weapon = new Weapon(address);
				Weapons.Add(weapon);
			}

			for (uint i = 0; i < Util.CHARACTER_COUNT; i++)
			{
				uint address = Util.CHARACTER_ADDRESS + Util.CHARACTER_SIZE * i;
				Character chara = new Character(address);
				if (String.IsNullOrEmpty(chara.Name)) continue;

				Characters.Add(chara);
			}

			for (uint i = 0; i < Util.MONSTER_COUNT; i++)
			{
				uint address = Util.MONSTER_ADDRESS + Util.MONSTER_SIZE * i;
				Monster monster = new Monster(address);
				if (String.IsNullOrEmpty(monster.Name)) continue;

				Monsters.Add(monster);
			}
		}

		public uint Money
		{
			get { return SaveData.Instance().ReadNumber(0x48, 4); }
			set { Util.WriteNumber(0x48, 4, value, 0, 9999999); }
		}
	}
}

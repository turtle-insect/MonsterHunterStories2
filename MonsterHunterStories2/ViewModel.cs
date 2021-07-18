using System;
using System.Collections.ObjectModel;

namespace MonsterHunterStories2
{
	class ViewModel
	{
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<Equipment> Weapons { get; set; } = new ObservableCollection<Equipment>();
		public ObservableCollection<Equipment> Armors { get; set; } = new ObservableCollection<Equipment>();
		public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
		public ObservableCollection<Monster> Monsters { get; set; } = new ObservableCollection<Monster>();
		public ObservableCollection<Egg> Eggs { get; set; } = new ObservableCollection<Egg>();
		public ViewModel()
		{
			foreach(var itemInfo in Info.Instance().Item)
			{
				uint address = Util.ItemIDAddress(itemInfo.Key);
				Item item = new Item(address);
				if (item.ID == 0) continue;
				if (item.Count == 0) continue;

				Items.Add(item);
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

			uint count = SaveData.Instance().ReadNumber(Util.EGG_COUNT_ADDRESS, 1);
			for (uint i = 0; i < count; i++)
			{
				uint address = Util.EGG_ADDRESS + Util.EGG_SIZE * i;
				Egg egg = new Egg(address);
				Eggs.Add(egg);
			}

			for (uint i = 0; i < Util.WEAPON_COUNT; i++)
			{
				uint address = Util.WEAPON_ADDRESS + Util.WEAPON_SIZE * i;
				Equipment weapon = new Equipment(address);
				Weapons.Add(weapon);
			}

			for (uint i = 0; i < Util.ARMOR_COUNT; i++)
			{
				uint address = Util.ARMOR_ADDRESS + Util.ARMOR_SIZE * i;
				Equipment armor = new Equipment(address);
				Armors.Add(armor);
			}
		}

		public uint Money
		{
			get { return SaveData.Instance().ReadNumber(72, 4); }
			set { Util.WriteNumber(72, 4, value, 0, 9999999); }
		}

		public uint PlayTimeHour
		{
			get { return SaveData.Instance().ReadNumber(64, 4) / 3600; }
			set
			{
				uint time = SaveData.Instance().ReadNumber(64, 4) % 3600 + value * 3600;
				SaveData.Instance().WriteNumber(64, 4, time);
			}
		}

		public uint PlayTimeMinute
		{
			get { return SaveData.Instance().ReadNumber(64, 4) / 60 % 60; }
			set
			{
				if (value < 0) value = 0;
				if (value > 59) value = 59;
				uint time = SaveData.Instance().ReadNumber(64, 4) / 3600 * 3600 + value * 60;
				SaveData.Instance().WriteNumber(64, 4, time);
			}
		}
	}
}

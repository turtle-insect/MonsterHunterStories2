using System;
using System.Collections.ObjectModel;

namespace MonsterHunterStories2
{
	class ViewModel
	{
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<Weapon> Weapons { get; set; } = new ObservableCollection<Weapon>();
		public ObservableCollection<Armor> Armors { get; set; } = new ObservableCollection<Armor>();
		public ObservableCollection<Talisman> Talismans { get; set; } = new ObservableCollection<Talisman>();
		public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
		public ObservableCollection<Monster> Monsters { get; set; } = new ObservableCollection<Monster>();
		public ObservableCollection<Egg> Eggs { get; set; } = new ObservableCollection<Egg>();
		public ObservableCollection<Guide> Guides { get; set; } = new ObservableCollection<Guide>();
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
				Character chara = new Character(Util.CHARACTER_ADDRESS + Util.CHARACTER_SIZE * i);
				if (String.IsNullOrEmpty(chara.Name)) continue;

				Characters.Add(chara);
			}

			for (uint i = 0; i < Util.MONSTER_COUNT; i++)
			{
				Monster monster = new Monster(Util.MONSTER_ADDRESS + Util.MONSTER_SIZE * i);
				if (String.IsNullOrEmpty(monster.Name)) continue;

				Monsters.Add(monster);
			}

			uint count = SaveData.Instance().ReadNumber(Util.EGG_COUNT_ADDRESS, 1);
			for (uint i = 0; i < count; i++)
			{
				Egg egg = new Egg(Util.EGG_ADDRESS + Util.EGG_SIZE * i);
				Eggs.Add(egg);
			}

			for (uint i = 0; i < Util.WEAPON_COUNT; i++)
			{
				Weapon weapon = new Weapon(Util.WEAPON_ADDRESS + Util.WEAPON_SIZE * i);
				Weapons.Add(weapon);
			}

			for (uint i = 0; i < Util.ARMOR_COUNT; i++)
			{
				Armor armor = new Armor(Util.ARMOR_ADDRESS + Util.ARMOR_SIZE * i);
				Armors.Add(armor);
			}

			for (uint i = 0; i < Util.TALISMAN_COUNT; i++)
			{
				Talisman Talisman = new Talisman(Util.TALISMAN_ADDRESS + Util.TALISMAN_SIZE * i);
				Talismans.Add(Talisman);
			}

			for (uint i = 0; i < Util.Guide_COUNT; i++)
			{
				Guide guide = new Guide(Util.Guide_ADDRESS + Util.Guide_SIZE * i);
				Guides.Add(guide);
			}
		}

		public uint Money
		{
			get {return SaveData.Instance().ReadNumber(Util.MONEY_ADDRESS, 4);}
			set {Util.WriteNumber(Util.MONEY_ADDRESS, 4, value, 0, 9999999);}
		}
		
		public uint PlayTimeHour
		{
			get {return SaveData.Instance().ReadNumber(64, 4) / 3600;}
			set
			{
				uint time = SaveData.Instance().ReadNumber(64, 4) % 3600 + value * 3600;
				SaveData.Instance().WriteNumber(64, 4, time);
			}
		}

		public uint PlayTimeMinute
		{
			get {return SaveData.Instance().ReadNumber(64, 4) / 60 % 60;}
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

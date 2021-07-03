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
		}

		public uint Money
		{
			get { return SaveData.Instance().ReadNumber(0x48, 4); }
			set { Util.WriteNumber(0x48, 4, value, 0, 9999999); }
		}
	}
}

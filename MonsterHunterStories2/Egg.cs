using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MonsterHunterStories2
{
	class Egg : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<Gene> Genes { get; set; } = new ObservableCollection<Gene>();

		public uint Address { get; private set; }

		public Egg(uint address)
		{
			Address = address;
			for (uint i = 0; i < 9; i++)
			{
				Genes.Add(new Gene(address + 8 + 4 * i));
			}
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(Address, 4); }
			set
			{
				SaveData.Instance().WriteNumber(Address, 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Smell
		{
			get { return SaveData.Instance().ReadNumber(Address + 4, 1); }
			set
			{
				Util.WriteNumber(Address + 4, 1, value, 0, 2);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Smell)));
			}
		}
	}
}

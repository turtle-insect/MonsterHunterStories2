using System.ComponentModel;

namespace MonsterHunterStories2
{
	class Guide : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;

		public Guide(uint address)
		{
			mAddress = address;
		}
		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 2); }
		}
		//Lv = 1 is None , 5 is Full  ?????  Prepare for the evening test
		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 4, 1); }
			set { Util.WriteNumber(mAddress + 4, 1, value, 1, 5 ); }
		}
		public bool Get
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 20, 1) == 1; }
			set { SaveData.Instance().WriteNumber(mAddress + 20, 1, value == true ? 1U : 0); }
		}
	}
}
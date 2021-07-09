using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MonsterHunterStories2
{
	class Character : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;

		public Character(uint address)
		{
			mAddress = address;
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

		public uint Lv
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 234, 1); }
			set { Util.WriteNumber(mAddress + 234, 1, value, 1, 0xFF); }
		}

		public uint Exp
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 336, 4); }
			set { Util.WriteNumber(mAddress + 336, 4, value, 0, 9999999); }
		}

		public uint SkinR
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 64, 1); }
			set
			{
				Util.WriteNumber(mAddress + 64, 1, value, 0, 255);
				Util.WriteNumber(mAddress + 188, 1, value, 0, 255);
			}
		}

		public uint SkinG
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 65, 1); }
			set
			{
				Util.WriteNumber(mAddress + 65, 1, value, 0, 255);
				Util.WriteNumber(mAddress + 189, 1, value, 0, 255);
			}
		}

		public uint SkinB
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 66, 1); }
			set
			{
				Util.WriteNumber(mAddress + 66, 1, value, 0, 255);
				Util.WriteNumber(mAddress + 190, 1, value, 0, 255);
			}
		}

		public uint HairStyle
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 140, 1); }
			set { SaveData.Instance().WriteNumber(mAddress + 140, 1, value); }
		}

		public uint Eyes
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 168, 1); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress + 168, 1, value);
				SaveData.Instance().WriteNumber(mAddress + 174, 1, value);
			}
		}

		public uint Mouth
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 169, 1); }
			set { SaveData.Instance().WriteNumber(mAddress + 169, 1, value); }
		}

		public uint Makeup
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 170, 1); }
			set { SaveData.Instance().WriteNumber(mAddress + 170, 1, value); }
		}

		public uint BodyType
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 180, 1); }
			set { Util.WriteNumber(mAddress + 180, 1, value, 0, 1); }
		}

		public uint FaceShape
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 182, 1); }
			set { SaveData.Instance().WriteNumber(mAddress + 182, 1, value); }
		}

		public uint Voice
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 183, 1); }
			set { SaveData.Instance().WriteNumber(mAddress + 183, 1, value); }
		}


	}
}

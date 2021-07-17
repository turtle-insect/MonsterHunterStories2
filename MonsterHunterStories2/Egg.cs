using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MonsterHunterStories2
{
	class Egg : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<Gene> Genes { get; set; } = new ObservableCollection<Gene>();

		private readonly uint mAddress;

        //public Egg(uint address)
        //{
        //    mAddress = address;
        //    for (uint i = 0; i < 9; i++)
        //    {
        //        Genes.Add(new Gene(address + 8 + 4 * i));
        //    }
        //}
        public Egg(uint address)
		{
			mAddress = address;
		}
		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress, 4); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress, 4, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}
		public static string byteToHexStr(byte[] bytes)
		{
			string returnStr = "";
			if (bytes != null)
			{
				for (int i = 0; i < bytes.Length; i++)
				{
					returnStr += bytes[i].ToString("X2");
				}
			}
			return returnStr;
		}

		public static byte[] StrToHexByte(string hexString)
		{
			hexString = hexString.Replace(" ", "");
			if ((hexString.Length % 2) != 0)
				hexString += " ";
			byte[] returnBytes = new byte[hexString.Length / 2];
			for (int i = 0; i < returnBytes.Length; i++)
				returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
			return returnBytes;
		}

		public string Smell
		{
			get {
				byte[] str = SaveData.Instance().ReadValue(mAddress, 120);
				string strr = "";
				if (SaveData.Instance().ReadNumber(mAddress, 4) == 0)
                {
					strr = "None";
				}
				else strr = byteToHexStr(str);

				return strr; }
			set
			{
				byte[] str = StrToHexByte(value);
				SaveData.Instance().WriteValue(mAddress, str);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Smell)));
			}
		}
	}
}

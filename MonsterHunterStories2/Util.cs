using System;
using System.Collections.Generic;

namespace MonsterHunterStories2
{
	class Util
	{
		public const uint PC_ADDRESS = 0x30;

		public const uint CHARACTER_ADDRESS = 0x2D2A98;
		public const uint CHARACTER_COUNT = 31;
		public const uint CHARACTER_SIZE = 596;

		public const uint MONSTER_ADDRESS = 0x2D72C8;
		public const uint MONSTER_COUNT = 500;
		public const uint MONSTER_SIZE = 412;

		public const uint EGG_ADDRESS = 0x10CAC;
		public const uint EGG_COUNT = 12;
		public const uint EGG_SIZE = 120;
		public const uint EGG_COUNT_ADDRESS = 0x10C4A;

		public const uint WEAPON_ADDRESS = 0x3ECC;
		public const uint WEAPON_COUNT = 700;
		public const uint WEAPON_SIZE = 36;

		public const uint ARMOR_ADDRESS = 0xA13C;
		public const uint ARMOR_COUNT = 400;
		public const uint ARMOR_SIZE = 36;

		public const uint TALISMAN_ADDRESS = 0xD97C;
		public const uint TALISMAN_COUNT = 200;
		public const uint TALISMAN_SIZE = 48;

		public const uint ITEMSETTING_ADDRESS = 0x12B68;
		public const uint MONEY_ADDRESS = 0x48;
		public const uint ITEM_ADDRESS = 0x4C;
		//Debug
		public const uint Guide_ADDRESS = 0x2CB37C;
		public const uint Guide_COUNT = 512;
		public const uint Guide_SIZE = 48;

		public static void WriteNumber(uint address, uint size, uint value, uint min, uint max)
		{
			if (value < min) value = min;
			if (value > max) value = max;
			SaveData.Instance().WriteNumber(address, size, value);
		}

		public static uint ItemIDAddress(uint id)
		{
			return ITEM_ADDRESS + id * 8;
		}

		public static String ReadHex(uint address, uint size)
		{
			byte[] bytes = SaveData.Instance().ReadValue(address, size);
			if (bytes == null) return "";

			var hexText = new System.Text.StringBuilder();
			for (int i = 0; i < bytes.Length; i++)
			{
				if (i % 2 == 0 && i != 0) hexText.Append(" ");
				hexText.Append(bytes[i].ToString("X2"));
			}
			return hexText.ToString();
		}

		public static void WriteHex(uint address, String hexString)
		{
			hexString = hexString.Replace(" ", "");
			if (hexString.Length % 2 != 0)
			{
				hexString += "0";
			}

			byte[] writeBytes = new byte[hexString.Length / 2];
			for (int i = 0; i < writeBytes.Length; i++)
			{
				writeBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
			}
			SaveData.Instance().WriteValue(address, writeBytes);
		}
	}
}

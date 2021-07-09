namespace MonsterHunterStories2
{
	class Util
	{
		public const uint CHARACTER_ADDRESS = 0x2D2A98;
		public const uint CHARACTER_COUNT = 31;
		public const uint CHARACTER_SIZE = 596;

		public const uint MONSTER_ADDRESS = 0x2D72C8;
		public const uint MONSTER_COUNT = 50;
		public const uint MONSTER_SIZE = 412;

		public const uint WEAPON_ADDRESS = 0x3ECC;
		public const uint WEAPON_COUNT = 1099;
		public const uint WEAPON_SIZE = 36;

		public static void WriteNumber(uint address, uint size, uint value, uint min, uint max)
		{
			if (value < min) value = min;
			if (value > max) value = max;
			SaveData.Instance().WriteNumber(address, size, value);
		}

		public static uint ItemIDAddress(uint id)
		{
			return 0x4C + id * 8;
		}
	}
}

using System.Globalization;
using System.Windows.Data;

namespace MonsterHunterStories2
{
	class EggAddress2HexStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint address = (uint)value;
			return Util.ReadHex(address, Util.EGG_SIZE);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

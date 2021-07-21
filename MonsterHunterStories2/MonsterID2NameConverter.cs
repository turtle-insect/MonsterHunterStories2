using System;
using System.Globalization;
using System.Windows.Data;

namespace MonsterHunterStories2
{
	class MonsterID2NameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint id = (uint)value;
			if (id == 0) return Properties.Resources.MainNoneType;
			return Info.Instance().Search(Info.Instance().Monster, id)?.Value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

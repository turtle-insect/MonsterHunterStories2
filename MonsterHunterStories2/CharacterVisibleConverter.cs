using System;
using System.Globalization;
using System.Windows.Data;

namespace MonsterHunterStories2
{
	class CharacterVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int index = (int)value;
			return index == 0 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

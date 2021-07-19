using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MonsterHunterStories2
{
	class WeaponID2NameConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			uint id = (uint)values[0];
			uint type = (uint)values[1];
			if (Info.Instance().Weapon.Count <= type) return "";

			return Info.Instance().Search(Info.Instance().Weapon[type], id)?.Value;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

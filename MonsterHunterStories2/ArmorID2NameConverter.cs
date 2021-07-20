using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MonsterHunterStories2
{
	class ArmorID2NameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			uint id = (uint)value;
			String name = Info.Instance().Search(Info.Instance().Armor, id)?.Value;
			if (id == 0) name = "None";
			if (String.IsNullOrEmpty(name)) name = "ID: " + id.ToString();
			return name;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

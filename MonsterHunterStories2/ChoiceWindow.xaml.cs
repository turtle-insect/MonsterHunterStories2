using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MonsterHunterStories2
{
	/// <summary>
	/// ChoiceWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ChoiceWindow : Window
	{
		public enum eType
		{
			TYPE_ITEM,
			TYPE_MONSTER,
			TYPE_RAIDACTION,
		}

		public uint ID { get; set; }
		public eType Type { get; set; } = eType.TYPE_ITEM;

		public ChoiceWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CreateItemList("");
			TextBoxFilter.Focus();
		}

		private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			CreateItemList(TextBoxFilter.Text);
		}

		private void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ButtonDecision.IsEnabled = ListBoxItem.SelectedIndex >= 0;
		}

		private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ButtonDecision_Click(sender, null);
		}

		private void ButtonDecision_Click(object sender, RoutedEventArgs e)
		{
			var item = (KeyValuesInfo)ListBoxItem.SelectedItem;
			ID = item.Key;
			Close();
		}

		private void CreateItemList(String filter)
		{
			ListBoxItem.Items.Clear();
			var infos = Info.Instance().Item;

			if (Type == eType.TYPE_MONSTER) infos = Info.Instance().Monster;
			else if (Type == eType.TYPE_RAIDACTION) infos = Info.Instance().RideAction;

			foreach (var info in infos)
			{
				String value = info.Value;
				if (String.IsNullOrEmpty(value)) continue;
				if (String.IsNullOrEmpty(filter) || value.IndexOf(filter) >= 0)
				{
					ListBoxItem.Items.Add(info);
				}
			}
		}
	}
}

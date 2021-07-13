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
		public uint ID { get; set; }

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

			foreach (var info in infos)
			{
				if (String.IsNullOrEmpty(filter) || info.Value.IndexOf(filter) >= 0)
				{
					ListBoxItem.Items.Add(info);
				}
			}
		}
	}
}

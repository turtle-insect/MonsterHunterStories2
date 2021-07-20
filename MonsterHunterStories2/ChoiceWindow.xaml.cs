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
			TYPE_GENE,
			TYPE_WEAPON,
			TYPE_ARMOR,
			TYPE_TALISMAN_SKILL,
		}

		public uint ID { get; set; }
		public eType Type { get; set; } = eType.TYPE_ITEM;
		public uint WeaponType { get; set; }

		public ChoiceWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CreateItemList("");
			TextBoxFilter.Focus();
			WeaponTypeArea.Visibility = Type == eType.TYPE_WEAPON ? Visibility.Visible : Visibility.Collapsed;
			ComboBoxWeaponType.SelectedIndex = (int)WeaponType;
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

		private void ComboBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			WeaponType = (uint)ComboBoxWeaponType.SelectedIndex;
			CreateItemList(TextBoxFilter.Text);
			TextBoxFilter.Focus();
		}

		private void ButtonDecision_Click(object sender, RoutedEventArgs e)
		{
			var item = (KeyValuesInfo)ListBoxItem.SelectedItem;
			ID = item.Key;
			DialogResult = true;
			Close();
		}

		private void CreateItemList(String filter)
		{
			ListBoxItem.Items.Clear();
			var infos = Info.Instance().Item;

			if (Type == eType.TYPE_MONSTER) infos = Info.Instance().Monster;
			else if (Type == eType.TYPE_RAIDACTION) infos = Info.Instance().RideAction;
			else if (Type == eType.TYPE_GENE) infos = Info.Instance().Gene;
			else if (Type == eType.TYPE_WEAPON) infos = Info.Instance().Weapon[WeaponType];
			else if (Type == eType.TYPE_TALISMAN_SKILL) infos = Info.Instance().TalismanSkill;

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

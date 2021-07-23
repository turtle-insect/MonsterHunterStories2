using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace MonsterHunterStories2
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;

			FileOpen(files[0]);
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			FileOpen(dlg.FileName);
		}

		private void MenuItemFileSave_Click(object sender, RoutedEventArgs e)
		{
			SaveData.Instance().Save();
		}

		private void MenuItemFileSaveAs_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().SaveAs(dlg.FileName);
		}

		private void MenuItemFileExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new AboutWindow();
			dlg.ShowDialog();
		}

		private void ButtonChoiceItem_Click(object sender, RoutedEventArgs e)
		{
			uint id = ChoiceDialog(ChoiceWindow.eType.TYPE_ITEM, 0);
			ViewModel viewmodel = DataContext as ViewModel;
			if (viewmodel == null) return;

			// 重複チェック
			for(int i = 0; i < viewmodel.Items.Count; i++)
			{
				if(viewmodel.Items[i].ID == id)
				{
					ListBoxItem.SelectedIndex = i;
					return;
				}
			}

			// アイテム追加
			Item item = new Item(Util.ItemIDAddress(id));
			item.ID = id;
			item.Count = 1;
			viewmodel.Items.Add(item);

			// アイテム持ちのフラグ設定
			SaveData.Instance().WriteBit(Util.ITEMSETTING_ADDRESS + id / 8, id % 8, true);
		}

		private void ButtonChoiceMonster_Click(object sender, RoutedEventArgs e)
		{
			Monster monster = ListBoxMonster.SelectedItem as Monster;
			if (monster == null) return;

			monster.ID = ChoiceDialog(ChoiceWindow.eType.TYPE_MONSTER, monster.ID);
		}

		private void ButtonChoiceWeapon_Click(object sender, RoutedEventArgs e)
		{
			Weapon weapon = (sender as Button)?.DataContext as Weapon;
			if (weapon == null) return;

			var dlg = new ChoiceWindow();
			dlg.ID = weapon.ID;
			dlg.Type = ChoiceWindow.eType.TYPE_WEAPON;
			dlg.WeaponType = weapon.Type;
			if (dlg.WeaponType >= Info.Instance().Weapon.Count) dlg.WeaponType = 0;
			if (dlg.ShowDialog() == false) return;

			weapon.ID = dlg.ID;
			weapon.Type = dlg.WeaponType;
		}

		private void ButtonChoiceRaidAction1_Click(object sender, RoutedEventArgs e)
		{
			Monster monster = ListBoxMonster.SelectedItem as Monster;
			if (monster == null) return;

			monster.RideAction1 = ChoiceDialog(ChoiceWindow.eType.TYPE_RAIDACTION, monster.RideAction1);
		}

		private void ButtonChoiceRaidAction2_Click(object sender, RoutedEventArgs e)
		{
			Monster monster = ListBoxMonster.SelectedItem as Monster;
			if (monster == null) return;

			monster.RideAction2 = ChoiceDialog(ChoiceWindow.eType.TYPE_RAIDACTION, monster.RideAction2);
		}

		private void ButtonAppendEgg_Click(object sender, RoutedEventArgs e)
		{
			ViewModel viewmodel = DataContext as ViewModel;
			if (viewmodel == null) return;

			uint count = (uint)viewmodel.Eggs.Count;
			if (count >= Util.EGG_COUNT) return;

			Egg egg = new Egg(Util.EGG_ADDRESS + count * Util.EGG_SIZE);
			viewmodel.Eggs.Add(egg);
			SaveData.Instance().WriteNumber(Util.EGG_COUNT_ADDRESS, 1, count + 1);
		}

        private void ButtonCopyEggHex_Click(object sender, RoutedEventArgs e)
        {
			Clipboard.SetText(All_Hex.Text);
		}

		private void ButtonPasteEggHex_Click(object sender, RoutedEventArgs e)
		{
			int index = ListBoxEgg.SelectedIndex;
			if (index < 0) return;

			var egg = ListBoxEgg.SelectedItem as Egg;
			if (egg == null) return;

			string info = Clipboard.GetText();
			if (info.Replace(" ", "").Length != Util.EGG_SIZE * 2)
			{
				MessageBox.Show("Wrong Egg");
				return;
			}

			ViewModel viewmodel = DataContext as ViewModel;
			if (viewmodel == null) return;
			try
			{
				Util.WriteHex(egg.Address, info);
			}
			catch
			{
				MessageBox.Show("Wrong Egg");
				return;
			}
			viewmodel.Eggs.RemoveAt(index);
			viewmodel.Eggs.Insert(index, new Egg(egg.Address));
			ListBoxEgg.SelectedIndex = index;
		}

		private void ButtonChoiceGenes_Click(object sender, RoutedEventArgs e)
		{
			Gene gene = (sender as Button)?.DataContext as Gene;
			if (gene == null) return;

			gene.ID = ChoiceDialog(ChoiceWindow.eType.TYPE_GENE, gene.ID);
		}

		private void ButtonMonsterGeneStackMax_Click(object sender, RoutedEventArgs e)
		{
			Monster monster = ListBoxMonster.SelectedItem as Monster;			
			if (monster == null) return;

			foreach (var gene in monster.Genes)
			{
				gene.Stack = 2;
			}
        }

		private void ButtonMonsterGeneUnlock_Click(object sender, RoutedEventArgs e)
		{
			Monster monster = ListBoxMonster.SelectedItem as Monster;
			if (monster == null) return;

			foreach (var gene in monster.Genes)
			{
				gene.Lock = false;
			}
		}

		private void ButtonEggGeneStackMax_Click(object sender, RoutedEventArgs e)
		{
			Egg egg = ListBoxEgg.SelectedItem as Egg;
			if (egg == null) return;

			foreach (var gene in egg.Genes)
			{
				gene.Stack = 2;
			}
		}

		private void ButtonEggGeneUnlock_Click(object sender, RoutedEventArgs e)
		{
			Egg egg = ListBoxEgg.SelectedItem as Egg;
			if (egg == null) return;

			foreach (var gene in egg.Genes)
			{
				gene.Lock = false;
			}
		}

		private void ButtonChoiceArmor_Click(object sender, RoutedEventArgs e)
		{
			Armor armor = (sender as Button)?.DataContext as Armor;
			if (armor == null) return;

			armor.ID = ChoiceDialog(ChoiceWindow.eType.TYPE_ARMOR, armor.ID);
		}

		private void ButtonChoiceTalisman_Click(object sender, RoutedEventArgs e)
		{
			Talisman talisman = (sender as Button)?.DataContext as Talisman;
			if (talisman == null) return;

			talisman.ID = ChoiceDialog(ChoiceWindow.eType.TYPE_TALISMAN, talisman.ID);
		}

		private void ButtonChoiceTalismanSkill1_Click(object sender, RoutedEventArgs e)
		{
			Talisman talisman = (sender as Button)?.DataContext as Talisman;
			if (talisman == null) return;

			talisman.Skill1 = ChoiceDialog(ChoiceWindow.eType.TYPE_TALISMAN_SKILL, talisman.Skill1);
		}

		private void ButtonChoiceTalismanSkill2_Click(object sender, RoutedEventArgs e)
		{
			Talisman talisman = (sender as Button)?.DataContext as Talisman;
			if (talisman == null) return;

			talisman.Skill2 = ChoiceDialog(ChoiceWindow.eType.TYPE_TALISMAN_SKILL, talisman.Skill2);
		}

		private uint ChoiceDialog(ChoiceWindow.eType type, uint id)
		{
			var dlg = new ChoiceWindow();
			dlg.ID = id;
			dlg.Type = type;
			dlg.ShowDialog();
			return dlg.ID;
		}

		private void FileOpen(String filename)
		{
			SaveData.Instance().Adventure = Properties.Settings.Default.PCConfirm ? Util.PC_ADDRESS : 0;
			SaveData.Instance().Open(filename);
			DataContext = new ViewModel();
		}

		private void ButtonBaseGuide_Click(object sender, RoutedEventArgs e)
		{
			ViewModel viewmodel = DataContext as ViewModel;
			if (viewmodel == null) return;
			foreach(Guide x in viewmodel.Guides)
            {
				if (x == null) return;
				x.Get = true;
				x.Lv = 5;
			}
			MessageBox.Show("Success");
		}

		private void ButtonBaseAllKinship(object sender, RoutedEventArgs e)
		{
			ViewModel viewmodel = DataContext as ViewModel;
			if (viewmodel == null) return;
			foreach (Monster x in viewmodel.Monsters)
			{
				if (x == null) return;
				if(x.ID != 0)
                {
					x.KinshipGauge = 100;
                }
			}
			MessageBox.Show("Success");
		}
	}
}

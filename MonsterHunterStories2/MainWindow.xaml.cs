using System;
using System.Windows;
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
			foreach (string key in TransText.Languages.Keys)
            {
				Languages.Items.Add(key);
			};
		}

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;

			SaveData.Instance().Open(files[0]);
			DataContext = new ViewModel();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Open(dlg.FileName);
			DataContext = new ViewModel();
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
			//Close();

			for (uint id = 1000; id < 1100; id++)
			{
				Item item = new Item(Util.ItemIDAddress(id));
				item.ID = id;
				item.Count = id % 1000 + 100;
				SaveData.Instance().WriteBit(0x12B68 + id / 8, id % 8, true);
			}
		}

		private void ButtonItemAppend_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new ChoiceWindow();
			dlg.ID = 0;
			dlg.ShowDialog();
			if (dlg.ID == 0) return;

			uint id = dlg.ID;
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
			SaveData.Instance().WriteBit(0x12B68 + id / 8, id % 8, true);
		}

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
			int index = TransText.Languages[Languages.SelectedItem.ToString()];
			if(TransText.LanguageTexts.GetLength(0)<index+1) index = 0;
			int i = 0;
			try
			{
				MenuFile.Header = TransText.LanguageTexts[index, i++];
				ButtonOpen.ToolTip = TransText.LanguageTexts[index, i];
				MenuOpen.Header = TransText.LanguageTexts[index, i++];
				ButtonSave.ToolTip = TransText.LanguageTexts[index, i];
				MenuSave.Header = TransText.LanguageTexts[index, i++];
				MenuSaveAs.Header = TransText.LanguageTexts[index, i++];
				MenuExit.Header = TransText.LanguageTexts[index, i++];

				TabBasic.Header = TransText.LanguageTexts[index, i++];
				TabCharacter.Header = TransText.LanguageTexts[index, i++];
				TabMonster.Header = TransText.LanguageTexts[index, i++];
				TabWeapon.Header = TransText.LanguageTexts[index, i++];
				TabItem.Header = TransText.LanguageTexts[index, i++];

				LabelMoney.Content = TransText.LanguageTexts[index, i++];

				LabelName.Content = TransText.LanguageTexts[index, i++];
				LabelBody.Content = TransText.LanguageTexts[index, i++];
				LabelFace.Content = TransText.LanguageTexts[index, i++];
				LabelSkin.Content = TransText.LanguageTexts[index, i++];
				LabelHair.Content = TransText.LanguageTexts[index, i++];
				LabelEyes.Content = TransText.LanguageTexts[index, i++];
				LabelMouth.Content = TransText.LanguageTexts[index, i++];
				LabelMakeup.Content = TransText.LanguageTexts[index, i++];
				LableVoice.Content = TransText.LanguageTexts[index, i++];
				TextMale.Content = TransText.LanguageTexts[index, i++];
				TextWoman.Content = TransText.LanguageTexts[index, i++];
				TextBlock.Text = TransText.LanguageTexts[index, i++];

				LabelMonsterName.Content = TransText.LanguageTexts[index, i++];
				LabelMonsterType.Content = TransText.LanguageTexts[index, i++];

				ButtonItem.Content = TransText.LanguageTexts[index, i++];
			}
			catch (Exception)
            {
				MessageBox.Show("Missing string!");
			}


		}
    }
}

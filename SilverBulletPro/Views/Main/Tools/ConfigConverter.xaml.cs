using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Win32;
using SilverBulletPro.Extensions;
using SilverBulletPro.Models;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Views.Main.Tools
{
	// Token: 0x02000188 RID: 392
	public partial class ConfigConverter : Page
	{
		// Token: 0x060009B8 RID: 2488 RVA: 0x0002CAD8 File Offset: 0x0002ACD8
		public ConfigConverter()
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = new ConfigConverterViewModel());
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x0002CB08 File Offset: 0x0002AD08
		private void TextBox_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
					if (array != null && array.Length != 0 && File.Exists(array[0]) && (Path.GetExtension(array[0]).ToLower() == ".anom" || Path.GetExtension(array[0]).ToLower() == ".svb" || Path.GetExtension(array[0]).ToLower() == ".loli" || Path.GetExtension(array[0]).ToLower() == ".lolix"))
					{
						((TextBox)sender).Text = array[0];
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0002CBDC File Offset: 0x0002ADDC
		private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0002CBE8 File Offset: 0x0002ADE8
		private void SelectCfgButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.txtConfigPath.Text))
				{
					if (!File.Exists(this.txtConfigPath.Text))
					{
						Alert.Error("Config not found!", "Error", false);
						this.txtConfigPath.Text = string.Empty;
					}
					else if (!this.listBoxConfigs.Items.Contains(this.txtConfigPath.Text))
					{
						this.vm.ConfigsCollection.Add(this.txtConfigPath.Text);
					}
				}
				else
				{
					OpenFileDialog openFileDialog = new OpenFileDialog
					{
						Filter = "Config|*.svb;*.anom;*.loli;*.lolix"
					};
					bool? flag = openFileDialog.ShowDialog();
					bool flag2 = true;
					if ((flag.GetValueOrDefault() == flag2 & flag != null) && !this.listBoxConfigs.Items.Contains(this.txtConfigPath.Text))
					{
						this.vm.ConfigsCollection.Add(openFileDialog.FileName);
					}
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0002CCF8 File Offset: 0x0002AEF8
		private void ListBox_DragEnter(object sender, DragEventArgs e)
		{
			e.Effects = DragDropEffects.Copy;
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0002CD04 File Offset: 0x0002AF04
		private void ListBox_Drop(object sender, DragEventArgs e)
		{
			try
			{
				foreach (string text in (string[])e.Data.GetData(DataFormats.FileDrop))
				{
					if (text != null && text.Length > 0 && File.Exists(text) && (Path.GetExtension(text).ToLower() == ".anom" || Path.GetExtension(text).ToLower() == ".svb" || Path.GetExtension(text).ToLower() == ".loli" || Path.GetExtension(text).ToLower() == ".lolix"))
					{
						this.vm.ConfigsCollection.Add(text);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0002CDD8 File Offset: 0x0002AFD8
		private void RemoveSelMenuItem_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ListBox listBox = this.FindVisualChildren<ListBox>().First((ListBox l) => l.Name == (sender as MenuItem).Tag.ToString());
				ObservableCollection<ConvertedConfigs> observableCollection = listBox.ItemsSource as ObservableCollection<ConvertedConfigs>;
				if (observableCollection != null)
				{
					observableCollection.RemoveAt(listBox.SelectedIndex);
					if (listBox.Items.Count == 0)
					{
						this.progressBar.Value = 0.0;
					}
				}
				else
				{
					ObservableCollection<string> observableCollection2 = listBox.ItemsSource as ObservableCollection<string>;
					if (observableCollection2 != null)
					{
						observableCollection2.RemoveAt(listBox.SelectedIndex);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0002CE78 File Offset: 0x0002B078
		private void ClearMenuItem_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ListBox listBox = this.FindVisualChildren<ListBox>().First((ListBox l) => l.Name == (sender as MenuItem).Tag.ToString());
				ObservableCollection<ConvertedConfigs> observableCollection = listBox.ItemsSource as ObservableCollection<ConvertedConfigs>;
				if (observableCollection != null)
				{
					observableCollection.Clear();
					this.progressBar.Value = 0.0;
				}
				else
				{
					ObservableCollection<string> observableCollection2 = listBox.ItemsSource as ObservableCollection<string>;
					if (observableCollection2 != null)
					{
						observableCollection2.Clear();
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000499 RID: 1177
		public ConfigConverterViewModel vm;
	}
}

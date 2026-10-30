using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using HandyControl.Controls;
using HandyControl.Data;
using Microsoft.Win32;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Requests;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Main.Runner;

namespace SilverBulletPro.Views.Dialogs
{
	// Token: 0x020001AD RID: 429
	public partial class DialogSelectProxylist : Page, IStyleConnector
	{
		// Token: 0x06000C1F RID: 3103 RVA: 0x000433D4 File Offset: 0x000415D4
		public DialogSelectProxylist(object caller)
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = GlobalData.ProxyManager);
			this.Caller = caller;
			foreach (object obj in Enum.GetValues(typeof(ProxyType)))
			{
				ProxyType proxyType = (ProxyType)obj;
				if (proxyType != 4)
				{
					this.proxyTypeCombobox.Items.Add(proxyType);
				}
			}
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x00043474 File Offset: 0x00041674
		private void selectButton_Click(object sender, RoutedEventArgs e)
		{
			((RunnerOptions)this.Caller).LoadProxiesFromManager((Proxylist)this.proxylistsListView.SelectedItem);
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x000434A8 File Offset: 0x000416A8
		private void listViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader gridViewColumnHeader = sender as GridViewColumnHeader;
			string propertyName = gridViewColumnHeader.Tag.ToString();
			if (this.listViewSortCol != null)
			{
				AdornerLayer.GetAdornerLayer(this.listViewSortCol).Remove(this.listViewSortAdorner);
				this.proxylistsListView.Items.SortDescriptions.Clear();
			}
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			if (this.listViewSortCol == gridViewColumnHeader && this.listViewSortAdorner.Direction == listSortDirection)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			this.listViewSortCol = gridViewColumnHeader;
			this.listViewSortAdorner = new SortAdorner(this.listViewSortCol, listSortDirection);
			AdornerLayer.GetAdornerLayer(this.listViewSortCol).Add(this.listViewSortAdorner);
			this.proxylistsListView.Items.SortDescriptions.Add(new SortDescription(propertyName, listSortDirection));
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x00043561 File Offset: 0x00041761
		private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.selectButton_Click(this, null);
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x0004356B File Offset: 0x0004176B
		private void ListViewItem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.selectButton_Click(this, null);
			}
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x0004357E File Offset: 0x0004177E
		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.SearchString = this.searchBoxProxy.Text;
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x00043596 File Offset: 0x00041796
		private void FilterTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchButton_Click(this, null);
			}
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x000435A9 File Offset: 0x000417A9
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			this.SearchButton_Click(sender, e);
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x000435B3 File Offset: 0x000417B3
		private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.searchBoxProxy.Text))
			{
				this.SearchButton_Click(this, null);
			}
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x000435CF File Offset: 0x000417CF
		private void WordlistsListView_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effects = DragDropEffects.Copy;
			}
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x000435EC File Offset: 0x000417EC
		private void ProxylistsListView_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (this.addToProxylistsCheckBox.IsChecked.GetValueOrDefault())
				{
					using (IEnumerator<string> enumerator = (from w in (string[])e.Data.GetData(DataFormats.FileDrop)
					where w.EndsWith(".txt")
					select w).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							string path = enumerator.Current;
							Proxylist proxyListByPath = this.GetProxyListByPath(path);
							proxyListByPath.RemoveDups = this.removeDupProxylistCheckBox.IsChecked.GetValueOrDefault();
							this.vm.Add(proxyListByPath);
						}
						goto IL_176;
					}
				}
				string text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
				if (text.EndsWith(".txt") && File.Exists(text))
				{
					Proxylist proxyListByPath2 = this.GetProxyListByPath(text);
					proxyListByPath2.RemoveDups = this.removeDupProxylistCheckBox.IsChecked.GetValueOrDefault();
					if (this.Caller.GetType() == typeof(Runner))
					{
						((Runner)this.Caller).LoadProxiesFromManager(null, proxyListByPath2);
					}
					else if (this.Caller.GetType() == typeof(RunnerOptions))
					{
						((this.Caller as RunnerOptions).DataContext as RunnerOptionsViewModel).Proxylist = proxyListByPath2;
					}
					((MainDialog)base.Parent).Close();
				}
				IL_176:;
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x000437C0 File Offset: 0x000419C0
		private Proxylist GetProxyListByPath(string path)
		{
			Proxylist result = null;
			try
			{
				if (path.ToLower().Contains("http") || path.ToLower().Contains("https"))
				{
					result = ProxyManagerViewModel.FileToProxylist(path, 0);
				}
				else if (path.ToLower().Contains("socks4"))
				{
					result = ProxyManagerViewModel.FileToProxylist(path, 1);
				}
				else if (path.ToLower().Contains("socks4a"))
				{
					result = ProxyManagerViewModel.FileToProxylist(path, 2);
				}
				else if (path.ToLower().Contains("socks5"))
				{
					result = ProxyManagerViewModel.FileToProxylist(path, 3);
				}
				else
				{
					result = ProxyManagerViewModel.FileToProxylist(path, 0);
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.ProxyManager, "Failed to open file " + path + " - " + ex.Message, false, 0);
			}
			return result;
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x00043894 File Offset: 0x00041A94
		private void TextBox_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
					if (array != null && array.Length != 0 && File.Exists(array[0]) && Path.GetExtension(array[0]).ToLower() == ".txt")
					{
						((TextBox)sender).Text = array[0];
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x00043918 File Offset: 0x00041B18
		private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00043924 File Offset: 0x00041B24
		private void ImportProxylistButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Proxylist file | *.txt";
			openFileDialog.FilterIndex = 1;
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = true;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				this.pathProxyTextBox.Text = openFileDialog.FileName;
				if (this.addToProxylistsCheckBox.IsChecked.GetValueOrDefault())
				{
					try
					{
						Proxylist proxylist = ProxyManagerViewModel.FileToProxylist(openFileDialog.FileName, (ProxyType)this.proxyTypeCombobox.SelectedItem);
						proxylist.RemoveDups = this.addToProxylistsCheckBox.IsChecked.GetValueOrDefault();
						this.vm.Add(proxylist);
						return;
					}
					catch (Exception ex)
					{
						GlobalData.Logger.Log(ex.Message, 2, true, 0);
						return;
					}
				}
				try
				{
					Proxylist proxylist2 = ProxyManagerViewModel.FileToProxylist(openFileDialog.FileName, (ProxyType)this.proxyTypeCombobox.SelectedItem);
					proxylist2.RemoveDups = this.removeDupProxylistCheckBox.IsChecked.GetValueOrDefault();
					if (this.Caller.GetType() == typeof(Runner))
					{
						((Runner)this.Caller).LoadProxiesFromManager(null, proxylist2);
					}
					else if (this.Caller.GetType() == typeof(ValueTuple<RunnerOptions, Runner>))
					{
						(((ValueTuple<RunnerOptions, Runner>)this.Caller).Item1.DataContext as RunnerOptionsViewModel).Proxylist = proxylist2;
					}
					((MainDialog)base.Parent).Close();
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x00043AC8 File Offset: 0x00041CC8
		private void proxyTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				bool? isChecked = this.addToProxylistsCheckBox.IsChecked;
				bool flag = true;
				if (isChecked.GetValueOrDefault() == flag & isChecked != null)
				{
					((Proxylist)this.proxylistsListView.SelectedItem).Type = this.proxyTypeCombobox.SelectedItem.ToString();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x00043D94 File Offset: 0x00041F94
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 3)
			{
				EventSetter eventSetter = new EventSetter();
				eventSetter.Event = Control.MouseDoubleClickEvent;
				eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
				((Style)target).Setters.Add(eventSetter);
				eventSetter = new EventSetter();
				eventSetter.Event = UIElement.KeyDownEvent;
				eventSetter.Handler = new KeyEventHandler(this.ListViewItem_KeyDown);
				((Style)target).Setters.Add(eventSetter);
			}
		}

		// Token: 0x04000617 RID: 1559
		private GridViewColumnHeader listViewSortCol;

		// Token: 0x04000618 RID: 1560
		private SortAdorner listViewSortAdorner;

		// Token: 0x04000619 RID: 1561
		private ProxyManagerViewModel vm;

		// Token: 0x0400061A RID: 1562
		private object Caller;
	}
}

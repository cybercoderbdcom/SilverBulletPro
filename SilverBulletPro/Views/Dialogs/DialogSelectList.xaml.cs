using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using HandyControl.Controls;
using HandyControl.Data;
using Microsoft.Win32;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Requests;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Main.Runner;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.Dialogs
{
	// Token: 0x020001AC RID: 428
	public partial class DialogSelectList : Page, IStyleConnector
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000C08 RID: 3080 RVA: 0x000423E6 File Offset: 0x000405E6
		// (set) Token: 0x06000C09 RID: 3081 RVA: 0x000423EE File Offset: 0x000405EE
		private object Caller { get; set; }

		// Token: 0x06000C0A RID: 3082 RVA: 0x000423F8 File Offset: 0x000405F8
		public DialogSelectList(object caller)
		{
			this.Caller = caller;
			this.wordlistVm = GlobalData.WordlistManager;
			this.proxyVm = GlobalData.ProxyManager;
			this.InitializeComponent();
			this.tabItemWordlist.DataContext = this.wordlistVm;
			this.tabItemProxylist.DataContext = this.proxyVm;
			foreach (object obj in Enum.GetValues(typeof(ProxyType)))
			{
				ProxyType proxyType = (ProxyType)obj;
				if (proxyType != 4)
				{
					this.proxyTypeCombobox.Items.Add(proxyType);
				}
			}
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x000424BC File Offset: 0x000406BC
		private void selectButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.tabControl.SelectedIndex == 0)
			{
				if (this.Caller.GetType() == typeof(Runner) && this.wordlistsListView.SelectedItems.Count > 1)
				{
					Runner runner = (Runner)this.Caller;
					RunnerViewModel runnerViewModel = runner.DataContext as RunnerViewModel;
					List<string> list = new List<string>();
					string text = string.Empty;
					foreach (object obj in this.wordlistsListView.SelectedItems)
					{
						Wordlist wordlist = (Wordlist)obj;
						text = text + wordlist.Name + " & ";
						string[] array = File.ReadAllLines(wordlist.Path);
						if (wordlist.RemoveDups)
						{
							array = array.Distinct<string>().ToArray<string>();
						}
						list.AddRange(array);
					}
					if (list.Count > 0)
					{
						runnerViewModel.DataPool = new ListDataPool(list, "Default");
					}
					Wordlist wordlist2 = (Wordlist)this.wordlistsListView.SelectedItem;
					runner.SetWordlist(new Wordlist(wordlist2.Name, wordlist2.Path, wordlist2.Type, wordlist2.Purpose, true, true, false)
					{
						Total = list.LongCount<string>(),
						Name = text.Trim().TrimEnd('&') + " [Multiple]",
						RemoveDups = false
					});
				}
				else if (this.Caller.GetType() == typeof(Runner))
				{
					((Runner)this.Caller).SetWordlist((Wordlist)this.wordlistsListView.SelectedItem);
				}
				else if (this.Caller.GetType() == typeof(UserControlWordlist))
				{
					((UserControlWordlist)this.Caller).Wordlist = (Wordlist)this.wordlistsListView.SelectedItem;
				}
			}
			else
			{
				((Runner)this.Caller).LoadProxiesFromManager(null, (Proxylist)this.proxylistsListView.SelectedItem);
			}
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00042704 File Offset: 0x00040904
		private void listViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader gridViewColumnHeader = sender as GridViewColumnHeader;
			string propertyName = gridViewColumnHeader.Tag.ToString();
			if (this.listViewSortCol != null)
			{
				AdornerLayer.GetAdornerLayer(this.listViewSortCol).Remove(this.listViewSortAdorner);
				this.wordlistsListView.Items.SortDescriptions.Clear();
			}
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			if (this.listViewSortCol == gridViewColumnHeader && this.listViewSortAdorner.Direction == listSortDirection)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			this.listViewSortCol = gridViewColumnHeader;
			this.listViewSortAdorner = new SortAdorner(this.listViewSortCol, listSortDirection);
			AdornerLayer.GetAdornerLayer(this.listViewSortCol).Add(this.listViewSortAdorner);
			this.wordlistsListView.Items.SortDescriptions.Add(new SortDescription(propertyName, listSortDirection));
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x000427BD File Offset: 0x000409BD
		private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.selectButton_Click(this, null);
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x000427C7 File Offset: 0x000409C7
		private void ListViewItem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.selectButton_Click(this, null);
			}
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x000427DC File Offset: 0x000409DC
		private void ImportWordlistButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Wordlist file | *.txt";
			openFileDialog.FilterIndex = 1;
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = true;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				this.pathTextBox.Text = openFileDialog.FileName;
				if (this.addToWordlistsCheckBox.IsChecked.GetValueOrDefault())
				{
					try
					{
						Wordlist wordlist = WordlistManagerViewModel.FileToWordlist(openFileDialog.FileName, true);
						wordlist.RemoveDups = this.removeDupCheckBox.IsChecked.GetValueOrDefault();
						this.wordlistVm.Add(wordlist);
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
					Wordlist wordlist2 = WordlistManagerViewModel.FileToWordlist(openFileDialog.FileName, true);
					wordlist2.RemoveDups = this.removeDupCheckBox.IsChecked.GetValueOrDefault();
					((Runner)this.Caller).SetWordlist(wordlist2);
					((MainDialog)base.Parent).Close();
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x00042900 File Offset: 0x00040B00
		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.tabControl.SelectedIndex == 0)
			{
				this.wordlistVm.SearchString = this.searchBox.Text;
				return;
			}
			this.proxyVm.SearchString = this.searchBox.Text;
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x0004293C File Offset: 0x00040B3C
		private void FilterTextbox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchButton_Click(this, null);
			}
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x0004294F File Offset: 0x00040B4F
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			this.SearchButton_Click(sender, e);
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x00042959 File Offset: 0x00040B59
		private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.searchBox.Text))
			{
				this.SearchButton_Click(this, null);
			}
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x00042975 File Offset: 0x00040B75
		private void WordlistsListView_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effects = DragDropEffects.Copy;
			}
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x00042990 File Offset: 0x00040B90
		private void WordlistsListView_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (this.addToWordlistsCheckBox.IsChecked.GetValueOrDefault())
				{
					Wordlist wordlist;
					Task.Run(delegate()
					{
						foreach (string path in from w in (string[])e.Data.GetData(DataFormats.FileDrop)
						where w.EndsWith(".txt")
						select w)
						{
							try
							{
								Wordlist wordlist = WordlistManagerViewModel.FileToWordlist(path, true);
								this.Dispatcher.Invoke<bool>(() => wordlist.RemoveDups = this.removeDupCheckBox.IsChecked.GetValueOrDefault());
								this.Dispatcher.Invoke(delegate()
								{
									this.wordlistVm.Add(wordlist);
								});
							}
							catch
							{
							}
						}
					}).ContinueWith(delegate(Task t)
					{
						try
						{
							if (t != null)
							{
								t.Dispose();
							}
						}
						catch
						{
						}
					});
				}
				else
				{
					string text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
					if (text.EndsWith(".txt") && File.Exists(text))
					{
						Wordlist wordlist = WordlistManagerViewModel.FileToWordlist(text, true);
						wordlist.RemoveDups = this.removeDupCheckBox.IsChecked.GetValueOrDefault();
						((Runner)this.Caller).SetWordlist(wordlist);
						((MainDialog)base.Parent).Close();
					}
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x00042AA0 File Offset: 0x00040CA0
		private void ProxylistsListView_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (this.addToProxylistsCheckBox.IsChecked.GetValueOrDefault())
				{
					Task.Run(delegate()
					{
						foreach (string path in from w in (string[])e.Data.GetData(DataFormats.FileDrop)
						where w.EndsWith(".txt")
						select w)
						{
							Proxylist proxylist = this.GetProxyListByPath(path);
							this.Dispatcher.Invoke<bool>(() => proxylist.RemoveDups = this.removeDupProxylistCheckBox.IsChecked.GetValueOrDefault());
							this.Dispatcher.Invoke(delegate()
							{
								this.proxyVm.Add(proxylist);
							});
						}
					}).ContinueWith(delegate(Task t)
					{
						try
						{
							if (t != null)
							{
								t.Dispose();
							}
						}
						catch
						{
						}
					});
				}
				else
				{
					string text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
					if (text.EndsWith(".txt") && File.Exists(text))
					{
						Proxylist proxyListByPath = this.GetProxyListByPath(text);
						proxyListByPath.RemoveDups = this.removeDupProxylistCheckBox.IsChecked.GetValueOrDefault();
						((Runner)this.Caller).LoadProxiesFromManager(null, proxyListByPath);
						((MainDialog)base.Parent).Close();
					}
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x00042BB0 File Offset: 0x00040DB0
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

		// Token: 0x06000C18 RID: 3096 RVA: 0x00042C84 File Offset: 0x00040E84
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

		// Token: 0x06000C19 RID: 3097 RVA: 0x00042D08 File Offset: 0x00040F08
		private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x00042D14 File Offset: 0x00040F14
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
						this.proxyVm.Add(proxylist);
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
					Proxylist proxylist2 = (Proxylist)this.proxylistsListView.SelectedItem;
					proxylist2.RemoveDups = this.addToProxylistsCheckBox.IsChecked.GetValueOrDefault();
					((Runner)this.Caller).LoadProxiesFromManager(null, proxylist2);
					((MainDialog)base.Parent).Close();
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00042E4C File Offset: 0x0004104C
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

		// Token: 0x06000C1E RID: 3102 RVA: 0x000432EC File Offset: 0x000414EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			EventSetter eventSetter;
			if (connectionId == 5)
			{
				eventSetter = new EventSetter();
				eventSetter.Event = Control.MouseDoubleClickEvent;
				eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
				((Style)target).Setters.Add(eventSetter);
				eventSetter = new EventSetter();
				eventSetter.Event = UIElement.KeyDownEvent;
				eventSetter.Handler = new KeyEventHandler(this.ListViewItem_KeyDown);
				((Style)target).Setters.Add(eventSetter);
				return;
			}
			if (connectionId != 18)
			{
				return;
			}
			eventSetter = new EventSetter();
			eventSetter.Event = Control.MouseDoubleClickEvent;
			eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
			((Style)target).Setters.Add(eventSetter);
			eventSetter = new EventSetter();
			eventSetter.Event = UIElement.KeyDownEvent;
			eventSetter.Handler = new KeyEventHandler(this.ListViewItem_KeyDown);
			((Style)target).Setters.Add(eventSetter);
		}

		// Token: 0x04000602 RID: 1538
		private GridViewColumnHeader listViewSortCol;

		// Token: 0x04000603 RID: 1539
		private SortAdorner listViewSortAdorner;

		// Token: 0x04000605 RID: 1541
		private WordlistManagerViewModel wordlistVm;

		// Token: 0x04000606 RID: 1542
		private ProxyManagerViewModel proxyVm;
	}
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using HandyControl.Controls;
using HandyControl.Data;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Main.Runner;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro
{
	// Token: 0x02000028 RID: 40
	public class DialogSelectWordlist : Page, IComponentConnector, IStyleConnector
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000169 RID: 361 RVA: 0x0000BB5D File Offset: 0x00009D5D
		// (set) Token: 0x0600016A RID: 362 RVA: 0x0000BB65 File Offset: 0x00009D65
		private object Caller { get; set; }

		// Token: 0x0600016B RID: 363 RVA: 0x0000BB6E File Offset: 0x00009D6E
		public DialogSelectWordlist(object caller)
		{
			this.Caller = caller;
			this.vm = GlobalData.WordlistManager;
			base.DataContext = this.vm;
			this.InitializeComponent();
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000BB9C File Offset: 0x00009D9C
		private void selectButton_Click(object sender, RoutedEventArgs e)
		{
			Runner runner = this.Caller as Runner;
			if (runner != null)
			{
				this.SetWordlists(runner);
			}
			else
			{
				ITuple tuple = this.Caller as ITuple;
				if (tuple != null && tuple.Length == 2)
				{
					RunnerOptions runnerOptions = tuple[0] as RunnerOptions;
					if (runnerOptions != null)
					{
						Runner runner2 = tuple[1] as Runner;
						if (runner2 != null)
						{
							this.SetWordlists(runnerOptions, runner2);
							goto IL_73;
						}
					}
				}
				UserControlWordlist userControlWordlist = this.Caller as UserControlWordlist;
				if (userControlWordlist != null)
				{
					this.SetWordlists(userControlWordlist);
				}
			}
			IL_73:
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000BC2C File Offset: 0x00009E2C
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

		// Token: 0x0600016E RID: 366 RVA: 0x0000BCE5 File Offset: 0x00009EE5
		private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.selectButton_Click(this, null);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000BCEF File Offset: 0x00009EEF
		private void ListViewItem_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.selectButton_Click(this, null);
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000BD04 File Offset: 0x00009F04
		private void ImportWordlistButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Wordlist file | *.txt";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.pathTextBox.Text = openFileDialog.FileName;
				if (this.addToWordlistsCheckBox.IsChecked.GetValueOrDefault())
				{
					try
					{
						Wordlist wordlist = WordlistManagerViewModel.FileToWordlist(openFileDialog.FileName, true);
						wordlist.RemoveDups = this.removeDupCheckBox.IsChecked.GetValueOrDefault();
						this.vm.Add(wordlist);
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
					if (this.Caller.GetType() == typeof(Runner))
					{
						((Runner)this.Caller).SetWordlist(wordlist2);
					}
					else if (this.Caller.GetType() == typeof(ValueTuple<RunnerOptions, Runner>))
					{
						(((ValueTuple<RunnerOptions, Runner>)this.Caller).Item1.DataContext as RunnerOptionsViewModel).DataPoolOptions = new DataPoolOptions[]
						{
							new WordlistDataPoolOptions
							{
								WordlistName = wordlist2.Name,
								WordlistPath = wordlist2.Path,
								WordlistType = wordlist2.Type,
								WordlistPurpose = wordlist2.Purpose
							}
						};
					}
					else if (this.Caller.GetType() == typeof(UserControlWordlist))
					{
						((UserControlWordlist)this.Caller).Wordlist = wordlist2;
					}
					((MainDialog)base.Parent).Close();
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000BF00 File Offset: 0x0000A100
		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.SearchString = this.searchBox.Text;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000BF18 File Offset: 0x0000A118
		private void FilterTextbox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchButton_Click(this, null);
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000BF2B File Offset: 0x0000A12B
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			this.SearchButton_Click(sender, e);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000BF35 File Offset: 0x0000A135
		private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.searchBox.Text))
			{
				this.SearchButton_Click(this, null);
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000BF51 File Offset: 0x0000A151
		private void WordlistsListView_DragEnter(object sender, System.Windows.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
			{
				e.Effects = System.Windows.DragDropEffects.Copy;
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000BF6C File Offset: 0x0000A16C
		private void WordlistsListView_Drop(object sender, System.Windows.DragEventArgs e)
		{
			try
			{
				if (this.addToWordlistsCheckBox.IsChecked.GetValueOrDefault())
				{
					using (IEnumerator<string> enumerator = (from w in (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop)
					where w.EndsWith(".txt")
					select w).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							string path = enumerator.Current;
							try
							{
								Wordlist wordlist = WordlistManagerViewModel.FileToWordlist(path, true);
								wordlist.RemoveDups = this.removeDupCheckBox.IsChecked.GetValueOrDefault();
								this.vm.Add(wordlist);
							}
							catch
							{
							}
						}
						goto IL_1F2;
					}
				}
				string text = ((string[])e.Data.GetData(System.Windows.DataFormats.FileDrop))[0];
				if (text.EndsWith(".txt") && File.Exists(text))
				{
					Wordlist wordlist2 = WordlistManagerViewModel.FileToWordlist(text, true);
					wordlist2.RemoveDups = this.removeDupCheckBox.IsChecked.GetValueOrDefault();
					if (this.Caller.GetType() == typeof(Runner))
					{
						((Runner)this.Caller).SetWordlist(wordlist2);
					}
					else if (this.Caller.GetType() == typeof(ValueTuple<RunnerOptions, Runner>))
					{
						(((ValueTuple<RunnerOptions, Runner>)this.Caller).Item1.DataContext as RunnerOptionsViewModel).DataPoolOptions = new DataPoolOptions[]
						{
							new WordlistDataPoolOptions
							{
								WordlistName = wordlist2.Name,
								WordlistPath = wordlist2.Path,
								WordlistType = wordlist2.Type,
								WordlistPurpose = wordlist2.Purpose
							}
						};
					}
					else if (this.Caller.GetType() == typeof(UserControlWordlist))
					{
						((UserControlWordlist)this.Caller).Wordlist = wordlist2;
					}
					((MainDialog)base.Parent).Close();
				}
				IL_1F2:;
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000C1D4 File Offset: 0x0000A3D4
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000C1D8 File Offset: 0x0000A3D8
		private void TextBox_Drop(object sender, System.Windows.DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
				{
					string[] array = e.Data.GetData(System.Windows.DataFormats.FileDrop) as string[];
					if (array != null && array.Length != 0 && File.Exists(array[0]) && Path.GetExtension(array[0]).ToLower() == ".txt")
					{
						((System.Windows.Controls.TextBox)sender).Text = array[0];
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000C25C File Offset: 0x0000A45C
		private void TextBox_PreviewDragOver(object sender, System.Windows.DragEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000C268 File Offset: 0x0000A468
		private void SetWordlists(Runner runner)
		{
			if (this.wordlistsListView.SelectedItems.Count > 1)
			{
				(runner.DataContext as RunnerViewModel).Options.SetWordlists(this.wordlistsListView.SelectedItems.OfType<Wordlist>().ToArray<Wordlist>());
				return;
			}
			runner.SetWordlist((Wordlist)this.wordlistsListView.SelectedItem);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000C2CC File Offset: 0x0000A4CC
		private void SetWordlists(RunnerOptions options, Runner runner)
		{
			if (this.wordlistsListView.SelectedItems.Count <= 1)
			{
				(options.DataContext as RunnerOptionsViewModel).SetWordlist((Wordlist)this.wordlistsListView.SelectedItem);
				return;
			}
			RunnerOptionsViewModel runnerOptionsViewModel = (RunnerOptionsViewModel)options.DataContext;
			if (runnerOptionsViewModel == null)
			{
				return;
			}
			runnerOptionsViewModel.SetWordlists(this.wordlistsListView.SelectedItems.OfType<Wordlist>().ToArray<Wordlist>());
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000C337 File Offset: 0x0000A537
		private void SetWordlists(UserControlWordlist controlWordlist)
		{
			controlWordlist.Wordlist = (Wordlist)this.wordlistsListView.SelectedItem;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000C350 File Offset: 0x0000A550
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogselectwordlist.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000C380 File Offset: 0x0000A580
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((DialogSelectWordlist)target).Loaded += this.Page_Loaded;
				return;
			case 2:
				this.searchBox = (SearchBar)target;
				this.searchBox.KeyDown += this.FilterTextbox_KeyDown;
				this.searchBox.SearchStarted += this.SearchBar_SearchStarted;
				this.searchBox.TextChanged += this.SearchBox_TextChanged;
				return;
			case 3:
				this.wordlistsListView = (System.Windows.Controls.ListView)target;
				this.wordlistsListView.DragEnter += this.WordlistsListView_DragEnter;
				this.wordlistsListView.Drop += this.WordlistsListView_Drop;
				return;
			case 5:
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
				return;
			case 6:
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
				return;
			case 7:
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
				return;
			case 8:
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
				return;
			case 9:
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
				return;
			case 10:
				this.pathTextBox = (System.Windows.Controls.TextBox)target;
				this.pathTextBox.Drop += this.TextBox_Drop;
				this.pathTextBox.PreviewDragOver += this.TextBox_PreviewDragOver;
				return;
			case 11:
				((System.Windows.Controls.Button)target).Click += this.ImportWordlistButton_Click;
				return;
			case 12:
				this.addToWordlistsCheckBox = (System.Windows.Controls.CheckBox)target;
				return;
			case 13:
				this.removeDupCheckBox = (System.Windows.Controls.CheckBox)target;
				return;
			case 14:
				this.selectButton = (System.Windows.Controls.Button)target;
				this.selectButton.Click += this.selectButton_Click;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000C588 File Offset: 0x0000A788
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 4)
			{
				EventSetter eventSetter = new EventSetter();
				eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
				eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
				((Style)target).Setters.Add(eventSetter);
				eventSetter = new EventSetter();
				eventSetter.Event = UIElement.KeyDownEvent;
				eventSetter.Handler = new System.Windows.Input.KeyEventHandler(this.ListViewItem_KeyDown);
				((Style)target).Setters.Add(eventSetter);
			}
		}

		// Token: 0x040000BC RID: 188
		private GridViewColumnHeader listViewSortCol;

		// Token: 0x040000BD RID: 189
		private SortAdorner listViewSortAdorner;

		// Token: 0x040000BF RID: 191
		private WordlistManagerViewModel vm;

		// Token: 0x040000C0 RID: 192
		internal SearchBar searchBox;

		// Token: 0x040000C1 RID: 193
		internal System.Windows.Controls.ListView wordlistsListView;

		// Token: 0x040000C2 RID: 194
		internal System.Windows.Controls.TextBox pathTextBox;

		// Token: 0x040000C3 RID: 195
		internal System.Windows.Controls.CheckBox addToWordlistsCheckBox;

		// Token: 0x040000C4 RID: 196
		internal System.Windows.Controls.CheckBox removeDupCheckBox;

		// Token: 0x040000C5 RID: 197
		internal System.Windows.Controls.Button selectButton;

		// Token: 0x040000C6 RID: 198
		private bool _contentLoaded;
	}
}

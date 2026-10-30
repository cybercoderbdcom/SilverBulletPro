using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using HandyControl.Controls;
using HandyControl.Data;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Extensions;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x02000186 RID: 390
	public partial class WordlistManager : Page
	{
		// Token: 0x0600099A RID: 2458 RVA: 0x0002BEF2 File Offset: 0x0002A0F2
		public WordlistManager()
		{
			this.vm = GlobalData.WordlistManager;
			base.DataContext = this.vm;
			this.InitializeComponent();
			this.progressDialog.Dismiss += delegate(object <p0>, RoutedEventArgs <p1>)
			{
				try
				{
					this.DisableProgress();
					CancellationTokenSource cancellationTokenSource = this.loadWordlistCts;
					if (cancellationTokenSource != null)
					{
						cancellationTokenSource.Cancel();
					}
					CancellationTokenSource cancellationTokenSource2 = this.loadWordlistCts;
					if (cancellationTokenSource2 != null)
					{
						cancellationTokenSource2.Dispose();
					}
				}
				catch
				{
				}
			};
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0002BF30 File Offset: 0x0002A130
		public void AddWordlist(Wordlist wordlist)
		{
			try
			{
				this.vm.Add(wordlist);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.WordlistManager, ex.Message, false, 0);
			}
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0002BF74 File Offset: 0x0002A174
		private void addButton_Click(object sender, RoutedEventArgs e)
		{
			new MainDialog(new MainDialog.InputDialog
			{
				Dialog = new DialogAddWordlist(this),
				Title = "Add Wordlist"
			}).ShowDialog();
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0002BFA0 File Offset: 0x0002A1A0
		private void editButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.wordlistListView.SelectedIndex != -1 && this.wordlistListView.SelectedItem != null)
				{
					DialogEditWordlist dialogEditWordlist = new DialogEditWordlist((Wordlist)this.wordlistListView.SelectedItem);
					new MainDialog(new MainDialog.InputDialog
					{
						Dialog = dialogEditWordlist,
						Title = "Edit Wordlist"
					}).ShowDialog();
					if (dialogEditWordlist.DialogResult == DialogResult.OK)
					{
						this.vm.Update(dialogEditWordlist.WordList);
						this.vm.RefreshList();
					}
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0002C050 File Offset: 0x0002A250
		private void deleteButton_Click(object sender, RoutedEventArgs e)
		{
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.WordlistManager;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Deleting ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.wordlistListView.SelectedItems.Count);
			defaultInterpolatedStringHandler.AppendLiteral(" references from the DB");
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			foreach (Wordlist wordlist in this.wordlistListView.SelectedItems.Cast<Wordlist>().ToList<Wordlist>())
			{
				this.vm.Remove(wordlist);
			}
			GlobalData.Logger.LogInfo(Components.WordlistManager, "Successfully deleted the wordlist references from the DB", false, 0);
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0002C118 File Offset: 0x0002A318
		private void deleteAllButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogWarning(Components.WordlistManager, "Purge selected, prompting warning", false, 0);
			if (Alert.Choice("This will purge the WHOLE Wordlists DB, are you sure you want to continue?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
			{
				GlobalData.Logger.LogInfo(Components.WordlistManager, "Purge initiated", false, 0);
				this.vm.RemoveAll();
				GlobalData.Logger.LogInfo(Components.WordlistManager, "Purge finished", false, 0);
				return;
			}
			GlobalData.Logger.LogInfo(Components.WordlistManager, "Purge dismissed", false, 0);
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0002C18E File Offset: 0x0002A38E
		private void deleteNotFoundWordlistsButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogWarning(Components.WordlistManager, "Deleting wordlists with missing files.", false, 0);
			this.vm.DeleteNotFound();
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0002C1AD File Offset: 0x0002A3AD
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			this.vm.SearchString = this.filterTextbox.Text;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0002C1C5 File Offset: 0x0002A3C5
		private void filterTextbox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchBar_SearchStarted(this, null);
			}
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0002C1D8 File Offset: 0x0002A3D8
		private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.filterTextbox.Text))
			{
				this.SearchBar_SearchStarted(this, null);
			}
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0002C1F4 File Offset: 0x0002A3F4
		private void listViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader gridViewColumnHeader = sender as GridViewColumnHeader;
			string propertyName = gridViewColumnHeader.Tag.ToString();
			if (this.listViewSortCol != null)
			{
				AdornerLayer.GetAdornerLayer(this.listViewSortCol).Remove(this.listViewSortAdorner);
				this.wordlistListView.Items.SortDescriptions.Clear();
			}
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			if (this.listViewSortCol == gridViewColumnHeader && this.listViewSortAdorner.Direction == listSortDirection)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			this.listViewSortCol = gridViewColumnHeader;
			this.listViewSortAdorner = new SortAdorner(this.listViewSortCol, listSortDirection);
			AdornerLayer.GetAdornerLayer(this.listViewSortCol).Add(this.listViewSortAdorner);
			this.wordlistListView.Items.SortDescriptions.Add(new SortDescription(propertyName, listSortDirection));
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0002C2B0 File Offset: 0x0002A4B0
		private void WordlistListViewDrop(object sender, System.Windows.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
			{
				foreach (string text in (from x in (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop)
				where x.EndsWith(".txt")
				select x).ToArray<string>())
				{
					try
					{
						string text2 = text;
						string currentDirectory = Directory.GetCurrentDirectory();
						if (text2.StartsWith(currentDirectory))
						{
							text2 = text2.Substring(currentDirectory.Length + 1);
						}
						Wordlist wordlist = new Wordlist(Path.GetFileNameWithoutExtension(text), text2, GlobalData.Settings.Environment.WordlistTypes.First<WordlistType>().Name, "", true, false, false);
						wordlist.Type = GlobalData.Settings.Environment.RecognizeWordlistType(wordlist.FirstLine);
						this.AddWordlist(wordlist);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0002C3B8 File Offset: 0x0002A5B8
		private void EnableProgress()
		{
			base.Dispatcher.InvokeIfRequired(delegate
			{
				this.progressDialog.Enable(this.mainGrid, default(TimeSpan));
			}, DispatcherPriority.ContextIdle);
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0002C3D2 File Offset: 0x0002A5D2
		private void DisableProgress()
		{
			base.Dispatcher.InvokeIfRequired(delegate
			{
				this.progressDialog.Disable(this.mainGrid, default(TimeSpan));
			}, DispatcherPriority.ContextIdle);
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0002C3EC File Offset: 0x0002A5EC
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				if (GlobalData.SBSettings.General.DisableAnimationMode)
				{
					Storyboard transitionStoryboard = this.trans.TransitionStoryboard;
					if (((transitionStoryboard != null) ? transitionStoryboard.Name : null) != "DisableAnimationMode")
					{
						this.trans.TransitionStoryboard = new Storyboard
						{
							Name = "DisableAnimationMode"
						};
						goto IL_6E;
					}
				}
				if (!GlobalData.SBSettings.General.DisableAnimationMode)
				{
					this.trans.TransitionStoryboard = null;
				}
				IL_6E:;
			}
			catch
			{
			}
		}

		// Token: 0x04000483 RID: 1155
		private WordlistManagerViewModel vm;

		// Token: 0x04000484 RID: 1156
		private GridViewColumnHeader listViewSortCol;

		// Token: 0x04000485 RID: 1157
		private SortAdorner listViewSortAdorner;

		// Token: 0x04000486 RID: 1158
		private CancellationTokenSource loadWordlistCts;
	}
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using HandyControl.Controls;
using HandyControl.Data;
using Microsoft.Win32;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Main.Runner;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x0200017D RID: 381
	public partial class HitsDB : Page, IStyleConnector
	{
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060008F4 RID: 2292 RVA: 0x00026909 File Offset: 0x00024B09
		private IEnumerable<Hit> Selected
		{
			get
			{
				return this.hitsListView.SelectedItems.Cast<Hit>();
			}
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0002691C File Offset: 0x00024B1C
		public HitsDB()
		{
			this.vm = GlobalData.HitsDB;
			base.DataContext = this.vm;
			this.InitializeComponent();
			this.vm.RefreshList();
			foreach (string newItem in new string[]
			{
				"SUCCESS",
				"NONE"
			}.Concat(GlobalData.Settings.Environment.GetCustomKeychainNames()))
			{
				this.typeFilterCombobox.Items.Add(newItem);
			}
			this.typeFilterCombobox.SelectedIndex = 0;
			this.configFilterCombobox.Items.Add(HitsDBViewModel.DefaultFilter);
			foreach (string newItem2 in from c in this.vm.ConfigsList
			orderby c
			select c)
			{
				this.configFilterCombobox.Items.Add(newItem2);
			}
			this.configFilterCombobox.SelectedIndex = 0;
			ContextMenu contextMenu = (ContextMenu)base.Resources["ItemContextMenu"];
			MenuItem menuItem = (MenuItem)contextMenu.Items[0];
			MenuItem menuItem2 = (MenuItem)contextMenu.Items[1];
			foreach (ExportFormat exportFormat in GlobalData.Settings.Environment.ExportFormats)
			{
				MenuItem menuItem3 = new MenuItem();
				menuItem3.Header = exportFormat.Format;
				menuItem3.Click += this.copySelectedCustom_Click;
				((MenuItem)menuItem.Items[4]).Items.Add(menuItem3);
			}
			foreach (ExportFormat exportFormat2 in GlobalData.Settings.Environment.ExportFormats)
			{
				MenuItem menuItem4 = new MenuItem();
				menuItem4.Header = exportFormat2.Format;
				menuItem4.Click += this.saveSelectedCustom_Click;
				((MenuItem)menuItem2.Items[3]).Items.Add(menuItem4);
			}
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00026C00 File Offset: 0x00024E00
		public void AddConfigToFilter(string name)
		{
			if (!this.configFilterCombobox.Items.Cast<string>().Any((string i) => i == name))
			{
				this.configFilterCombobox.Items.Add(name);
			}
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00026C54 File Offset: 0x00024E54
		private void configFilterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.configFilterCombobox.SelectedValue == null)
			{
				this.vm.ConfigFilter = string.Empty;
				return;
			}
			this.vm.ConfigFilter = this.configFilterCombobox.SelectedValue.ToString();
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.HitsDB;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Changed config filter to ");
			defaultInterpolatedStringHandler.AppendFormatted(this.vm.ConfigFilter);
			defaultInterpolatedStringHandler.AppendLiteral(", found ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.vm.Total);
			defaultInterpolatedStringHandler.AppendLiteral(" hits");
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00026D00 File Offset: 0x00024F00
		private void typeFilterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.vm.TypeFilter = (string)this.typeFilterCombobox.SelectedValue;
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.HitsDB;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Changed type filter to ");
			defaultInterpolatedStringHandler.AppendFormatted(this.vm.TypeFilter);
			defaultInterpolatedStringHandler.AppendLiteral(", found ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.vm.Total);
			defaultInterpolatedStringHandler.AppendLiteral(" hits");
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00026D90 File Offset: 0x00024F90
		private void purgeButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogWarning(Components.HitsDB, "Purge selected, prompting warning", false, 0);
			if (Alert.Choice("This will purge the WHOLE Hits DB, are you sure you want to continue?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
			{
				GlobalData.Logger.LogInfo(Components.HitsDB, "Purge initiated", false, 0);
				this.vm.RemoveAll();
				this.configFilterCombobox.Items.Clear();
				this.configFilterCombobox.Items.Add(HitsDBViewModel.DefaultFilter);
				this.configFilterCombobox.SelectedIndex = 0;
				GlobalData.Logger.LogInfo(Components.HitsDB, "Purge finished", false, 0);
				return;
			}
			GlobalData.Logger.LogInfo(Components.HitsDB, "Purge dismissed", false, 0);
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00026E38 File Offset: 0x00025038
		private void listViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader gridViewColumnHeader = sender as GridViewColumnHeader;
			string propertyName = gridViewColumnHeader.Tag.ToString();
			if (this.listViewSortCol != null)
			{
				AdornerLayer.GetAdornerLayer(this.listViewSortCol).Remove(this.listViewSortAdorner);
				this.hitsListView.Items.SortDescriptions.Clear();
			}
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			if (this.listViewSortCol == gridViewColumnHeader && this.listViewSortAdorner.Direction == listSortDirection)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			this.listViewSortCol = gridViewColumnHeader;
			this.listViewSortAdorner = new SortAdorner(this.listViewSortCol, listSortDirection);
			AdornerLayer.GetAdornerLayer(this.listViewSortCol).Add(this.listViewSortAdorner);
			this.hitsListView.Items.SortDescriptions.Add(new SortDescription(propertyName, listSortDirection));
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00026EF1 File Offset: 0x000250F1
		private void ListViewItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00026EF3 File Offset: 0x000250F3
		private string GetSaveFile()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "TXT files | *.txt";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.ShowDialog();
			return saveFileDialog.FileName;
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00026F18 File Offset: 0x00025118
		private void copySelectedData_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.Selected.CopyToClipboard((Hit hit) => hit.Data);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "Exception while copying hits - " + ex.Message, false, 0);
			}
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00026F84 File Offset: 0x00025184
		private void copySelectedCapture_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.Selected.CopyToClipboard(this.mappingCapture);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "Exception while copying hits - " + ex.Message, false, 0);
			}
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00026FD4 File Offset: 0x000251D4
		private void copySelectedFull_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.Selected.CopyToClipboard(this.mappingFull);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "Exception while copying hits - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00027024 File Offset: 0x00025224
		private void copySelectedCustom_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.Selected.CopyToClipboard((Hit hit) => hit.ToFormattedString(StringExtension.Unescape((sender as MenuItem).Header.ToString(), false)));
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "Exception while copying hits - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00027088 File Offset: 0x00025288
		private void saveSelectedData_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.Selected.SaveToFile(this.GetSaveFile(), (Hit hit) => hit.Data);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "Exception while saving hits - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x000270F8 File Offset: 0x000252F8
		private void saveSelectedCapture_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.Selected.SaveToFile(this.GetSaveFile(), this.mappingCapture);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "Exception while saving hits - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00027150 File Offset: 0x00025350
		private void saveSelectedFull_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.Selected.SaveToFile(this.GetSaveFile(), this.mappingFull);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "Exception while saving hits - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x000271A8 File Offset: 0x000253A8
		private void saveSelectedCustom_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.Selected.SaveToFile(this.GetSaveFile(), (Hit hit) => hit.ToFormattedString(StringExtension.Unescape((sender as MenuItem).Header.ToString(), false)));
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "Exception while copying hits - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00027214 File Offset: 0x00025414
		private void selectAll_Click(object sender, RoutedEventArgs e)
		{
			this.hitsListView.SelectAll();
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x00027224 File Offset: 0x00025424
		private void copySelectedProxy_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Clipboard.SetText(((Hit)this.hitsListView.SelectedItem).Proxy);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "Failed to copy selected proxy - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00027280 File Offset: 0x00025480
		private void searchButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.SearchString = this.searchBar.Text;
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.HitsDB;
			string str = "Changed capture filter to '";
			string searchString = this.vm.SearchString;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("', found ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.vm.Total);
			defaultInterpolatedStringHandler.AppendLiteral(" hits");
			logger.LogInfo(component, str + searchString + defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00027300 File Offset: 0x00025500
		private void sendToRecheck_Click(object sender, RoutedEventArgs e)
		{
			if (this.hitsListView.SelectedItems.Count == 0)
			{
				GlobalData.Logger.LogError(Components.HitsDB, "No hits selected!", true, 0);
				return;
			}
			Hit first = (Hit)this.hitsListView.SelectedItem;
			Wordlist wordlist = new Wordlist("Recheck-" + first.ConfigName, "NULL", GlobalData.Settings.Environment.RecognizeWordlistType(first.Data), "", true, true, false);
			RunnerManagerViewModel runnerManager = GlobalData.RunnerManager;
			runnerManager.Create();
			Runner view = runnerManager.RunnersCollection.Last<RunnerInstance>().View;
			RunnerViewModel viewModel = runnerManager.RunnersCollection.Last<RunnerInstance>().ViewModel;
			GlobalData.MainWindow.ShowRunner(view);
			viewModel.SetWordlist(wordlist);
			viewModel.DataPool = new ListDataPool((from Hit h in this.hitsListView.SelectedItems
			select h.Data).ToList<string>(), "Default");
			try
			{
				Config config = GlobalData.ConfigManager.ConfigsCollection.First((ConfigViewModel c) => c.Name == first.ConfigName).Config;
				viewModel.SetConfig(config, false);
				viewModel.Options.BotsAmount = Math.Min(config.Settings.SuggestedBots, this.hitsListView.SelectedItems.Count);
			}
			catch
			{
			}
			GlobalData.MainWindow.SelectRunner();
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00027490 File Offset: 0x00025690
		private void deleteSelected_Click(object sender, RoutedEventArgs e)
		{
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.HitsDB;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Deleting ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.hitsListView.SelectedItems.Count);
			defaultInterpolatedStringHandler.AppendLiteral(" hits");
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			this.vm.Remove(this.Selected);
			if (this.vm.HitsCollection.Count == 0)
			{
				this.configFilterCombobox.Items.Clear();
				this.configFilterCombobox.Items.Add(HitsDBViewModel.DefaultFilter);
				this.configFilterCombobox.SelectedIndex = 0;
			}
			GlobalData.Logger.LogInfo(Components.HitsDB, "Succesfully sent the delete query and refreshed the list", false, 0);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00027551 File Offset: 0x00025751
		private void removeDuplicatesButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.DeleteDuplicates();
			GlobalData.Logger.LogInfo(Components.HitsDB, "Deleted duplicate hits", false, 0);
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00027570 File Offset: 0x00025770
		private void deleteFilteredButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogWarning(Components.HitsDB, "Delete filtered selected, prompting warning", false, 0);
			if (MessageBox.Show("This will delete all the hits that are currently being displayed, are you sure you want to continue?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.None) != MessageBoxResult.Yes)
			{
				return;
			}
			this.vm.DeleteFiltered();
			if (this.vm.HitsCollection.Count == 0)
			{
				this.configFilterCombobox.Items.Clear();
				this.configFilterCombobox.Items.Add(HitsDBViewModel.DefaultFilter);
				this.configFilterCombobox.SelectedIndex = 0;
			}
			GlobalData.Logger.LogInfo(Components.HitsDB, "Deleted filtered hits", false, 0);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x00027607 File Offset: 0x00025807
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			this.searchButton_Click(this, null);
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00027611 File Offset: 0x00025811
		private void SearchBar_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.searchButton_Click(this, e);
			}
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00027624 File Offset: 0x00025824
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				if (GlobalData.SBSettings.General.DisableAnimationMode)
				{
					this.trans.TransitionStoryboard = new Storyboard();
				}
				else if (!GlobalData.SBSettings.General.DisableAnimationMode)
				{
					this.trans.TransitionStoryboard = null;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x000279F8 File Offset: 0x00025BF8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 21)
			{
				EventSetter eventSetter = new EventSetter();
				eventSetter.Event = UIElement.MouseRightButtonDownEvent;
				eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseRightButtonDown);
				((Style)target).Setters.Add(eventSetter);
			}
		}

		// Token: 0x0400042C RID: 1068
		private HitsDBViewModel vm;

		// Token: 0x0400042D RID: 1069
		private GridViewColumnHeader listViewSortCol;

		// Token: 0x0400042E RID: 1070
		private SortAdorner listViewSortAdorner;

		// Token: 0x0400042F RID: 1071
		private Func<Hit, string> mappingCapture = (Hit hit) => hit.Data + " | " + hit.CapturedString;

		// Token: 0x04000430 RID: 1072
		private Func<Hit, string> mappingFull = (Hit hit) => string.Concat(new string[]
		{
			"Data = ",
			hit.Data,
			" | Type = ",
			hit.Type,
			" | Config = ",
			hit.ConfigName,
			" | Wordlist = ",
			hit.WordlistName,
			" | Proxy = ",
			hit.Proxy,
			" | Date = ",
			hit.Date.ToLongDateString(),
			" | CapturedData = ",
			hit.CapturedString
		});
	}
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
using AngleSharp.Text;
using HandyControl.Controls;
using HandyControl.Data;
using Microsoft.Win32;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.Runners;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.Requests;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro.Views.Main
{
	// Token: 0x0200017F RID: 383
	public partial class ProxyManager : Page, IStyleConnector
	{
		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x00027FCE File Offset: 0x000261CE
		private IEnumerable<Proxylist> SelectedProxylists
		{
			get
			{
				return this.proxylistsListView.SelectedItems.Cast<Proxylist>();
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x00027FE0 File Offset: 0x000261E0
		private IEnumerable<CProxy> SelectedProxies
		{
			get
			{
				return this.proxiesListView.SelectedItems.Cast<CProxy>();
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x00027FF2 File Offset: 0x000261F2
		private Proxylist CurrentProxylist
		{
			get
			{
				return this.proxylistComboBox.SelectedItem as Proxylist;
			}
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00028004 File Offset: 0x00026204
		public ProxyManager()
		{
			this.vm = GlobalData.ProxyManager;
			base.DataContext = this.vm;
			this.InitializeComponent();
			this.botsSlider.Maximum = 200.0;
			this.vm.RefreshList();
			this.vm.ProxyChecker.UpdateProperties();
			this.tabItemProxyChecker.DataContext = this.vm.ProxyChecker;
			this.proxylistComboBox.DataContext = this.vm;
			this.RefreshProxylist_Click(this, null);
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x000280A0 File Offset: 0x000262A0
		private void CheckButton_Click(object sender, RoutedEventArgs e)
		{
			ProxyManager.<CheckButton_Click>d__12 <CheckButton_Click>d__;
			<CheckButton_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<CheckButton_Click>d__.<>4__this = this;
			<CheckButton_Click>d__.<>1__state = -1;
			<CheckButton_Click>d__.<>t__builder.Start<ProxyManager.<CheckButton_Click>d__12>(ref <CheckButton_Click>d__);
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x000280D8 File Offset: 0x000262D8
		public List<CProxy> AddProxies(IEnumerable<string> raw, ProxyType defaultType = 0, string defaultUsername = "", string defaultPassword = "")
		{
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.ProxyManager;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Adding ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(raw.Count<string>());
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<ProxyType>(defaultType);
			defaultInterpolatedStringHandler.AppendLiteral(" proxies to the database");
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			List<CProxy> list = new List<CProxy>();
			foreach (string text in (from p in raw
			where !string.IsNullOrEmpty(p)
			select p).Distinct<string>().ToList<string>())
			{
				try
				{
					CProxy cproxy = new CProxy().Parse(text, defaultType, defaultUsername, defaultPassword);
					if (!cproxy.IsNumeric || cproxy.IsValidNumeric)
					{
						list.Add(cproxy);
					}
				}
				catch
				{
				}
			}
			this.vm.ProxyChecker.AddRange(list);
			this.vm.ProxyChecker.Type = defaultType;
			this.vm.ProxyChecker.UpdateProperties();
			return list;
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0002821C File Offset: 0x0002641C
		private void botsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.vm.ProxyChecker.BotsAmount = (int)e.NewValue;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00028238 File Offset: 0x00026438
		private void deleteNotWorkingButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogInfo(Components.ProxyManager, "Deleting all non working proxies", false, 0);
			this.vm.ProxyChecker.RemoveNotWorking();
			this.vm.ProxyChecker.UpdateProperties();
			this.CurrentProxylist.Proxies = this.vm.ProxyChecker.Proxies.ToList<CProxy>();
			this.vm.Update(this.CurrentProxylist);
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x000282A8 File Offset: 0x000264A8
		private void deleteDuplicatesButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogInfo(Components.ProxyManager, "Deleting duplicate proxies", false, 0);
			this.vm.ProxyChecker.RemoveDuplicates();
			this.vm.ProxyChecker.UpdateProperties();
			this.CurrentProxylist.Proxies = this.vm.ProxyChecker.Proxies.ToList<CProxy>();
			this.vm.Update(this.CurrentProxylist);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00028318 File Offset: 0x00026518
		private void DeleteUntestedButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogInfo(Components.ProxyManager, "Deleting all untested proxies", false, 0);
			this.vm.ProxyChecker.RemoveUntested();
			this.vm.ProxyChecker.UpdateProperties();
			this.CurrentProxylist.Proxies = this.vm.ProxyChecker.Proxies.ToList<CProxy>();
			this.vm.Update(this.CurrentProxylist);
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00028388 File Offset: 0x00026588
		private void ProxylistComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (!this.vm.ProxyChecker.AddMultipleLists)
				{
					this.vm.ProxyChecker.RemoveAll();
				}
				IList<CProxy> proxies = this.CurrentProxylist.Proxies;
				if (proxies != null && proxies.Count > 0)
				{
					this.vm.ProxyChecker.AddRange(this.CurrentProxylist.Proxies);
					this.vm.ProxyChecker.Type = StringExtensions.ToEnum<ProxyType>(this.CurrentProxylist.Type, 0);
					this.vm.ProxyChecker.UpdateProperties();
				}
				else
				{
					this.CurrentProxylist.Proxies = this.AddProxies(File.ReadLines(this.CurrentProxylist.Path), StringExtensions.ToEnum<ProxyType>(this.CurrentProxylist.Type, 0), "", "");
					this.vm.Update(this.CurrentProxylist);
				}
			}
			catch
			{
				this.vm.ProxyChecker.ProxiesCollection.Clear();
			}
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00028498 File Offset: 0x00026698
		private void AddProxySiteUrlButton_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.testSiteComboBox.Text))
			{
				return;
			}
			if (!GlobalData.Settings.ProxyManagerSettings.ProxySiteUrls.Contains(this.vm.ProxyChecker.TestSite))
			{
				GlobalData.Settings.ProxyManagerSettings.ProxySiteUrls.Add(this.vm.ProxyChecker.TestSite);
				IOManager.SaveSettings<ProxyManagerSettings>(Constants.ProxyManagerSettingsFile, GlobalData.Settings.ProxyManagerSettings);
			}
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00028518 File Offset: 0x00026718
		private void RemoveProxySiteUrlButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.testSiteComboBox.Items.Count == 0)
			{
				return;
			}
			if (this.testSiteComboBox.SelectedIndex == -1)
			{
				GlobalData.Settings.ProxyManagerSettings.ProxySiteUrls.Remove(this.testSiteComboBox.Text);
			}
			else
			{
				GlobalData.Settings.ProxyManagerSettings.ProxySiteUrls.RemoveAt(this.testSiteComboBox.SelectedIndex);
			}
			IOManager.SaveSettings<ProxyManagerSettings>(Constants.ProxyManagerSettingsFile, GlobalData.Settings.ProxyManagerSettings);
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0002859C File Offset: 0x0002679C
		private void AddProxyKeyButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.successKeyComboBox.Text == string.Empty)
			{
				return;
			}
			if (!GlobalData.Settings.ProxyManagerSettings.ProxyKeys.Contains(this.vm.ProxyChecker.SuccessKey))
			{
				GlobalData.Settings.ProxyManagerSettings.ProxyKeys.Add(this.vm.ProxyChecker.SuccessKey);
				IOManager.SaveSettings<ProxyManagerSettings>(Constants.ProxyManagerSettingsFile, GlobalData.Settings.ProxyManagerSettings);
			}
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00028620 File Offset: 0x00026820
		private void RemoveProxyKeyButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.successKeyComboBox.Items.Count == 0)
			{
				return;
			}
			if (this.successKeyComboBox.SelectedIndex == -1)
			{
				GlobalData.Settings.ProxyManagerSettings.ProxyKeys.Remove(this.successKeyComboBox.Text);
			}
			else
			{
				GlobalData.Settings.ProxyManagerSettings.ProxyKeys.RemoveAt(this.successKeyComboBox.SelectedIndex);
			}
			IOManager.SaveSettings<ProxyManagerSettings>(Constants.ProxyManagerSettingsFile, GlobalData.Settings.ProxyManagerSettings);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x000286A4 File Offset: 0x000268A4
		private void deleteAllProxiesButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogWarning(Components.ProxyManager, "Purge selected, prompting warning", false, 0);
			if (Alert.Choice("This will purge the WHOLE Proxies DB, are you sure you want to continue?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
			{
				GlobalData.Logger.LogInfo(Components.ProxyManager, "Purge initiated", false, 0);
				this.vm.ProxyChecker.RemoveAll();
				IList<CProxy> proxies = this.CurrentProxylist.Proxies;
				if (proxies != null)
				{
					proxies.Clear();
				}
				this.CurrentProxylist.Proxies = null;
				this.vm.Update(this.CurrentProxylist);
				this.vm.ProxyChecker.UpdateProperties();
				GlobalData.Logger.LogInfo(Components.ProxyManager, "Purge finished", false, 0);
				return;
			}
			GlobalData.Logger.LogInfo(Components.ProxyManager, "Purge dismissed", false, 0);
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00028764 File Offset: 0x00026964
		private void DeleteSelectedPathProxylist_Click(object sender, RoutedEventArgs e)
		{
			this.vm.ProxyChecker.Remove(this.SelectedProxies);
			this.CurrentProxylist.Proxies = this.vm.ProxyChecker.Proxies.ToList<CProxy>();
			this.vm.Update(this.CurrentProxylist);
			this.vm.ProxyChecker.UpdateProperties();
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x000287C8 File Offset: 0x000269C8
		private void exportButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.SelectedProxylists.Count<Proxylist>() <= 0)
			{
				Alert.Warning("No proxies selected!", "Warning", false);
				GlobalData.Logger.LogWarning(Components.ProxyManager, "No proxies selected", false, 0);
				return;
			}
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.Filter = "Text File |*.txt";
			saveFileDialog.Title = "Export proxies";
			bool? flag = saveFileDialog.ShowDialog();
			bool flag2 = false;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				return;
			}
			if (saveFileDialog.FileName != string.Empty)
			{
				LoggerViewModel logger = GlobalData.Logger;
				Components component = Components.ProxyManager;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Exporting ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SelectedProxies.Count<CProxy>());
				defaultInterpolatedStringHandler.AppendLiteral(" proxies");
				logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
				this.SelectedProxies.SaveToFile(saveFileDialog.FileName, (CProxy p) => p.Proxy);
			}
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x000288CC File Offset: 0x00026ACC
		private void deleteButton_Click(object sender, RoutedEventArgs e)
		{
			LoggerViewModel logger = GlobalData.Logger;
			Components component = Components.ProxyManager;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Deleting ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.proxylistsListView.SelectedItems.Count);
			defaultInterpolatedStringHandler.AppendLiteral(" proxies");
			logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			this.vm.Remove(this.SelectedProxylists);
			this.vm.ProxyChecker.UpdateProperties();
			GlobalData.Logger.LogInfo(Components.ProxyManager, "Proxies deleted successfully", false, 0);
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x0002895C File Offset: 0x00026B5C
		private void deleteAllButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogWarning(Components.ProxyManager, "Purge selected, prompting warning", false, 0);
			if (Alert.Choice("This will purge the WHOLE Proxylists DB, are you sure you want to continue?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
			{
				GlobalData.Logger.LogInfo(Components.ProxyManager, "Purge initiated", false, 0);
				this.vm.RemoveAll();
				this.vm.ProxyChecker.UpdateProperties();
				GlobalData.Logger.LogInfo(Components.ProxyManager, "Purge finished", false, 0);
				return;
			}
			GlobalData.Logger.LogInfo(Components.ProxyManager, "Purge dismissed", false, 0);
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x000289E2 File Offset: 0x00026BE2
		private void deleteNotFoundProxyButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Logger.LogWarning(Components.WordlistManager, "Deleting proxylists with missing files.", false, 0);
			this.vm.DeleteNotFound();
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00028A01 File Offset: 0x00026C01
		private void ImportProxyButton_Click(object sender, RoutedEventArgs e)
		{
			new MainDialog(new MainDialog.InputDialog
			{
				Dialog = new DialogAddProxies(this, null),
				Title = "Import Proxies"
			}).ShowDialog();
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00028A2C File Offset: 0x00026C2C
		private void EditProxyButton_CLick(object sender, RoutedEventArgs e)
		{
			if (this.proxylistsListView.SelectedIndex == -1)
			{
				return;
			}
			Proxylist proxylist = this.proxylistsListView.SelectedItem as Proxylist;
			DialogAddProxies dialogAddProxies = new DialogAddProxies(this, proxylist);
			new MainDialog(new MainDialog.InputDialog
			{
				Dialog = dialogAddProxies,
				Title = "Edit Proxies"
			}).ShowDialog();
			if (dialogAddProxies.DialogResult == DialogResult.OK)
			{
				this.vm.Update(proxylist);
				this.vm.RefreshList();
			}
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00028AA4 File Offset: 0x00026CA4
		private void shareProxyButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.proxylistsListView.SelectedIndex == -1)
			{
				return;
			}
			this.tabControl.SelectedIndex = 1;
			if (this.proxylistComboBox.SelectedIndex == this.proxylistsListView.SelectedIndex)
			{
				this.proxylistComboBox.SelectedIndex = -1;
			}
			this.proxylistComboBox.SelectedIndex = this.proxylistsListView.SelectedIndex;
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00028B06 File Offset: 0x00026D06
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			this.vm.SearchString = this.searchBar.Text;
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00028B1E File Offset: 0x00026D1E
		private void SearchBar_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchBar_SearchStarted(sender, null);
			}
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00028B31 File Offset: 0x00026D31
		private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.searchBar.Text))
			{
				this.SearchBar_SearchStarted(sender, null);
			}
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00028B50 File Offset: 0x00026D50
		private void ProxyListViewDrop(object sender, System.Windows.DragEventArgs e)
		{
			if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
			{
				foreach (string text in (from x in (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop)
				where x.EndsWith(".txt")
				select x).ToArray<string>())
				{
					try
					{
						Proxylist proxy;
						if (text.ToLower().Contains("http") || text.ToLower().Contains("https"))
						{
							proxy = ProxyManagerViewModel.FileToProxylist(text, 0);
						}
						else if (text.ToLower().Contains("socks4"))
						{
							proxy = ProxyManagerViewModel.FileToProxylist(text, 1);
						}
						else if (text.ToLower().Contains("socks4a"))
						{
							proxy = ProxyManagerViewModel.FileToProxylist(text, 2);
						}
						else if (text.ToLower().Contains("socks5"))
						{
							proxy = ProxyManagerViewModel.FileToProxylist(text, 3);
						}
						else
						{
							proxy = ProxyManagerViewModel.FileToProxylist(text, 0);
						}
						this.vm.Add(proxy);
					}
					catch (Exception ex)
					{
						GlobalData.Logger.LogError(Components.ProxyManager, "Failed to open file " + text + " - " + ex.Message, false, 0);
					}
				}
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00028C9C File Offset: 0x00026E9C
		private void copySelectedProxies_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.SelectedProxies.CopyToClipboard((CProxy p) => p.Host + ":" + p.Port);
				LoggerViewModel logger = GlobalData.Logger;
				Components component = Components.ProxyManager;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Copied ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SelectedProxies.Count<CProxy>());
				defaultInterpolatedStringHandler.AppendLiteral(" proxies");
				logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.ProxyManager, "Failed to copy proxies - " + ex.Message, false, 0);
			}
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00028D4C File Offset: 0x00026F4C
		private void copySelectedProxiesFull_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.SelectedProxies.CopyToClipboard(delegate(CProxy p)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(3, 3);
					defaultInterpolatedStringHandler2.AppendLiteral("(");
					defaultInterpolatedStringHandler2.AppendFormatted<ProxyType>(p.Type);
					defaultInterpolatedStringHandler2.AppendLiteral(")");
					defaultInterpolatedStringHandler2.AppendFormatted(p.Host);
					defaultInterpolatedStringHandler2.AppendLiteral(":");
					defaultInterpolatedStringHandler2.AppendFormatted(p.Port);
					return defaultInterpolatedStringHandler2.ToStringAndClear() + (string.IsNullOrEmpty(p.Username) ? "" : (":" + p.Username + ":" + p.Password));
				});
				LoggerViewModel logger = GlobalData.Logger;
				Components component = Components.ProxyManager;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Copied ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SelectedProxies.Count<CProxy>());
				defaultInterpolatedStringHandler.AppendLiteral(" proxies");
				logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.ProxyManager, "Failed to copy proxies - " + ex.Message, false, 0);
			}
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00028DFC File Offset: 0x00026FFC
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

		// Token: 0x0600093C RID: 2364 RVA: 0x00028EB8 File Offset: 0x000270B8
		private void proxiesListViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader gridViewColumnHeader = sender as GridViewColumnHeader;
			string propertyName = gridViewColumnHeader.Tag.ToString();
			if (this.listViewSortCol != null)
			{
				AdornerLayer.GetAdornerLayer(this.listViewSortCol).Remove(this.listViewSortAdorner);
				this.proxiesListView.Items.SortDescriptions.Clear();
			}
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			if (this.listViewSortCol == gridViewColumnHeader && this.listViewSortAdorner.Direction == listSortDirection)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			this.listViewSortCol = gridViewColumnHeader;
			this.listViewSortAdorner = new SortAdorner(this.listViewSortCol, listSortDirection);
			AdornerLayer.GetAdornerLayer(this.listViewSortCol).Add(this.listViewSortAdorner);
			this.proxiesListView.Items.SortDescriptions.Add(new SortDescription(propertyName, listSortDirection));
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x00028F71 File Offset: 0x00027171
		private void ListViewItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x00028F74 File Offset: 0x00027174
		private void CopySelectedNameProxylist_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.SelectedProxylists.CopyToClipboard((Proxylist p) => p.Name);
				LoggerViewModel logger = GlobalData.Logger;
				Components component = Components.ProxyManager;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Copied ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SelectedProxylists.Count<Proxylist>());
				defaultInterpolatedStringHandler.AppendLiteral(" proxylist name(s)");
				logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.ProxyManager, "Failed to copy proxylist name(s) - " + ex.Message, false, 0);
			}
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00029024 File Offset: 0x00027224
		private void CopySelectedPathProxylist_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.SelectedProxylists.CopyToClipboard((Proxylist p) => p.Path);
				LoggerViewModel logger = GlobalData.Logger;
				Components component = Components.ProxyManager;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Copied ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.SelectedProxylists.Count<Proxylist>());
				defaultInterpolatedStringHandler.AppendLiteral(" proxylist path(s)");
				logger.LogInfo(component, defaultInterpolatedStringHandler.ToStringAndClear(), false, 0);
			}
			catch (Exception ex)
			{
				GlobalData.Logger.LogError(Components.ProxyManager, "Failed to copy proxylist path(s) - " + ex.Message, false, 0);
			}
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x000290D4 File Offset: 0x000272D4
		private void RefreshProxylist_Click(object sender, RoutedEventArgs e)
		{
			this.deleteNotFoundProxyButton_Click(this, e);
			for (int i = 0; i < this.vm.ProxylistsCollection.Count; i++)
			{
				Proxylist proxy = ProxyManagerViewModel.RefreshProxylist(this.vm.ProxylistsCollection[i]);
				this.vm.Update(proxy);
			}
			this.vm.RefreshList();
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00029134 File Offset: 0x00027334
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

		// Token: 0x06000944 RID: 2372 RVA: 0x0002980C File Offset: 0x00027A0C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			EventSetter eventSetter;
			if (connectionId == 18)
			{
				eventSetter = new EventSetter();
				eventSetter.Event = UIElement.MouseRightButtonDownEvent;
				eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseRightButtonDown);
				((Style)target).Setters.Add(eventSetter);
				return;
			}
			if (connectionId != 42)
			{
				return;
			}
			eventSetter = new EventSetter();
			eventSetter.Event = UIElement.MouseRightButtonDownEvent;
			eventSetter.Handler = new MouseButtonEventHandler(this.ListViewItem_MouseRightButtonDown);
			((Style)target).Setters.Add(eventSetter);
		}

		// Token: 0x0400043F RID: 1087
		public ProxyManagerViewModel vm;

		// Token: 0x04000440 RID: 1088
		private GridViewColumnHeader listViewSortCol;

		// Token: 0x04000441 RID: 1089
		private SortAdorner listViewSortAdorner;

		// Token: 0x04000442 RID: 1090
		private WorkerStatus Status;

		// Token: 0x04000443 RID: 1091
		private CancellationTokenSource cts = new CancellationTokenSource();
	}
}

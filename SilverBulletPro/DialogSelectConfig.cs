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
using PluginFrameworkPro;
using SilverBulletPro.Core;
using SilverBulletPro.Core.LS;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Plugins;
using SilverBulletPro.ViewModels;
using SilverBulletPro.Views.Main.Runner;
using SilverBulletPro.Views.StackerBlocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro
{
	// Token: 0x02000027 RID: 39
	public class DialogSelectConfig : Page, IComponentConnector, IStyleConnector
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600015A RID: 346 RVA: 0x0000B391 File Offset: 0x00009591
		// (set) Token: 0x0600015B RID: 347 RVA: 0x0000B399 File Offset: 0x00009599
		private object Caller { get; set; }

		// Token: 0x0600015C RID: 348 RVA: 0x0000B3A2 File Offset: 0x000095A2
		public DialogSelectConfig(object caller)
		{
			this.Caller = caller;
			this.vm = GlobalData.ConfigManager;
			base.DataContext = this.vm;
			this.InitializeComponent();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000B3D0 File Offset: 0x000095D0
		private void selectButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.configsListView.SelectedItems.Count == 0)
			{
				return;
			}
			if (this.Caller.GetType() == typeof(Runner))
			{
				Config config = ((ConfigViewModel)this.configsListView.SelectedItem).Config;
				Runner runner = this.Caller as Runner;
				if (GlobalData.SBSettings.General.LiveConfigUpdates)
				{
					runner.SetConfig(config);
				}
				else
				{
					runner.SetConfig(IOManager.CloneConfig(config));
				}
			}
			if (this.Caller.GetType() == typeof(ValueTuple<RunnerOptions, Runner>))
			{
				ValueTuple<RunnerOptions, Runner> valueTuple = (ValueTuple<RunnerOptions, Runner>)this.Caller;
				valueTuple.Item1.configComboBox.SelectedItem = this.configsListView.SelectedItem;
				valueTuple.Item1.EncryptedConfig = null;
			}
			else if (this.Caller.GetType() == typeof(UserControlConfig))
			{
				((UserControlConfig)this.Caller).Config = (ConfigViewModel)this.configsListView.SelectedItem;
			}
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000B4F0 File Offset: 0x000096F0
		private void listViewColumnHeader_Click(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader gridViewColumnHeader = sender as GridViewColumnHeader;
			string propertyName = gridViewColumnHeader.Tag.ToString();
			if (this.listViewSortCol != null)
			{
				AdornerLayer.GetAdornerLayer(this.listViewSortCol).Remove(this.listViewSortAdorner);
				this.configsListView.Items.SortDescriptions.Clear();
			}
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			if (this.listViewSortCol == gridViewColumnHeader && this.listViewSortAdorner.Direction == listSortDirection)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			this.listViewSortCol = gridViewColumnHeader;
			this.listViewSortAdorner = new SortAdorner(this.listViewSortCol, listSortDirection);
			AdornerLayer.GetAdornerLayer(this.listViewSortCol).Add(this.listViewSortAdorner);
			this.configsListView.Items.SortDescriptions.Add(new SortDescription(propertyName, listSortDirection));
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000B5A9 File Offset: 0x000097A9
		private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			this.selectButton_Click(this, null);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000B5B3 File Offset: 0x000097B3
		private void ListViewItem_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.selectButton_Click(this, null);
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000B5C6 File Offset: 0x000097C6
		private void FilterTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.SearchBar_SearchStarted(this, null);
			}
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000B5D9 File Offset: 0x000097D9
		private void SearchBar_SearchStarted(object sender, FunctionEventArgs<string> e)
		{
			this.vm.SearchString = this.searchBar.Text;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000B5F1 File Offset: 0x000097F1
		private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.searchBar.Text))
			{
				this.SearchBar_SearchStarted(this, null);
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000B60D File Offset: 0x0000980D
		private void refreshButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.Rescan();
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000B61C File Offset: 0x0000981C
		private void selectEncButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Runner runner = this.Caller as Runner;
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "Config Enc|*.espk"
				};
				bool? flag = openFileDialog.ShowDialog();
				bool flag2 = false;
				if (!(flag.GetValueOrDefault() == flag2 & flag != null) || !(Path.GetExtension(openFileDialog.FileName).ToLower() != ".espk"))
				{
					string text = Alert.CustomInput("Password", "Custom Title", null);
					if (!string.IsNullOrEmpty(text))
					{
						Config config;
						if (runner == null && this.Caller.GetType() == typeof(ValueTuple<RunnerOptions, Runner>))
						{
							ValueTuple<RunnerOptions, Runner> valueTuple = (ValueTuple<RunnerOptions, Runner>)this.Caller;
							RunnerOptions item = valueTuple.Item1;
							runner = valueTuple.Item2;
							config = (item.EncryptedConfig = IOManager.CloneConfig(IOManager.Unpack(CryptConfig.Decrypt(openFileDialog.FileName, text), "")));
						}
						else
						{
							runner.SetConfig(config = IOManager.CloneConfig(IOManager.Unpack(CryptConfig.Decrypt(openFileDialog.FileName, text), "")));
						}
						if (config != null && config.Settings.RequiredPlugins.Length != 0)
						{
							try
							{
								ValueTuple<IEnumerable<PluginControl>, IEnumerable<IBlockPlugin>> valueTuple2 = Loader.LoadPlugins(Constants.PluginsFolder);
								IEnumerable<PluginControl> item2 = valueTuple2.Item1;
								IEnumerable<IBlockPlugin> item3 = valueTuple2.Item2;
								GlobalData.BlockPlugins = item3.ToList<IBlockPlugin>();
								MainWindow.Plugins = item2;
								foreach (IBlockPlugin blockPlugin in item3)
								{
									try
									{
										GlobalData.BlockMappings.Add(new SilverBlock(blockPlugin.GetType(), typeof(BlockPluginPage), blockPlugin.Background, blockPlugin.Foreground, null));
										BlockParser.BlockMappings.Add(blockPlugin.Name, blockPlugin.GetType());
										GlobalData.Logger.LogInfo(Components.Main, "Initialized " + blockPlugin.Name + " block plugin", false, 0);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						((MainDialog)base.Parent).Close();
					}
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000B898 File Offset: 0x00009A98
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogselectconfig.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000B8C8 File Offset: 0x00009AC8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.searchBar = (SearchBar)target;
				this.searchBar.KeyDown += this.FilterTextBox_KeyDown;
				this.searchBar.SearchStarted += this.SearchBar_SearchStarted;
				this.searchBar.TextChanged += this.SearchBar_TextChanged;
				return;
			case 2:
				this.configsListView = (ListView)target;
				return;
			case 4:
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
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
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
				return;
			case 11:
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
				return;
			case 12:
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
				return;
			case 13:
				((GridViewColumnHeader)target).Click += this.listViewColumnHeader_Click;
				return;
			case 14:
				this.refreshButton = (Button)target;
				this.refreshButton.Click += this.refreshButton_Click;
				return;
			case 15:
				this.selectButton = (Button)target;
				this.selectButton.Click += this.selectButton_Click;
				return;
			case 16:
				this.selectEncButton = (Button)target;
				this.selectEncButton.Click += this.selectEncButton_Click;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000BAE4 File Offset: 0x00009CE4
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

		// Token: 0x040000B2 RID: 178
		private GridViewColumnHeader listViewSortCol;

		// Token: 0x040000B3 RID: 179
		private SortAdorner listViewSortAdorner;

		// Token: 0x040000B5 RID: 181
		private ConfigManagerViewModel vm;

		// Token: 0x040000B6 RID: 182
		internal SearchBar searchBar;

		// Token: 0x040000B7 RID: 183
		internal ListView configsListView;

		// Token: 0x040000B8 RID: 184
		internal Button refreshButton;

		// Token: 0x040000B9 RID: 185
		internal Button selectButton;

		// Token: 0x040000BA RID: 186
		internal Button selectEncButton;

		// Token: 0x040000BB RID: 187
		private bool _contentLoaded;
	}
}

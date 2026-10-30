using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core;

namespace SilverBulletPro.Views.Main.Configs.OtherOptions
{
	// Token: 0x020001A7 RID: 423
	public partial class Selenium : Page
	{
		// Token: 0x06000BD2 RID: 3026 RVA: 0x00040070 File Offset: 0x0003E270
		public Selenium()
		{
			this.InitializeComponent();
			base.DataContext = (this.vm = GlobalData.ConfigManager.CurrentConfig.Config.Settings);
			try
			{
				this.quitBrowserStatusesComboBox.SelectedIndex = 0;
			}
			catch
			{
			}
			try
			{
				this.commandLineArgsComboBox.SelectedIndex = 0;
			}
			catch
			{
			}
			foreach (string str in this.vm.SeleChromeExtensions)
			{
				this.extensionsBox.AppendText(str + Environment.NewLine);
			}
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x00040144 File Offset: 0x0003E344
		private void AddQuitBrowserStatusesButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.quitBrowserStatusesComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.SeleniumQuitBrowserStatuses);
					hashSet.Add(this.quitBrowserStatusesComboBox.Text);
					this.vm.SeleniumQuitBrowserStatuses = hashSet.ToArray<string>();
					this.quitBrowserStatusesComboBox.SelectedIndex = this.quitBrowserStatusesComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x000401CC File Offset: 0x0003E3CC
		private void AddCommandLineArgButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.commandLineArgsComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.SeleniumCmdLineArgs);
					hashSet.Add(this.commandLineArgsComboBox.Text);
					this.vm.SeleniumCmdLineArgs = hashSet.ToArray<string>();
					this.commandLineArgsComboBox.SelectedIndex = this.commandLineArgsComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x00040254 File Offset: 0x0003E454
		private void RemoveQuitBrowserStatusesButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.quitBrowserStatusesComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.SeleniumQuitBrowserStatuses);
					hashSet.Remove(this.quitBrowserStatusesComboBox.Text);
					this.vm.SeleniumQuitBrowserStatuses = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x000402BC File Offset: 0x0003E4BC
		private void RemoveCommandLineArgButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.commandLineArgsComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.SeleniumCmdLineArgs);
					hashSet.Remove(this.commandLineArgsComboBox.Text);
					this.vm.SeleniumCmdLineArgs = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x00040324 File Offset: 0x0003E524
		private void ExtensionsBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				this.vm.SeleChromeExtensions = this.extensionsBox.Text.Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None).ToList<string>();
			}
			catch
			{
			}
		}

		// Token: 0x040005E3 RID: 1507
		private ConfigSettings vm;
	}
}

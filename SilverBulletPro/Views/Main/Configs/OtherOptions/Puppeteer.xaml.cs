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
	// Token: 0x020001A4 RID: 420
	public partial class Puppeteer : Page
	{
		// Token: 0x06000BBC RID: 3004 RVA: 0x0003F8A8 File Offset: 0x0003DAA8
		public Puppeteer()
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
			try
			{
				this.blockedUrlsComboBox.SelectedIndex = 0;
			}
			catch
			{
			}
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0003F944 File Offset: 0x0003DB44
		private void AddQuitBrowserStatusesButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.quitBrowserStatusesComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.PuppeteerQuitBrowserStatuses);
					hashSet.Add(this.quitBrowserStatusesComboBox.Text);
					this.vm.PuppeteerQuitBrowserStatuses = hashSet.ToArray<string>();
					this.quitBrowserStatusesComboBox.SelectedIndex = this.quitBrowserStatusesComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x0003F9CC File Offset: 0x0003DBCC
		private void AddCommandLineArgButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.commandLineArgsComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.PuppeteerCmdLineArgs);
					hashSet.Add(this.commandLineArgsComboBox.Text);
					this.vm.PuppeteerCmdLineArgs = hashSet.ToArray<string>();
					this.commandLineArgsComboBox.SelectedIndex = this.commandLineArgsComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x0003FA54 File Offset: 0x0003DC54
		private void RemoveQuitBrowserStatusesButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.quitBrowserStatusesComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.PuppeteerQuitBrowserStatuses);
					hashSet.Remove(this.quitBrowserStatusesComboBox.Text);
					this.vm.PuppeteerQuitBrowserStatuses = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0003FABC File Offset: 0x0003DCBC
		private void RemoveCommandLineArgButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.commandLineArgsComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.PuppeteerCmdLineArgs);
					hashSet.Remove(this.commandLineArgsComboBox.Text);
					this.vm.SeleniumCmdLineArgs = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0003FB24 File Offset: 0x0003DD24
		private void AddBlockedUrlsButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.blockedUrlsComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.PuppeteerBlockedUrls);
					hashSet.Add(this.blockedUrlsComboBox.Text);
					this.vm.PuppeteerBlockedUrls = hashSet.ToArray<string>();
					this.blockedUrlsComboBox.SelectedIndex = this.blockedUrlsComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x0003FBAC File Offset: 0x0003DDAC
		private void RemoveBlockedUrlsButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.blockedUrlsComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(this.vm.PuppeteerBlockedUrls);
					hashSet.Remove(this.blockedUrlsComboBox.Text);
					this.vm.PuppeteerBlockedUrls = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x040005D7 RID: 1495
		private ConfigSettings vm;
	}
}

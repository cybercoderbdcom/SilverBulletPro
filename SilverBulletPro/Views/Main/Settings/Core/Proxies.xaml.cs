using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.Views.Main.Settings.Core
{
	// Token: 0x02000196 RID: 406
	public partial class Proxies : Page
	{
		// Token: 0x06000A38 RID: 2616 RVA: 0x0002FF9D File Offset: 0x0002E19D
		public Proxies()
		{
			this.vm = GlobalData.Settings.CoreSettings.Proxies;
			base.DataContext = this.vm;
			this.InitializeComponent();
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x0002FFCC File Offset: 0x0002E1CC
		private void AddGlobalBanKeysButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.globalBanKeysComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(GlobalData.Settings.CoreSettings.Proxies.GlobalBanKeys);
					hashSet.Add(this.globalBanKeysComboBox.Text);
					GlobalData.Settings.CoreSettings.Proxies.GlobalBanKeys = hashSet.ToArray<string>();
					this.globalBanKeysComboBox.SelectedIndex = this.globalBanKeysComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00030068 File Offset: 0x0002E268
		private void RemoveGlobalBanKeysButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.globalBanKeysComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(GlobalData.Settings.CoreSettings.Proxies.GlobalBanKeys);
					hashSet.Remove(this.globalBanKeysComboBox.Text);
					GlobalData.Settings.CoreSettings.Proxies.GlobalBanKeys = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x000300E0 File Offset: 0x0002E2E0
		private void AddGlobalRetryKeysButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.globalRetryKeysComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(GlobalData.Settings.CoreSettings.Proxies.GlobalRetryKeys);
					hashSet.Add(this.globalRetryKeysComboBox.Text);
					GlobalData.Settings.CoreSettings.Proxies.GlobalRetryKeys = hashSet.ToArray<string>();
					this.globalRetryKeysComboBox.SelectedIndex = this.globalRetryKeysComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0003017C File Offset: 0x0002E37C
		private void RemoveGlobalRetryKeysButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.globalRetryKeysComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(GlobalData.Settings.CoreSettings.Proxies.GlobalRetryKeys);
					hashSet.Remove(this.globalRetryKeysComboBox.Text);
					GlobalData.Settings.CoreSettings.Proxies.GlobalRetryKeys = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x040004FA RID: 1274
		private ProxiesSettings vm;
	}
}

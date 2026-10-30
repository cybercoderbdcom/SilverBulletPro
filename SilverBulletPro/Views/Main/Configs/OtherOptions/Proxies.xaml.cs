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
	// Token: 0x020001A3 RID: 419
	public partial class Proxies : Page
	{
		// Token: 0x06000BB7 RID: 2999 RVA: 0x0003F6E4 File Offset: 0x0003D8E4
		public Proxies()
		{
			this.InitializeComponent();
			base.DataContext = (this.settings = GlobalData.ConfigManager.CurrentConfig.Config.Settings);
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0003F720 File Offset: 0x0003D920
		private void AddBanProxyOnStatuses_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.banProxyAfterStatusComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(this.settings.BanProxyOnStatuses);
					hashSet.Add(this.banProxyAfterStatusComboBox.Text);
					this.settings.BanProxyOnStatuses = hashSet.ToArray<string>();
					this.banProxyAfterStatusComboBox.SelectedIndex = this.banProxyAfterStatusComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0003F7A8 File Offset: 0x0003D9A8
		private void RemoveBanProxyOnStatuses_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.banProxyAfterStatusComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(this.settings.BanProxyOnStatuses);
					hashSet.Remove(this.banProxyAfterStatusComboBox.Text);
					this.settings.BanProxyOnStatuses = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x040005D4 RID: 1492
		private ConfigSettings settings;
	}
}

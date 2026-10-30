using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.Views.Main.Settings.Core
{
	// Token: 0x02000194 RID: 404
	public partial class General : Page
	{
		// Token: 0x06000A30 RID: 2608 RVA: 0x0002FD68 File Offset: 0x0002DF68
		public General()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.Settings.CoreSettings.General;
			foreach (string newItem in Enum.GetNames(typeof(BotsDisplayMode)))
			{
				this.botsDisplayModeComboBox.Items.Add(newItem);
			}
			foreach (string newItem2 in Enum.GetNames(typeof(HttpRequestLibrary)))
			{
				this.defaultHttpRequestModeComboBox.Items.Add(newItem2);
			}
			this.botsDisplayModeComboBox.SelectedIndex = GlobalData.Settings.CoreSettings.General.BotsDisplayMode;
			this.defaultHttpRequestModeComboBox.SelectedIndex = GlobalData.Settings.CoreSettings.General.DefaultHttpRequestLib;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0002FE3C File Offset: 0x0002E03C
		private void botsDisplayModeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			GlobalData.Settings.CoreSettings.General.BotsDisplayMode = this.botsDisplayModeComboBox.SelectedIndex;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x0002FE60 File Offset: 0x0002E060
		private void DefaultHttpRequestModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			BlockRequest.DefaultHttpRequestLib = (GlobalData.Settings.CoreSettings.General.DefaultHttpRequestLib = this.defaultHttpRequestModeComboBox.SelectedIndex);
		}
	}
}

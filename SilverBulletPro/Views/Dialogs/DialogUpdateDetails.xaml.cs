using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MdXaml;
using SilverBulletPro.Updater;

namespace SilverBulletPro.Views.Dialogs
{
	// Token: 0x020001AE RID: 430
	public partial class DialogUpdateDetails : Page
	{
		// Token: 0x06000C32 RID: 3122 RVA: 0x00043E0D File Offset: 0x0004200D
		public DialogUpdateDetails(LatestRelease latestRelease)
		{
			this.InitializeComponent();
			this.textBox.Text = latestRelease.Assets[0].Browser_Download_Url;
			this.markDown.Markdown = latestRelease.Body;
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x00043E44 File Offset: 0x00042044
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Clipboard.SetText(this.textBox.Text);
			}
			catch
			{
			}
		}
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MdXaml;
using SilverBulletPro.Extensions;

namespace SilverBulletPro.Views.Main.Configs.OtherOptions
{
	// Token: 0x020001A5 RID: 421
	public partial class Readme : Page
	{
		// Token: 0x06000BC5 RID: 3013 RVA: 0x0003FD3C File Offset: 0x0003DF3C
		public Readme()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.ConfigManager.CurrentConfig.Config.Settings;
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x0003FD64 File Offset: 0x0003DF64
		private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			Action action = this.action;
			if (action == null)
			{
				return;
			}
			action();
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x0003FD78 File Offset: 0x0003DF78
		private void MarkdownCheckBox_Click(object sender, RoutedEventArgs e)
		{
			if (this.chbMarkdown.IsChecked.GetValueOrDefault())
			{
				this.action = delegate()
				{
					this.previewMarkdown.Markdown = this.richTextBox.GetText();
				};
				this.preview.Visibility = Visibility.Collapsed;
				this.previewMarkdown.Visibility = Visibility.Visible;
			}
			else
			{
				this.action = delegate()
				{
					this.preview.Text = this.richTextBox.GetText();
				};
				this.previewMarkdown.Visibility = Visibility.Collapsed;
				this.preview.Visibility = Visibility.Visible;
			}
			this.action();
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0003FDFC File Offset: 0x0003DFFC
		private void Page_LostFocus(object sender, RoutedEventArgs e)
		{
			try
			{
				GlobalData.ConfigManager.CurrentConfig.Config.Settings.AdditionalInfo = this.richTextBox.GetText();
			}
			catch
			{
			}
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0003FE44 File Offset: 0x0003E044
		private void richTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			this.Page_LostFocus(this, e);
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0003FE50 File Offset: 0x0003E050
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				this.chbMarkdown.IsChecked = new bool?(GlobalData.ConfigManager.CurrentConfig.Config.Settings.UseMarkdown);
				this.MarkdownCheckBox_Click(this.chbMarkdown, e);
				this.richTextBox.SetText(GlobalData.ConfigManager.CurrentConfig.Config.Settings.AdditionalInfo);
			}
			catch
			{
			}
		}

		// Token: 0x040005DC RID: 1500
		private Action action;
	}
}

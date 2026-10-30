using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using AngleSharp.Text;
using Microsoft.CSharp.RuntimeBinder;
using PluginFrameworkPro.Attributes;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Extensions;
using SilverBulletPro.Plugins;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000046 RID: 70
	public partial class UserControlWordlist : UserControl, IControl
	{
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000336 RID: 822 RVA: 0x00013B06 File Offset: 0x00011D06
		// (set) Token: 0x06000337 RID: 823 RVA: 0x00013B0E File Offset: 0x00011D0E
		public Wordlist Wordlist { get; set; }

		// Token: 0x06000338 RID: 824 RVA: 0x00013B17 File Offset: 0x00011D17
		public UserControlWordlist(WordlistPicker wordlistPicker)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.SetProperties(wordlistPicker);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00013B33 File Offset: 0x00011D33
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.Wordlist;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00013B3C File Offset: 0x00011D3C
		public void SetValue(dynamic value)
		{
			if (UserControlWordlist.<>o__6.<>p__0 == null)
			{
				UserControlWordlist.<>o__6.<>p__0 = CallSite<Func<CallSite, object, Wordlist>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Wordlist), typeof(UserControlWordlist)));
			}
			this.Wordlist = UserControlWordlist.<>o__6.<>p__0.Target(UserControlWordlist.<>o__6.<>p__0, value);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00013B90 File Offset: 0x00011D90
		private void Choose_Click(object sender, RoutedEventArgs e)
		{
			new MainDialog(new MainDialog.InputDialog
			{
				Dialog = new DialogSelectWordlist(this),
				Title = "Select a Wordlist"
			}).ShowDialog();
			if (this.Wordlist != null)
			{
				this.WordlistName.Text = this.Wordlist.Name;
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00013BE4 File Offset: 0x00011DE4
		private void SetProperties(WordlistPicker wordlistPicker)
		{
			if (!string.IsNullOrWhiteSpace(wordlistPicker.ForeColor))
			{
				this.WordlistName.Foreground = wordlistPicker.ForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(wordlistPicker.BackColor))
			{
				this.WordlistName.Background = wordlistPicker.BackColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(wordlistPicker.BtnForeColor))
			{
				this.Choose.Foreground = wordlistPicker.BtnForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(wordlistPicker.BtnBackColor))
			{
				this.Choose.Background = wordlistPicker.BtnBackColor.ToBrush();
			}
			this.Choose.Visibility = (this.WordlistName.Visibility = StringExtensions.ToEnum<Visibility>(wordlistPicker.Display.ToString(), Visibility.Visible));
			if (!string.IsNullOrEmpty(wordlistPicker.Tooltip))
			{
				this.Choose.ToolTip = wordlistPicker.Tooltip;
			}
		}
	}
}

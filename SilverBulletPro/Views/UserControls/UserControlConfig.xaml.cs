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
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.Plugins;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x0200003E RID: 62
	public partial class UserControlConfig : UserControl, IControl
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00012830 File Offset: 0x00010A30
		// (set) Token: 0x060002EB RID: 747 RVA: 0x00012838 File Offset: 0x00010A38
		public ConfigViewModel Config { get; set; }

		// Token: 0x060002EC RID: 748 RVA: 0x00012841 File Offset: 0x00010A41
		public UserControlConfig(ConfigPicker configPicker)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.SetProperties(configPicker);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0001285D File Offset: 0x00010A5D
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.Config;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00012868 File Offset: 0x00010A68
		public void SetValue(dynamic value)
		{
			if (UserControlConfig.<>o__6.<>p__0 == null)
			{
				UserControlConfig.<>o__6.<>p__0 = CallSite<Func<CallSite, object, ConfigViewModel>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(ConfigViewModel), typeof(UserControlConfig)));
			}
			this.Config = UserControlConfig.<>o__6.<>p__0.Target(UserControlConfig.<>o__6.<>p__0, value);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000128BC File Offset: 0x00010ABC
		private void Choose_Click(object sender, RoutedEventArgs e)
		{
			new MainDialog(new MainDialog.InputDialog
			{
				Dialog = new DialogSelectConfig(this),
				Title = "Select a Config"
			}).ShowDialog();
			if (this.Config != null)
			{
				this.ConfigName.Text = this.Config.Name;
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00012910 File Offset: 0x00010B10
		private void SetProperties(ConfigPicker configPicker)
		{
			if (!string.IsNullOrWhiteSpace(configPicker.ForeColor))
			{
				this.ConfigName.Foreground = configPicker.ForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(configPicker.BackColor))
			{
				this.ConfigName.Background = configPicker.BackColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(configPicker.BtnForeColor))
			{
				this.Choose.Foreground = configPicker.BtnForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(configPicker.BtnBackColor))
			{
				this.Choose.Background = configPicker.BtnBackColor.ToBrush();
			}
			this.Choose.Visibility = (this.ConfigName.Visibility = StringExtensions.ToEnum<Visibility>(configPicker.Display.ToString(), Visibility.Visible));
		}
	}
}

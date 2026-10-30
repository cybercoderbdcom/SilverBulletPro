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
using Microsoft.Win32;
using PluginFrameworkPro.Attributes;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Extensions;
using SilverBulletPro.Plugins;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000041 RID: 65
	public partial class UserControlFilePicker : UserControl, IControl
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000308 RID: 776 RVA: 0x00012F50 File Offset: 0x00011150
		// (set) Token: 0x06000309 RID: 777 RVA: 0x00012F58 File Offset: 0x00011158
		public string Filter { get; set; }

		// Token: 0x0600030A RID: 778 RVA: 0x00012F61 File Offset: 0x00011161
		public UserControlFilePicker(string location, FilePicker filePicker, EventObject[] events = null)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.SetProperties(filePicker);
			this.Filter = filePicker.Filter;
			this.SetValue(location);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00012F90 File Offset: 0x00011190
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.Location.Text;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00012FA0 File Offset: 0x000111A0
		public void SetValue(dynamic value)
		{
			TextBox location = this.Location;
			if (UserControlFilePicker.<>o__6.<>p__0 == null)
			{
				UserControlFilePicker.<>o__6.<>p__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(UserControlFilePicker)));
			}
			location.Text = UserControlFilePicker.<>o__6.<>p__0.Target(UserControlFilePicker.<>o__6.<>p__0, value);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00012FFC File Offset: 0x000111FC
		private void Choose_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = this.Filter;
			bool? flag = openFileDialog.ShowDialog();
			if (flag != null && flag.Value)
			{
				this.SetValue(openFileDialog.FileName);
			}
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00013040 File Offset: 0x00011240
		private void SetProperties(FilePicker filePicker)
		{
			if (!string.IsNullOrWhiteSpace(filePicker.ForeColor))
			{
				this.Location.Foreground = filePicker.ForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(filePicker.BackColor))
			{
				this.Location.Background = filePicker.BackColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(filePicker.BtnForeColor))
			{
				this.Choose.Foreground = filePicker.BtnForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(filePicker.BtnBackColor))
			{
				this.Choose.Background = filePicker.BtnBackColor.ToBrush();
			}
			this.Choose.Visibility = (this.Location.Visibility = StringExtensions.ToEnum<Visibility>(filePicker.Display.ToString(), Visibility.Visible));
			if (!string.IsNullOrEmpty(filePicker.Tooltip))
			{
				this.Choose.ToolTip = filePicker.Tooltip;
			}
		}
	}
}

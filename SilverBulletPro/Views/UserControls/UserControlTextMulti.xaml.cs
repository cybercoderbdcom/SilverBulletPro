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
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.Plugins;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000045 RID: 69
	public partial class UserControlTextMulti : UserControl, IControl
	{
		// Token: 0x0600032F RID: 815 RVA: 0x0001391C File Offset: 0x00011B1C
		public UserControlTextMulti(string[] defaultValue, TextMulti textMulti, ViewModelBase viewModel = null, EventObject[] events = null)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.SetProperties(textMulti);
			this.SetValue(defaultValue);
			this.viewModel = viewModel;
			if (viewModel != null)
			{
				viewModel.PropertyChanged += this.ViewModel_PropertyChanged;
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0001395B File Offset: 0x00011B5B
		private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.SetValue(this.viewModel.GetType().GetProperty(e.PropertyName).GetValue(this.viewModel));
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00013984 File Offset: 0x00011B84
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.valueTextbox.Text.Split(new string[]
			{
				"\r\n",
				"\n"
			}, StringSplitOptions.None);
		}

		// Token: 0x06000332 RID: 818 RVA: 0x000139B0 File Offset: 0x00011BB0
		public void SetValue(dynamic value)
		{
			if (UserControlTextMulti.<>o__4.<>p__0 == null)
			{
				UserControlTextMulti.<>o__4.<>p__0 = CallSite<Func<CallSite, object, string[]>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string[]), typeof(UserControlTextMulti)));
			}
			string[] value2 = UserControlTextMulti.<>o__4.<>p__0.Target(UserControlTextMulti.<>o__4.<>p__0, value);
			this.valueTextbox.Text = string.Join(Environment.NewLine, value2);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00013A18 File Offset: 0x00011C18
		private void SetProperties(TextMulti textMulti)
		{
			if (!string.IsNullOrWhiteSpace(textMulti.ForeColor))
			{
				this.valueTextbox.Foreground = textMulti.ForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(textMulti.BackColor))
			{
				this.valueTextbox.Background = textMulti.BackColor.ToBrush();
			}
			this.valueTextbox.Visibility = StringExtensions.ToEnum<Visibility>(textMulti.Display.ToString(), Visibility.Visible);
			this.valueTextbox.IsReadOnly = textMulti.ReadOnly;
			if (!string.IsNullOrEmpty(textMulti.Tooltip))
			{
				this.valueTextbox.ToolTip = textMulti.Tooltip;
			}
		}

		// Token: 0x04000193 RID: 403
		private ViewModelBase viewModel;
	}
}

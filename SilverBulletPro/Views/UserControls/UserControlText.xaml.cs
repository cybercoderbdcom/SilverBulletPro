using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using AngleSharp.Text;
using HandyControl.Controls;
using Microsoft.CSharp.RuntimeBinder;
using PluginFrameworkPro.Attributes;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Extensions;
using SilverBulletPro.Plugins;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000044 RID: 68
	public partial class UserControlText : UserControl, IControl
	{
		// Token: 0x06000327 RID: 807 RVA: 0x000136A4 File Offset: 0x000118A4
		public UserControlText(string defaultValue, Text text, ViewModelBase viewModel = null, EventObject[] events = null)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.events = events;
			this.SetValue(defaultValue);
			this.SetProperties(text);
			this.viewModel = viewModel;
			if (viewModel != null)
			{
				viewModel.PropertyChanged += this.ViewModel_PropertyChanged;
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000136F6 File Offset: 0x000118F6
		private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.SetValue(this.viewModel.GetType().GetProperty(e.PropertyName).GetValue(this.viewModel));
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0001371F File Offset: 0x0001191F
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.valueTextBox.Text;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0001372C File Offset: 0x0001192C
		public void SetValue(dynamic value)
		{
			TextBox textBox = this.valueTextBox;
			if (UserControlText.<>o__5.<>p__0 == null)
			{
				UserControlText.<>o__5.<>p__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(UserControlText)));
			}
			textBox.Text = UserControlText.<>o__5.<>p__0.Target(UserControlText.<>o__5.<>p__0, value);
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00013788 File Offset: 0x00011988
		private void SetProperties(Text text)
		{
			if (!string.IsNullOrWhiteSpace(text.InputFieldForeColor))
			{
				this.valueTextBox.Foreground = text.InputFieldForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(text.InputFieldBackColor))
			{
				this.valueTextBox.Background = text.InputFieldBackColor.ToBrush();
			}
			if (!string.IsNullOrEmpty(text.Placeholder))
			{
				InfoElement.SetPlaceholder(this.valueTextBox, text.Placeholder);
			}
			this.valueTextBox.Visibility = StringExtensions.ToEnum<Visibility>(text.Display.ToString(), Visibility.Visible);
			this.valueTextBox.IsReadOnly = text.ReadOnly;
			if (!string.IsNullOrEmpty(text.Tooltip))
			{
				this.valueTextBox.ToolTip = text.Tooltip;
			}
			Build.SetEvents(this.events, delegate(HandleEvent e)
			{
				object result = null;
				if (!string.IsNullOrEmpty(e.ControlName))
				{
					try
					{
						return this.valueTextBox.FindName(e.ControlName);
					}
					catch
					{
						return result;
					}
				}
				this.valueTextBox.GetType().GetEvent(e.EventName);
				result = this.valueTextBox;
				return result;
			}, "Text");
		}

		// Token: 0x0400018F RID: 399
		private ViewModelBase viewModel;

		// Token: 0x04000190 RID: 400
		private EventObject[] events;
	}
}

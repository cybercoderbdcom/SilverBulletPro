using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
	// Token: 0x02000040 RID: 64
	public partial class UserControlDropdown : UserControl, IControl
	{
		// Token: 0x06000300 RID: 768 RVA: 0x00012CD0 File Offset: 0x00010ED0
		public UserControlDropdown(string value, DropDown dropDown, ViewModelBase viewModel = null, EventObject[] events = null)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.events = events;
			foreach (string newItem in dropDown.Options)
			{
				this.valueDropdown.Items.Add(newItem);
			}
			this.SetProperties(dropDown);
			this.SetValue(value);
			this.viewModel = viewModel;
			if (viewModel != null)
			{
				viewModel.PropertyChanged += this.ViewModel_PropertyChanged;
			}
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00012D4D File Offset: 0x00010F4D
		private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.SetValue(this.viewModel.GetType().GetProperty(e.PropertyName).GetValue(this.viewModel));
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00012D76 File Offset: 0x00010F76
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.valueDropdown.SelectedValue;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00012D84 File Offset: 0x00010F84
		public void SetValue(dynamic value)
		{
			Selector selector = this.valueDropdown;
			if (UserControlDropdown.<>o__5.<>p__0 == null)
			{
				UserControlDropdown.<>o__5.<>p__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(UserControlDropdown)));
			}
			selector.SelectedValue = UserControlDropdown.<>o__5.<>p__0.Target(UserControlDropdown.<>o__5.<>p__0, value);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00012DE0 File Offset: 0x00010FE0
		private void SetProperties(DropDown dropDown)
		{
			if (!string.IsNullOrWhiteSpace(dropDown.ForeColor))
			{
				this.valueDropdown.Foreground = dropDown.ForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(dropDown.BackColor))
			{
				this.valueDropdown.Background = dropDown.BackColor.ToBrush();
			}
			this.valueDropdown.Visibility = StringExtensions.ToEnum<Visibility>(dropDown.Display.ToString(), Visibility.Visible);
			this.valueDropdown.IsEditable = dropDown.IsEditable;
			if (!string.IsNullOrEmpty(dropDown.Tooltip))
			{
				this.valueDropdown.ToolTip = dropDown.Tooltip;
			}
			Build.SetEvents(this.events, delegate(HandleEvent e)
			{
				object result = null;
				if (!string.IsNullOrEmpty(e.ControlName))
				{
					try
					{
						return base.FindName(e.ControlName);
					}
					catch
					{
						return result;
					}
				}
				this.valueDropdown.GetType().GetEvent(e.EventName);
				result = this.valueDropdown;
				return result;
			}, "Dropdown");
		}

		// Token: 0x0400017C RID: 380
		private ViewModelBase viewModel;

		// Token: 0x0400017D RID: 381
		private EventObject[] events;
	}
}

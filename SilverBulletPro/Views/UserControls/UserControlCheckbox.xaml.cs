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
	// Token: 0x0200003D RID: 61
	public partial class UserControlCheckbox : UserControl, IControl
	{
		// Token: 0x060002E2 RID: 738 RVA: 0x000125C4 File Offset: 0x000107C4
		public UserControlCheckbox(bool defaultValue, CheckBox checkBox, ViewModelBase viewModel = null, EventObject[] events = null)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.events = events;
			this.SetProperties(checkBox);
			this.SetValue(defaultValue);
			this.viewModel = viewModel;
			if (viewModel != null)
			{
				viewModel.PropertyChanged += this.ViewModel_PropertyChanged;
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0001261B File Offset: 0x0001081B
		private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.SetValue(this.viewModel.GetType().GetProperty(e.PropertyName).GetValue(this.viewModel));
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00012644 File Offset: 0x00010844
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.valueCheckbox.IsChecked.Value;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0001266C File Offset: 0x0001086C
		public void SetValue(dynamic value)
		{
			ToggleButton toggleButton = this.valueCheckbox;
			if (UserControlCheckbox.<>o__5.<>p__0 == null)
			{
				UserControlCheckbox.<>o__5.<>p__0 = CallSite<Func<CallSite, object, bool>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(bool), typeof(UserControlCheckbox)));
			}
			toggleButton.IsChecked = new bool?(UserControlCheckbox.<>o__5.<>p__0.Target(UserControlCheckbox.<>o__5.<>p__0, value));
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000126CC File Offset: 0x000108CC
		private void SetProperties(CheckBox checkBox)
		{
			if (!string.IsNullOrWhiteSpace(checkBox.ForeColor))
			{
				this.valueCheckbox.Foreground = checkBox.ForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(checkBox.BackColor))
			{
				this.valueCheckbox.Background = checkBox.BackColor.ToBrush();
			}
			this.valueCheckbox.Visibility = StringExtensions.ToEnum<Visibility>(checkBox.Display.ToString(), Visibility.Visible);
			if (!string.IsNullOrEmpty(checkBox.Tooltip))
			{
				this.valueCheckbox.ToolTip = checkBox.Tooltip;
			}
			Build.SetEvents(this.events, delegate(HandleEvent e)
			{
				object result = null;
				if (!string.IsNullOrEmpty(e.ControlName))
				{
					try
					{
						return this.valueCheckbox.FindName(e.ControlName);
					}
					catch
					{
						return result;
					}
				}
				this.valueCheckbox.GetType().GetEvent(e.EventName);
				result = this.valueCheckbox;
				return result;
			}, "CheckBox");
		}

		// Token: 0x0400016C RID: 364
		private ViewModelBase viewModel;

		// Token: 0x0400016D RID: 365
		private EventObject[] events;
	}
}

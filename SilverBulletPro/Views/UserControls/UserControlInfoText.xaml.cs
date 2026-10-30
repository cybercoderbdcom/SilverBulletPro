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
	// Token: 0x02000042 RID: 66
	public partial class UserControlInfoText : UserControl, IControl
	{
		// Token: 0x06000311 RID: 785 RVA: 0x000131A8 File Offset: 0x000113A8
		public UserControlInfoText(string defaultValue, InfoText infoText, ViewModelBase viewModel = null, EventObject[] events = null)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.events = events;
			this.SetValue(defaultValue);
			this.SetProperties(infoText);
			this.vm = viewModel;
			if (viewModel != null)
			{
				viewModel.PropertyChanged += this.ViewModel_PropertyChanged;
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x000131FA File Offset: 0x000113FA
		private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.SetValue(this.vm.GetType().GetProperty(e.PropertyName).GetValue(this.vm));
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00013223 File Offset: 0x00011423
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.valueLabel.Content;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00013230 File Offset: 0x00011430
		public void SetValue(dynamic value)
		{
			ContentControl contentControl = this.valueLabel;
			if (UserControlInfoText.<>o__5.<>p__0 == null)
			{
				UserControlInfoText.<>o__5.<>p__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(UserControlInfoText)));
			}
			contentControl.Content = UserControlInfoText.<>o__5.<>p__0.Target(UserControlInfoText.<>o__5.<>p__0, value);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0001328C File Offset: 0x0001148C
		private void SetProperties(InfoText infoText)
		{
			if (!string.IsNullOrWhiteSpace(infoText.ForeColor))
			{
				this.valueLabel.Foreground = infoText.ForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(infoText.BackColor))
			{
				this.valueLabel.Background = infoText.BackColor.ToBrush();
			}
			this.valueLabel.Visibility = StringExtensions.ToEnum<Visibility>(infoText.Display.ToString(), Visibility.Visible);
			if (!string.IsNullOrEmpty(infoText.Tooltip))
			{
				this.valueLabel.ToolTip = infoText.Tooltip;
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
				this.valueLabel.GetType().GetEvent(e.EventName);
				result = this.valueLabel;
				return result;
			}, "InfoText");
		}

		// Token: 0x04000184 RID: 388
		private ViewModelBase vm;

		// Token: 0x04000185 RID: 389
		private EventObject[] events;
	}
}

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
	// Token: 0x02000043 RID: 67
	public partial class UserControlNumericPlug : UserControl, IControl
	{
		// Token: 0x06000319 RID: 793 RVA: 0x000133EC File Offset: 0x000115EC
		public UserControlNumericPlug(int defaultValue, Numeric numeric, ViewModelBase viewModel = null, EventObject[] events = null)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.events = events;
			this.SetProperties(numeric);
			this.SetValue(defaultValue);
			this.viewModel = viewModel;
			if (viewModel != null)
			{
				viewModel.PropertyChanged += this.ViewModel_PropertyChanged;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600031A RID: 794 RVA: 0x00013443 File Offset: 0x00011643
		// (set) Token: 0x0600031B RID: 795 RVA: 0x0001344B File Offset: 0x0001164B
		public double Minimum { get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600031C RID: 796 RVA: 0x00013454 File Offset: 0x00011654
		// (set) Token: 0x0600031D RID: 797 RVA: 0x0001345C File Offset: 0x0001165C
		public double Maximum { get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00013465 File Offset: 0x00011665
		// (set) Token: 0x0600031F RID: 799 RVA: 0x0001346D File Offset: 0x0001166D
		public TextAlignment TextAlignment { get; set; }

		// Token: 0x06000320 RID: 800 RVA: 0x00013476 File Offset: 0x00011676
		private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.SetValue(this.viewModel.GetType().GetProperty(e.PropertyName).GetValue(this.viewModel));
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0001349F File Offset: 0x0001169F
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.valueNumeric.Value;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000134B4 File Offset: 0x000116B4
		public void SetValue(dynamic value)
		{
			NumericUpDown numericUpDown = this.valueNumeric;
			if (UserControlNumericPlug.<>o__17.<>p__0 == null)
			{
				UserControlNumericPlug.<>o__17.<>p__0 = CallSite<Func<CallSite, object, double>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(double), typeof(UserControlNumericPlug)));
			}
			numericUpDown.Value = UserControlNumericPlug.<>o__17.<>p__0.Target(UserControlNumericPlug.<>o__17.<>p__0, value);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00013510 File Offset: 0x00011710
		private void SetProperties(Numeric numeric)
		{
			this.Minimum = numeric.Minimum;
			this.Maximum = numeric.Maximum;
			this.TextAlignment = StringExtensions.ToEnum<TextAlignment>(numeric.Alignment.ToString(), TextAlignment.Left);
			if (!string.IsNullOrWhiteSpace(numeric.NumericForeColor))
			{
				this.valueNumeric.Foreground = numeric.NumericForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(numeric.NumericBackColor))
			{
				this.valueNumeric.Background = numeric.NumericBackColor.ToBrush();
			}
			this.valueNumeric.Visibility = StringExtensions.ToEnum<Visibility>(numeric.Display.ToString(), Visibility.Visible);
			if (!string.IsNullOrEmpty(numeric.Tooltip))
			{
				this.valueNumeric.ToolTip = numeric.Tooltip;
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
				this.valueNumeric.GetType().GetEvent(e.EventName);
				result = this.valueNumeric;
				return result;
			}, "Numeric");
		}

		// Token: 0x04000188 RID: 392
		private EventObject[] events;

		// Token: 0x04000189 RID: 393
		private ViewModelBase viewModel;
	}
}

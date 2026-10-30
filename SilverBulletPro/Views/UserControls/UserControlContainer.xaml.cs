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
using SilverBulletPro.Extensions;
using SilverBulletPro.Plugins;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x0200003F RID: 63
	public partial class UserControlContainer : UserControl, IControl
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x00012A5B File Offset: 0x00010C5B
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x00012A63 File Offset: 0x00010C63
		public string PropertyName { get; set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x00012A6C File Offset: 0x00010C6C
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x00012A74 File Offset: 0x00010C74
		public IControl UserControl { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x00012A7D File Offset: 0x00010C7D
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x00012A85 File Offset: 0x00010C85
		public string Label { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00012A8E File Offset: 0x00010C8E
		// (set) Token: 0x060002FA RID: 762 RVA: 0x00012A96 File Offset: 0x00010C96
		public string Tooltip { get; set; }

		// Token: 0x060002FB RID: 763 RVA: 0x00012AA0 File Offset: 0x00010CA0
		public UserControlContainer(string propertyName, IControl userControl, InputField inputField)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.PropertyName = propertyName;
			this.UserControl = userControl;
			(this.UserControl as UserControl).SetValue(Grid.ColumnProperty, 1);
			this.Grid.Children.Add(this.UserControl as UserControl);
			this.Label = inputField.Label;
			this.labelControl.VerticalAlignment = StringExtensions.ToEnum<VerticalAlignment>(inputField.LabelVerticalAlignment.ToString(), VerticalAlignment.Center);
			if (!string.IsNullOrEmpty(inputField.Tooltip))
			{
				this.Tooltip = inputField.Tooltip;
				this.tooltipTextBlock.Visibility = Visibility.Visible;
			}
			else
			{
				this.tooltipTextBlock.Visibility = Visibility.Collapsed;
			}
			if (!string.IsNullOrWhiteSpace(inputField.ForeColor))
			{
				this.labelControl.Foreground = inputField.ForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(inputField.BackColor))
			{
				this.labelControl.Background = inputField.BackColor.ToBrush();
			}
			this.labelControl.Visibility = StringExtensions.ToEnum<Visibility>(inputField.LabelDisplay.ToString(), Visibility.Visible);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00012BCE File Offset: 0x00010DCE
		[return: Dynamic]
		public dynamic GetValue()
		{
			return this.UserControl.GetValue();
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00012BDC File Offset: 0x00010DDC
		public void SetValue(dynamic value)
		{
			if (UserControlContainer.<>o__18.<>p__0 == null)
			{
				UserControlContainer.<>o__18.<>p__0 = CallSite<Action<CallSite, IControl, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetValue", null, typeof(UserControlContainer), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			UserControlContainer.<>o__18.<>p__0.Target(UserControlContainer.<>o__18.<>p__0, this.UserControl, value);
		}
	}
}

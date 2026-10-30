using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using AngleSharp.Text;
using PluginFrameworkPro.Attributes;
using SilverBulletPro.Extensions;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x02000034 RID: 52
	public partial class ButtonContainer : UserControl
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x0000DF04 File Offset: 0x0000C104
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x0000DF0C File Offset: 0x0000C10C
		public string Text { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0000DF15 File Offset: 0x0000C115
		// (set) Token: 0x060001DB RID: 475 RVA: 0x0000DF1D File Offset: 0x0000C11D
		private string MethodName { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0000DF26 File Offset: 0x0000C126
		// (set) Token: 0x060001DD RID: 477 RVA: 0x0000DF2E File Offset: 0x0000C12E
		private PluginControl PluginControl { get; set; }

		// Token: 0x060001DE RID: 478 RVA: 0x0000DF37 File Offset: 0x0000C137
		public ButtonContainer(Button btn, string methodName, PluginControl pluginControl)
		{
			this.InitializeComponent();
			base.DataContext = this;
			this.Text = btn.Text;
			this.SetProperties(btn);
			this.MethodName = methodName;
			this.PluginControl = pluginControl;
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000DF6D File Offset: 0x0000C16D
		private void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			this.PluginControl.RunMethod(this.MethodName);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000DF80 File Offset: 0x0000C180
		private void SetProperties(Button btn)
		{
			if (!string.IsNullOrWhiteSpace(btn.ForeColor))
			{
				this.SubmitButton.Foreground = btn.ForeColor.ToBrush();
			}
			if (!string.IsNullOrWhiteSpace(btn.BackColor))
			{
				this.SubmitButton.Background = btn.BackColor.ToBrush();
			}
			this.SubmitButton.Visibility = StringExtensions.ToEnum<Visibility>(btn.Display.ToString(), Visibility.Visible);
			this.SubmitButton.IsEnabled = btn.IsEnabled;
		}
	}
}

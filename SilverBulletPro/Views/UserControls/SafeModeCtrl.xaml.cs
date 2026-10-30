using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SilverBulletPro.Views.UserControls
{
	// Token: 0x0200003B RID: 59
	public partial class SafeModeCtrl : UserControl
	{
		// Token: 0x060002B2 RID: 690 RVA: 0x00011E2E File Offset: 0x0001002E
		public SafeModeCtrl()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00011E3C File Offset: 0x0001003C
		// (set) Token: 0x060002B4 RID: 692 RVA: 0x00011E4E File Offset: 0x0001004E
		public bool SafeMode
		{
			get
			{
				return (bool)base.GetValue(SafeModeCtrl.SafeModeProperty);
			}
			set
			{
				base.SetValue(SafeModeCtrl.SafeModeProperty, value);
			}
		}

		// Token: 0x04000157 RID: 343
		public static readonly DependencyProperty SafeModeProperty = DependencyProperty.Register("SafeMode", typeof(bool), typeof(SafeModeCtrl), new PropertyMetadata(false));
	}
}

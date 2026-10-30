using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SilverBulletPro.Views.Main.Settings.Core
{
	// Token: 0x02000193 RID: 403
	public partial class Compile : Page
	{
		// Token: 0x06000A2D RID: 2605 RVA: 0x0002FD08 File Offset: 0x0002DF08
		public Compile()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.Settings.CoreSettings.Compiler;
		}
	}
}

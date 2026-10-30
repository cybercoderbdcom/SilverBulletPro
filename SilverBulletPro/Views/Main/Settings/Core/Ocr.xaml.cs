using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SilverBulletPro.Views.Main.Settings.Core
{
	// Token: 0x02000195 RID: 405
	public partial class Ocr : Page
	{
		// Token: 0x06000A35 RID: 2613 RVA: 0x0002FF2C File Offset: 0x0002E12C
		public Ocr()
		{
			this.InitializeComponent();
			base.DataContext = (base.DataContext = GlobalData.Settings.CoreSettings.Ocr);
		}
	}
}

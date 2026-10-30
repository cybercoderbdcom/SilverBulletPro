using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SilverBulletPro.Views.Main.Settings.Core
{
	// Token: 0x02000197 RID: 407
	public partial class Puppeteer : Page
	{
		// Token: 0x06000A3F RID: 2623 RVA: 0x000302D4 File Offset: 0x0002E4D4
		public Puppeteer()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.Settings.CoreSettings.Puppeteer;
		}
	}
}

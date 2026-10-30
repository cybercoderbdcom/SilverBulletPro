using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Enums;

namespace SilverBulletPro.Views.Main.Settings.Core
{
	// Token: 0x02000198 RID: 408
	public partial class Selenium : Page
	{
		// Token: 0x06000A42 RID: 2626 RVA: 0x00030334 File Offset: 0x0002E534
		public Selenium()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.Settings.CoreSettings.Selenium;
			foreach (object newItem in Enum.GetValues(typeof(SeleniumBrowserType)))
			{
				this.browserType.Items.Add(newItem);
			}
		}
	}
}

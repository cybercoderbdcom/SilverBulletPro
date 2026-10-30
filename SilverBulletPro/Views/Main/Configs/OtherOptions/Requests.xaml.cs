using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace SilverBulletPro.Views.Main.Configs.OtherOptions
{
	// Token: 0x020001A6 RID: 422
	public partial class Requests : Page
	{
		// Token: 0x06000BCF RID: 3023 RVA: 0x00040009 File Offset: 0x0003E209
		public Requests()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.ConfigManager.CurrentConfig.Config.Settings;
		}
	}
}

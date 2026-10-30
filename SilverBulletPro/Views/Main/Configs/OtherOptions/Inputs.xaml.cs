using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core;
using SilverBulletPro.Core.ViewModels;

namespace SilverBulletPro.Views.Main.Configs.OtherOptions
{
	// Token: 0x020001A0 RID: 416
	public partial class Inputs : Page, IStyleConnector
	{
		// Token: 0x06000B9A RID: 2970 RVA: 0x0003E60E File Offset: 0x0003C80E
		public Inputs()
		{
			this.vm = GlobalData.ConfigManager.CurrentConfig.Config.Settings;
			base.DataContext = this.vm;
			this.InitializeComponent();
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x0003E64D File Offset: 0x0003C84D
		private void clearInputsButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.CustomInputs.Clear();
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0003E65F File Offset: 0x0003C85F
		private void addInputButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.CustomInputs.Add(new CustomInput(this.rand.Next()));
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x0003E681 File Offset: 0x0003C881
		private void removeInputButton_Click(object sender, RoutedEventArgs e)
		{
			this.vm.RemoveCustomInputById((int)(sender as Button).Tag);
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0003E737 File Offset: 0x0003C937
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 4)
			{
				((Button)target).Click += this.removeInputButton_Click;
			}
		}

		// Token: 0x040005C1 RID: 1473
		private ConfigSettings vm;

		// Token: 0x040005C2 RID: 1474
		private Random rand = new Random();
	}
}

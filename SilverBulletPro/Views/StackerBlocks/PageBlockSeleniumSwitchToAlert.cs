using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000147 RID: 327
	public class PageBlockSeleniumSwitchToAlert : Page, IComponentConnector
	{
		// Token: 0x060007B2 RID: 1970 RVA: 0x00021EF6 File Offset: 0x000200F6
		public PageBlockSeleniumSwitchToAlert(BlockSeleniumSwitchToAlert block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00021F0C File Offset: 0x0002010C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumswitchtoalert.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00021F3C File Offset: 0x0002013C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00021F46 File Offset: 0x00020146
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000392 RID: 914
		private bool _contentLoaded;
	}
}

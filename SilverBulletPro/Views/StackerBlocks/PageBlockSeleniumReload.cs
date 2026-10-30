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
	// Token: 0x0200011D RID: 285
	public class PageBlockSeleniumReload : Page, IComponentConnector
	{
		// Token: 0x06000708 RID: 1800 RVA: 0x00020233 File Offset: 0x0001E433
		public PageBlockSeleniumReload(BlockSeleniumReload block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x00020248 File Offset: 0x0001E448
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumreload.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00020278 File Offset: 0x0001E478
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00020282 File Offset: 0x0001E482
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400034D RID: 845
		private bool _contentLoaded;
	}
}

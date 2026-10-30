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
	// Token: 0x0200011E RID: 286
	public class PageBlockSeleniumSetBrowserSize : Page, IComponentConnector
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x0002028B File Offset: 0x0001E48B
		public PageBlockSeleniumSetBrowserSize(BlockSeleniumSetBrowserSize block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x000202A0 File Offset: 0x0001E4A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumsetbrowsersize.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000202D0 File Offset: 0x0001E4D0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x000202DA File Offset: 0x0001E4DA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400034E RID: 846
		private bool _contentLoaded;
	}
}

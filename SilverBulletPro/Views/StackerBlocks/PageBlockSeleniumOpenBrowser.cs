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
	// Token: 0x0200011C RID: 284
	public class PageBlockSeleniumOpenBrowser : Page, IComponentConnector
	{
		// Token: 0x06000704 RID: 1796 RVA: 0x000201DB File Offset: 0x0001E3DB
		public PageBlockSeleniumOpenBrowser(BlockSeleniumOpenBrowser block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x000201F0 File Offset: 0x0001E3F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumopenbrowser.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00020220 File Offset: 0x0001E420
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0002022A File Offset: 0x0001E42A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400034C RID: 844
		private bool _contentLoaded;
	}
}

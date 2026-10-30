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
	// Token: 0x02000116 RID: 278
	public class PageBlockSeleniumFullScreen : Page, IComponentConnector
	{
		// Token: 0x060006EC RID: 1772 RVA: 0x0001FFCB File Offset: 0x0001E1CB
		public PageBlockSeleniumFullScreen(BlockSeleniumFullScreen block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0001FFE0 File Offset: 0x0001E1E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumfullscreen.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00020010 File Offset: 0x0001E210
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0002001A File Offset: 0x0001E21A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000346 RID: 838
		private bool _contentLoaded;
	}
}

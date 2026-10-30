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
	// Token: 0x02000114 RID: 276
	public class PageBlockSeleniumCloseBrowser : Page, IComponentConnector
	{
		// Token: 0x060006E4 RID: 1764 RVA: 0x0001FF1B File Offset: 0x0001E11B
		public PageBlockSeleniumCloseBrowser(BlockSeleniumCloseBrowser block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0001FF30 File Offset: 0x0001E130
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumclosebrowser.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0001FF60 File Offset: 0x0001E160
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0001FF6A File Offset: 0x0001E16A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000344 RID: 836
		private bool _contentLoaded;
	}
}

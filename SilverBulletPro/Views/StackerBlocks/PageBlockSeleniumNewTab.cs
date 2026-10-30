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
	// Token: 0x0200011B RID: 283
	public class PageBlockSeleniumNewTab : Page, IComponentConnector
	{
		// Token: 0x06000700 RID: 1792 RVA: 0x00020183 File Offset: 0x0001E383
		public PageBlockSeleniumNewTab(BlockSeleniumNewTab block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00020198 File Offset: 0x0001E398
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumnewtab.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x000201C8 File Offset: 0x0001E3C8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x000201D2 File Offset: 0x0001E3D2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400034B RID: 843
		private bool _contentLoaded;
	}
}

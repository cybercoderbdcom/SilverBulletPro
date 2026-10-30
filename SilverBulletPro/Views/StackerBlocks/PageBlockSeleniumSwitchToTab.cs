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
	// Token: 0x0200011F RID: 287
	public class PageBlockSeleniumSwitchToTab : Page, IComponentConnector
	{
		// Token: 0x06000710 RID: 1808 RVA: 0x000202E3 File Offset: 0x0001E4E3
		public PageBlockSeleniumSwitchToTab(BlockSeleniumSwitchToTab block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x000202F8 File Offset: 0x0001E4F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumswitchtotab.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00020328 File Offset: 0x0001E528
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00020332 File Offset: 0x0001E532
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400034F RID: 847
		private bool _contentLoaded;
	}
}

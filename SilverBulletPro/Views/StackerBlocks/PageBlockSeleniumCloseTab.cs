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
	// Token: 0x02000115 RID: 277
	public class PageBlockSeleniumCloseTab : Page, IComponentConnector
	{
		// Token: 0x060006E8 RID: 1768 RVA: 0x0001FF73 File Offset: 0x0001E173
		public PageBlockSeleniumCloseTab(BlockSeleniumCloseTab block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0001FF88 File Offset: 0x0001E188
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumclosetab.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0001FFB8 File Offset: 0x0001E1B8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0001FFC2 File Offset: 0x0001E1C2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000345 RID: 837
		private bool _contentLoaded;
	}
}

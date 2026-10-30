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
	// Token: 0x02000119 RID: 281
	public class PageBlockSeleniumMaximize : Page, IComponentConnector
	{
		// Token: 0x060006F8 RID: 1784 RVA: 0x000200D3 File Offset: 0x0001E2D3
		public PageBlockSeleniumMaximize(BlockSeleniumMaximize block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x000200E8 File Offset: 0x0001E2E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniummaximize.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00020118 File Offset: 0x0001E318
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00020122 File Offset: 0x0001E322
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000349 RID: 841
		private bool _contentLoaded;
	}
}

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
	// Token: 0x02000118 RID: 280
	public class PageBlockSeleniumGoForward : Page, IComponentConnector
	{
		// Token: 0x060006F4 RID: 1780 RVA: 0x0002007B File Offset: 0x0001E27B
		public PageBlockSeleniumGoForward(BlockSeleniumGoForward block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00020090 File Offset: 0x0001E290
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumgoforward.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x000200C0 File Offset: 0x0001E2C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x000200CA File Offset: 0x0001E2CA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000348 RID: 840
		private bool _contentLoaded;
	}
}

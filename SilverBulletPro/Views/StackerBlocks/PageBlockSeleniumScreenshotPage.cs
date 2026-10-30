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
	// Token: 0x02000143 RID: 323
	public class PageBlockSeleniumScreenshotPage : Page, IComponentConnector
	{
		// Token: 0x060007A0 RID: 1952 RVA: 0x00021CB7 File Offset: 0x0001FEB7
		public PageBlockSeleniumScreenshotPage(BlockSeleniumScreenshotPage block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00021CCC File Offset: 0x0001FECC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumscreenshotpage.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x00021CFC File Offset: 0x0001FEFC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00021D06 File Offset: 0x0001FF06
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400038D RID: 909
		private bool _contentLoaded;
	}
}

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
	// Token: 0x02000144 RID: 324
	public class PageBlockSeleniumScreenshotPageBase64 : Page, IComponentConnector
	{
		// Token: 0x060007A4 RID: 1956 RVA: 0x00021D0F File Offset: 0x0001FF0F
		public PageBlockSeleniumScreenshotPageBase64(BlockSeleniumScreenshotPageBase64 block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00021D24 File Offset: 0x0001FF24
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumscreenshotpagebase64.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x00021D54 File Offset: 0x0001FF54
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00021D5E File Offset: 0x0001FF5E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400038E RID: 910
		private bool _contentLoaded;
	}
}

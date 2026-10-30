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
	// Token: 0x0200013C RID: 316
	public class PageBlockSeleniumGetCookies : Page, IComponentConnector
	{
		// Token: 0x06000784 RID: 1924 RVA: 0x00021A4F File Offset: 0x0001FC4F
		public PageBlockSeleniumGetCookies(BlockSeleniumGetCookies block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00021A64 File Offset: 0x0001FC64
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumgetcookies.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x00021A94 File Offset: 0x0001FC94
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x00021A9E File Offset: 0x0001FC9E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000386 RID: 902
		private bool _contentLoaded;
	}
}

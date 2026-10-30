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
	// Token: 0x0200013A RID: 314
	public class PageBlockSeleniumClearCookies : Page, IComponentConnector
	{
		// Token: 0x0600077C RID: 1916 RVA: 0x0002199C File Offset: 0x0001FB9C
		public PageBlockSeleniumClearCookies(BlockSeleniumClearCookies block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x000219B4 File Offset: 0x0001FBB4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumclearcookies.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x000219E4 File Offset: 0x0001FBE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x000219EE File Offset: 0x0001FBEE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000384 RID: 900
		private bool _contentLoaded;
	}
}

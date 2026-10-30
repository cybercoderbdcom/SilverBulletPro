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
	// Token: 0x0200011A RID: 282
	public class PageBlockSeleniumMinimize : Page, IComponentConnector
	{
		// Token: 0x060006FC RID: 1788 RVA: 0x0002012B File Offset: 0x0001E32B
		public PageBlockSeleniumMinimize(BlockSeleniumMinimize block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00020140 File Offset: 0x0001E340
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/browser/pageblockseleniumminimize.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00020170 File Offset: 0x0001E370
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0002017A File Offset: 0x0001E37A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400034A RID: 842
		private bool _contentLoaded;
	}
}

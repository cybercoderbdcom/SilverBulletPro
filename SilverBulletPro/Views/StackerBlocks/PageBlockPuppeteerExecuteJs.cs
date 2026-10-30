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
	// Token: 0x020000C5 RID: 197
	public class PageBlockPuppeteerExecuteJs : Page, IComponentConnector
	{
		// Token: 0x0600058B RID: 1419 RVA: 0x0001BB54 File Offset: 0x00019D54
		public PageBlockPuppeteerExecuteJs(BlockPuppeteerExecuteJs block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0001BB6C File Offset: 0x00019D6C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerexecutejs.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0001BB9C File Offset: 0x00019D9C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0001BBA6 File Offset: 0x00019DA6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002A6 RID: 678
		private bool _contentLoaded;
	}
}

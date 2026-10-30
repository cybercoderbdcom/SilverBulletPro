using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000C4 RID: 196
	public class PageBlockPuppeteerExecuteFunc : Page, IComponentConnector
	{
		// Token: 0x06000587 RID: 1415 RVA: 0x0001BAD7 File Offset: 0x00019CD7
		public PageBlockPuppeteerExecuteFunc(BlockPuppeteerExecuteFunc block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtArgs.AddItems(block.Arguments);
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x0001BB00 File Offset: 0x00019D00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/puppeteer/page/pageblockpuppeteerexecutefunc.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0001BB30 File Offset: 0x00019D30
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0001BB3A File Offset: 0x00019D3A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.rtArgs = (RichTextInputBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040002A4 RID: 676
		internal RichTextInputBox rtArgs;

		// Token: 0x040002A5 RID: 677
		private bool _contentLoaded;
	}
}

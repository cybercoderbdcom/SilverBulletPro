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
	// Token: 0x0200014E RID: 334
	public class PageBlockSolveGeeTestCaptcha : Page, IComponentConnector
	{
		// Token: 0x060007EF RID: 2031 RVA: 0x0002389F File Offset: 0x00021A9F
		public PageBlockSolveGeeTestCaptcha(BlockSolveGeeTestCaptcha block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x000238B4 File Offset: 0x00021AB4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblocksolvegeetestcaptcha.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x000238E4 File Offset: 0x00021AE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x000238EE File Offset: 0x00021AEE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003B2 RID: 946
		private bool _contentLoaded;
	}
}

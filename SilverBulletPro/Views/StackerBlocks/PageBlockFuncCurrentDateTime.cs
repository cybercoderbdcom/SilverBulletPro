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
	// Token: 0x0200009A RID: 154
	public class PageBlockFuncCurrentDateTime : Page, IComponentConnector
	{
		// Token: 0x060004C1 RID: 1217 RVA: 0x0001864B File Offset: 0x0001684B
		public PageBlockFuncCurrentDateTime(BlockCurrentDateTime block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00018660 File Offset: 0x00016860
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/time/pageblockfunccurrentdatetime.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00018690 File Offset: 0x00016890
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0001869A File Offset: 0x0001689A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400024C RID: 588
		private bool _contentLoaded;
	}
}

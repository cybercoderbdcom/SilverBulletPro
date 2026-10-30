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
	// Token: 0x0200005F RID: 95
	public class PageBlockFuncXor : Page, IComponentConnector
	{
		// Token: 0x060003CE RID: 974 RVA: 0x00016478 File Offset: 0x00014678
		public PageBlockFuncXor(BlockXor block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00016490 File Offset: 0x00014690
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncxor.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x000164C0 File Offset: 0x000146C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x000164CA File Offset: 0x000146CA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.outputVar = (VarCapOutputBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040001EC RID: 492
		internal VarCapOutputBox outputVar;

		// Token: 0x040001ED RID: 493
		private bool _contentLoaded;
	}
}

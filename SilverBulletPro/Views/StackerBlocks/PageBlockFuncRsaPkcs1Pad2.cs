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
	// Token: 0x0200005D RID: 93
	public class PageBlockFuncRsaPkcs1Pad2 : Page, IComponentConnector
	{
		// Token: 0x060003C6 RID: 966 RVA: 0x00016352 File Offset: 0x00014552
		public PageBlockFuncRsaPkcs1Pad2(BlockRsaPkcs1Pad2 block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00016368 File Offset: 0x00014568
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncrsapkcs1pad2.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00016398 File Offset: 0x00014598
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x000163A4 File Offset: 0x000145A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.outputVar = (VarCapOutputBox)target;
				return;
			case 2:
				this.modulusControl = (TextInputBox)target;
				return;
			case 3:
				this.exponentControl = (TextInputBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040001E5 RID: 485
		internal VarCapOutputBox outputVar;

		// Token: 0x040001E6 RID: 486
		internal TextInputBox modulusControl;

		// Token: 0x040001E7 RID: 487
		internal TextInputBox exponentControl;

		// Token: 0x040001E8 RID: 488
		private bool _contentLoaded;
	}
}

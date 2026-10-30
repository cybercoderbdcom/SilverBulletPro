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
	// Token: 0x0200005E RID: 94
	public class PageBlockFuncScrypt : Page, IComponentConnector
	{
		// Token: 0x060003CA RID: 970 RVA: 0x000163F8 File Offset: 0x000145F8
		public PageBlockFuncScrypt(BlockScrypt block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00016424 File Offset: 0x00014624
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncscrypt.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00016454 File Offset: 0x00014654
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0001645E File Offset: 0x0001465E
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

		// Token: 0x040001E9 RID: 489
		private BlockScrypt vm;

		// Token: 0x040001EA RID: 490
		internal VarCapOutputBox outputVar;

		// Token: 0x040001EB RID: 491
		private bool _contentLoaded;
	}
}

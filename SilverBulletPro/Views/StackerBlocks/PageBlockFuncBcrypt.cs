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
	// Token: 0x02000052 RID: 82
	public class PageBlockFuncBcrypt : Page, IComponentConnector
	{
		// Token: 0x06000393 RID: 915 RVA: 0x000156E8 File Offset: 0x000138E8
		public PageBlockFuncBcrypt(BlockBcrypt block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00015700 File Offset: 0x00013900
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncbcrypt.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00015730 File Offset: 0x00013930
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0001573A File Offset: 0x0001393A
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

		// Token: 0x040001BA RID: 442
		internal VarCapOutputBox outputVar;

		// Token: 0x040001BB RID: 443
		private bool _contentLoaded;
	}
}

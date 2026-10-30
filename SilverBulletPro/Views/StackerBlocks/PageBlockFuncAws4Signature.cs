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
	// Token: 0x02000051 RID: 81
	public class PageBlockFuncAws4Signature : Page, IComponentConnector
	{
		// Token: 0x0600038F RID: 911 RVA: 0x0001567D File Offset: 0x0001387D
		public PageBlockFuncAws4Signature(BlockAws4Signature block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00015694 File Offset: 0x00013894
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncaws4signature.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x000156C4 File Offset: 0x000138C4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x000156CE File Offset: 0x000138CE
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

		// Token: 0x040001B8 RID: 440
		internal VarCapOutputBox outputVar;

		// Token: 0x040001B9 RID: 441
		private bool _contentLoaded;
	}
}

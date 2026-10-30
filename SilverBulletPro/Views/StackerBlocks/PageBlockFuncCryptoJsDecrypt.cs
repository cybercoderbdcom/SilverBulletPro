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
	// Token: 0x02000053 RID: 83
	public class PageBlockFuncCryptoJsDecrypt : Page, IComponentConnector
	{
		// Token: 0x06000397 RID: 919 RVA: 0x00015754 File Offset: 0x00013954
		public PageBlockFuncCryptoJsDecrypt(BlockCryptoJsDecrypt block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0001576C File Offset: 0x0001396C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfunccryptojsdecrypt.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0001579C File Offset: 0x0001399C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x000157A6 File Offset: 0x000139A6
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

		// Token: 0x040001BC RID: 444
		internal VarCapOutputBox outputVar;

		// Token: 0x040001BD RID: 445
		private bool _contentLoaded;
	}
}

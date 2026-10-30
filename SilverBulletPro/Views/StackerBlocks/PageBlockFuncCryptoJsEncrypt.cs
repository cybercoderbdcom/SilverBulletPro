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
	// Token: 0x02000054 RID: 84
	public class PageBlockFuncCryptoJsEncrypt : Page, IComponentConnector
	{
		// Token: 0x0600039B RID: 923 RVA: 0x000157C0 File Offset: 0x000139C0
		public PageBlockFuncCryptoJsEncrypt(BlockCryptoJsEncrypt block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x000157D8 File Offset: 0x000139D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfunccryptojsencrypt.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00015808 File Offset: 0x00013A08
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00015812 File Offset: 0x00013A12
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

		// Token: 0x040001BE RID: 446
		internal VarCapOutputBox outputVar;

		// Token: 0x040001BF RID: 447
		private bool _contentLoaded;
	}
}

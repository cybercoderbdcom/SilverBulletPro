using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x0200004F RID: 79
	public class PageBlockFuncAesDecrypt : Page, IComponentConnector
	{
		// Token: 0x06000387 RID: 903 RVA: 0x000153AC File Offset: 0x000135AC
		public PageBlockFuncAesDecrypt(BlockAesDecrypt block)
		{
			this.InitializeComponent();
			foreach (object newItem in Enum.GetValues(typeof(CipherMode)))
			{
				this.cipherModeBox.Items.Add(newItem);
			}
			foreach (object newItem2 in Enum.GetValues(typeof(PaddingMode)))
			{
				this.paddingModeBox.Items.Add(newItem2);
			}
			base.DataContext = block;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00015480 File Offset: 0x00013680
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncaesdecrypt.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x000154B0 File Offset: 0x000136B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x000154BC File Offset: 0x000136BC
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
				this.cipherModeBox = (ComboBox)target;
				return;
			case 3:
				this.paddingModeBox = (ComboBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040001AF RID: 431
		internal VarCapOutputBox outputVar;

		// Token: 0x040001B0 RID: 432
		internal ComboBox cipherModeBox;

		// Token: 0x040001B1 RID: 433
		internal ComboBox paddingModeBox;

		// Token: 0x040001B2 RID: 434
		private bool _contentLoaded;
	}
}

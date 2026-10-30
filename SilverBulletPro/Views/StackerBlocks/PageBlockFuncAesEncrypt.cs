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
	// Token: 0x02000050 RID: 80
	public class PageBlockFuncAesEncrypt : Page, IComponentConnector
	{
		// Token: 0x0600038B RID: 907 RVA: 0x00015510 File Offset: 0x00013710
		public PageBlockFuncAesEncrypt(BlockAesEncrypt block)
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
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x000155F0 File Offset: 0x000137F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncaesencrypt.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00015620 File Offset: 0x00013820
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0001562C File Offset: 0x0001382C
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

		// Token: 0x040001B3 RID: 435
		private BlockAesEncrypt vm;

		// Token: 0x040001B4 RID: 436
		internal VarCapOutputBox outputVar;

		// Token: 0x040001B5 RID: 437
		internal ComboBox cipherModeBox;

		// Token: 0x040001B6 RID: 438
		internal ComboBox paddingModeBox;

		// Token: 0x040001B7 RID: 439
		private bool _contentLoaded;
	}
}

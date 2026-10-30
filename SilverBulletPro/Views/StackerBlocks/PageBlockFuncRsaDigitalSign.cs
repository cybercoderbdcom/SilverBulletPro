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
	// Token: 0x0200005B RID: 91
	public class PageBlockFuncRsaDigitalSign : Page, IComponentConnector
	{
		// Token: 0x060003BD RID: 957 RVA: 0x000160C0 File Offset: 0x000142C0
		public PageBlockFuncRsaDigitalSign(BlockRsaDigitalSign block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object newItem in Enum.GetValues(typeof(BlockRsaDigitalSign.HashAlgorithm)))
			{
				this.hashAlgorithmBox.Items.Add(newItem);
			}
			block.PrivateKey.Replace("\\n", Environment.NewLine);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00016154 File Offset: 0x00014354
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncrsadigitalsign.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00016184 File Offset: 0x00014384
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00016190 File Offset: 0x00014390
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
				this.privatekeyControl = (TextInputBox)target;
				return;
			case 3:
				this.hashAlgorithmBox = (ComboBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040001DB RID: 475
		internal VarCapOutputBox outputVar;

		// Token: 0x040001DC RID: 476
		internal TextInputBox privatekeyControl;

		// Token: 0x040001DD RID: 477
		internal ComboBox hashAlgorithmBox;

		// Token: 0x040001DE RID: 478
		private bool _contentLoaded;
	}
}

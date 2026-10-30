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
	// Token: 0x02000057 RID: 87
	public class PageBlockFuncJwtDecode : Page, IComponentConnector
	{
		// Token: 0x060003AA RID: 938 RVA: 0x00015C3E File Offset: 0x00013E3E
		public PageBlockFuncJwtDecode(BlockJwtDecode block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00015C54 File Offset: 0x00013E54
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncjwtdecode.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00015C84 File Offset: 0x00013E84
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00015C8E File Offset: 0x00013E8E
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

		// Token: 0x040001CC RID: 460
		internal VarCapOutputBox outputVar;

		// Token: 0x040001CD RID: 461
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200006B RID: 107
	public class PageBlockFuncRoundFloat : Page, IComponentConnector
	{
		// Token: 0x06000400 RID: 1024 RVA: 0x00016BAC File Offset: 0x00014DAC
		public PageBlockFuncRoundFloat(BlockRoundFloat block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = double.MinValue;
			this.inputControl1.Maximum = double.MaxValue;
			this.inputControl2.Minimum = double.MinValue;
			this.inputControl2.Maximum = double.MaxValue;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00016C1C File Offset: 0x00014E1C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/float/pageblockfuncroundfloat.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00016C4C File Offset: 0x00014E4C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00016C56 File Offset: 0x00014E56
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.inputControl1 = (NumStrInputBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.inputControl2 = (NumStrInputBox)target;
		}

		// Token: 0x04000201 RID: 513
		internal NumStrInputBox inputControl1;

		// Token: 0x04000202 RID: 514
		internal NumStrInputBox inputControl2;

		// Token: 0x04000203 RID: 515
		private bool _contentLoaded;
	}
}

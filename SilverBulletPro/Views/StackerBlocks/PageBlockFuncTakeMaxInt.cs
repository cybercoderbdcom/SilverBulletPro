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
	// Token: 0x02000070 RID: 112
	public class PageBlockFuncTakeMaxInt : Page, IComponentConnector
	{
		// Token: 0x06000414 RID: 1044 RVA: 0x00016F9C File Offset: 0x0001519C
		public PageBlockFuncTakeMaxInt(BlockTakeMaxInt block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = -2147483648.0;
			this.inputControl1.Maximum = 2147483647.0;
			this.inputControl2.Minimum = -2147483648.0;
			this.inputControl2.Maximum = 2147483647.0;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0001700C File Offset: 0x0001520C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/integer/pageblockfunctakemaxint.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0001703C File Offset: 0x0001523C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00017046 File Offset: 0x00015246
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

		// Token: 0x0400020F RID: 527
		internal NumStrInputBox inputControl1;

		// Token: 0x04000210 RID: 528
		internal NumStrInputBox inputControl2;

		// Token: 0x04000211 RID: 529
		private bool _contentLoaded;
	}
}

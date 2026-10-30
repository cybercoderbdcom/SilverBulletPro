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
	// Token: 0x0200006F RID: 111
	public class PageBlockFuncRandInt : Page, IComponentConnector
	{
		// Token: 0x06000410 RID: 1040 RVA: 0x00016EC4 File Offset: 0x000150C4
		public PageBlockFuncRandInt(BlockRandomInt block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = -2147483648.0;
			this.inputControl1.Maximum = 2147483647.0;
			this.inputControl2.Minimum = -2147483648.0;
			this.inputControl2.Maximum = 2147483647.0;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00016F34 File Offset: 0x00015134
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/integer/pageblockfuncrandint.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00016F64 File Offset: 0x00015164
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00016F6E File Offset: 0x0001516E
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

		// Token: 0x0400020C RID: 524
		internal NumStrInputBox inputControl1;

		// Token: 0x0400020D RID: 525
		internal NumStrInputBox inputControl2;

		// Token: 0x0400020E RID: 526
		private bool _contentLoaded;
	}
}

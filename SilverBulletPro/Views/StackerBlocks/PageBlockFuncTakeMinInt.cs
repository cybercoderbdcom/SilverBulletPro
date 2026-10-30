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
	// Token: 0x02000071 RID: 113
	public class PageBlockFuncTakeMinInt : Page, IComponentConnector
	{
		// Token: 0x06000418 RID: 1048 RVA: 0x00017074 File Offset: 0x00015274
		public PageBlockFuncTakeMinInt(BlockTakeMinInt block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = -2147483648.0;
			this.inputControl1.Maximum = 2147483647.0;
			this.inputControl2.Minimum = -2147483648.0;
			this.inputControl2.Maximum = 2147483647.0;
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000170E4 File Offset: 0x000152E4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/integer/pageblockfunctakeminint.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00017114 File Offset: 0x00015314
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0001711E File Offset: 0x0001531E
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

		// Token: 0x04000212 RID: 530
		internal NumStrInputBox inputControl1;

		// Token: 0x04000213 RID: 531
		internal NumStrInputBox inputControl2;

		// Token: 0x04000214 RID: 532
		private bool _contentLoaded;
	}
}

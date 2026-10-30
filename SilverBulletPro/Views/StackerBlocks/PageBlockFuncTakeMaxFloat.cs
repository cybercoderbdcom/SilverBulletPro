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
	// Token: 0x0200006D RID: 109
	public class PageBlockFuncTakeMaxFloat : Page, IComponentConnector
	{
		// Token: 0x06000408 RID: 1032 RVA: 0x00016D14 File Offset: 0x00014F14
		public PageBlockFuncTakeMaxFloat(BlockTakeMaxFloat block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = double.MinValue;
			this.inputControl1.Maximum = double.MaxValue;
			this.inputControl2.Minimum = double.MinValue;
			this.inputControl2.Maximum = double.MaxValue;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00016D84 File Offset: 0x00014F84
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/float/pageblockfunctakemaxfloat.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00016DB4 File Offset: 0x00014FB4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00016DBE File Offset: 0x00014FBE
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

		// Token: 0x04000206 RID: 518
		internal NumStrInputBox inputControl1;

		// Token: 0x04000207 RID: 519
		internal NumStrInputBox inputControl2;

		// Token: 0x04000208 RID: 520
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200006E RID: 110
	public class PageBlockFuncTakeMinFloat : Page, IComponentConnector
	{
		// Token: 0x0600040C RID: 1036 RVA: 0x00016DEC File Offset: 0x00014FEC
		public PageBlockFuncTakeMinFloat(BlockTakeMinFloat block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = double.MinValue;
			this.inputControl1.Maximum = double.MaxValue;
			this.inputControl2.Minimum = double.MinValue;
			this.inputControl2.Maximum = double.MaxValue;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00016E5C File Offset: 0x0001505C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/float/pageblockfunctakeminfloat.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00016E8C File Offset: 0x0001508C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00016E96 File Offset: 0x00015096
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

		// Token: 0x04000209 RID: 521
		internal NumStrInputBox inputControl1;

		// Token: 0x0400020A RID: 522
		internal NumStrInputBox inputControl2;

		// Token: 0x0400020B RID: 523
		private bool _contentLoaded;
	}
}

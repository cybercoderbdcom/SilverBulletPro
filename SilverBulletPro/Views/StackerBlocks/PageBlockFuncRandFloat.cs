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
	// Token: 0x0200006A RID: 106
	public class PageBlockFuncRandFloat : Page, IComponentConnector
	{
		// Token: 0x060003FC RID: 1020 RVA: 0x00016AD4 File Offset: 0x00014CD4
		public PageBlockFuncRandFloat(BlockRandomFloat block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = double.MinValue;
			this.inputControl1.Maximum = double.MaxValue;
			this.inputControl2.Minimum = double.MinValue;
			this.inputControl2.Maximum = double.MaxValue;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00016B44 File Offset: 0x00014D44
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/float/pageblockfuncrandfloat.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00016B74 File Offset: 0x00014D74
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00016B7E File Offset: 0x00014D7E
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

		// Token: 0x040001FE RID: 510
		internal NumStrInputBox inputControl1;

		// Token: 0x040001FF RID: 511
		internal NumStrInputBox inputControl2;

		// Token: 0x04000200 RID: 512
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200006C RID: 108
	public class PageBlockFuncRoundToInteger : Page, IComponentConnector
	{
		// Token: 0x06000404 RID: 1028 RVA: 0x00016C83 File Offset: 0x00014E83
		public PageBlockFuncRoundToInteger(BlockRoundToInteger block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = double.MinValue;
			this.inputControl1.Maximum = double.MaxValue;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00016CC0 File Offset: 0x00014EC0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/float/pageblockfuncroundtointeger.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00016CF0 File Offset: 0x00014EF0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00016CFA File Offset: 0x00014EFA
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
			this._contentLoaded = true;
		}

		// Token: 0x04000204 RID: 516
		internal NumStrInputBox inputControl1;

		// Token: 0x04000205 RID: 517
		private bool _contentLoaded;
	}
}

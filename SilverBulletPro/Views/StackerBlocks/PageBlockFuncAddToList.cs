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
	// Token: 0x02000073 RID: 115
	public class PageBlockFuncAddToList : Page, IComponentConnector
	{
		// Token: 0x06000420 RID: 1056 RVA: 0x000171C8 File Offset: 0x000153C8
		public PageBlockFuncAddToList(BlockAddToList block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControlNum.Minimum = -1.0;
			this.inputControlNum.Maximum = 2147483647.0;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00017208 File Offset: 0x00015408
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncaddtolist.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00017238 File Offset: 0x00015438
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00017242 File Offset: 0x00015442
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.inputControlNum = (NumStrInputBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000217 RID: 535
		internal NumStrInputBox inputControlNum;

		// Token: 0x04000218 RID: 536
		private bool _contentLoaded;
	}
}

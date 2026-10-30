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
	// Token: 0x02000066 RID: 102
	public class PageBlockFuncAbs : Page, IComponentConnector
	{
		// Token: 0x060003EB RID: 1003 RVA: 0x0001687B File Offset: 0x00014A7B
		public PageBlockFuncAbs(BlockAbsolute block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00016890 File Offset: 0x00014A90
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/float/pageblockfuncabs.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000168C0 File Offset: 0x00014AC0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x000168CA File Offset: 0x00014ACA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.inputControl = (NumStrInputBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040001F7 RID: 503
		internal NumStrInputBox inputControl;

		// Token: 0x040001F8 RID: 504
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200007D RID: 125
	public class PageBlockFuncRemoveFromList : Page, IComponentConnector
	{
		// Token: 0x06000448 RID: 1096 RVA: 0x0001764F File Offset: 0x0001584F
		public PageBlockFuncRemoveFromList(BlockRemoveFromList block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = -2147483648.0;
			this.inputControl1.Maximum = 2147483647.0;
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x0001768C File Offset: 0x0001588C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncremovefromlist.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x000176BC File Offset: 0x000158BC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000176C6 File Offset: 0x000158C6
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

		// Token: 0x04000223 RID: 547
		internal NumStrInputBox inputControl1;

		// Token: 0x04000224 RID: 548
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200008F RID: 143
	public class PageBlockFuncSubstring : Page, IComponentConnector
	{
		// Token: 0x06000493 RID: 1171 RVA: 0x00018124 File Offset: 0x00016324
		public PageBlockFuncSubstring(BlockSubstring block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.indexNum.Minimum = 0.0;
			this.indexNum.Maximum = 2147483647.0;
			this.lengthNum.Minimum = -1.0;
			this.lengthNum.Maximum = 2147483647.0;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00018194 File Offset: 0x00016394
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncsubstring.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x000181C4 File Offset: 0x000163C4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x000181CE File Offset: 0x000163CE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.indexNum = (NumStrInputBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.lengthNum = (NumStrInputBox)target;
		}

		// Token: 0x0400023E RID: 574
		internal NumStrInputBox indexNum;

		// Token: 0x0400023F RID: 575
		internal NumStrInputBox lengthNum;

		// Token: 0x04000240 RID: 576
		private bool _contentLoaded;
	}
}

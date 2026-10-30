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
	// Token: 0x0200004A RID: 74
	public class PageBlockFuncMergeByteArrays : Page, IComponentConnector
	{
		// Token: 0x0600036F RID: 879 RVA: 0x00014FCB File Offset: 0x000131CB
		public PageBlockFuncMergeByteArrays(BlockMergeByteArrays block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00014FE0 File Offset: 0x000131E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/bytearrays/pageblockfuncmergebytearrays.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00015010 File Offset: 0x00013210
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0001501A File Offset: 0x0001321A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.first = (TextInputBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.second = (TextInputBox)target;
		}

		// Token: 0x040001A6 RID: 422
		internal TextInputBox first;

		// Token: 0x040001A7 RID: 423
		internal TextInputBox second;

		// Token: 0x040001A8 RID: 424
		private bool _contentLoaded;
	}
}

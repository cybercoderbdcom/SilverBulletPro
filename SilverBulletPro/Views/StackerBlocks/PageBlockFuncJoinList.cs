using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000077 RID: 119
	public class PageBlockFuncJoinList : Page, IComponentConnector
	{
		// Token: 0x06000430 RID: 1072 RVA: 0x00017367 File Offset: 0x00015567
		public PageBlockFuncJoinList(BlockJoinList block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0001737C File Offset: 0x0001557C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncjoinlist.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000173AC File Offset: 0x000155AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000173B6 File Offset: 0x000155B6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400021C RID: 540
		private bool _contentLoaded;
	}
}

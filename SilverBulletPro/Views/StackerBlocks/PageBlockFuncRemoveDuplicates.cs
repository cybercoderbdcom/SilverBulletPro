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
	// Token: 0x0200007C RID: 124
	public class PageBlockFuncRemoveDuplicates : Page, IComponentConnector
	{
		// Token: 0x06000444 RID: 1092 RVA: 0x000175F4 File Offset: 0x000157F4
		public PageBlockFuncRemoveDuplicates(BlockRemoveDuplicates block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0001760C File Offset: 0x0001580C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncremoveduplicates.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0001763C File Offset: 0x0001583C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00017646 File Offset: 0x00015846
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000222 RID: 546
		private bool _contentLoaded;
	}
}

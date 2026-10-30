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
	// Token: 0x0200007F RID: 127
	public class PageBlockFuncSortList : Page, IComponentConnector
	{
		// Token: 0x06000450 RID: 1104 RVA: 0x0001773B File Offset: 0x0001593B
		public PageBlockFuncSortList(BlockSortList block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00017750 File Offset: 0x00015950
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncsortlist.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00017780 File Offset: 0x00015980
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x0001778A File Offset: 0x0001598A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000226 RID: 550
		private bool _contentLoaded;
	}
}

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
	// Token: 0x02000161 RID: 353
	public class PageBlockUtilityReadableSize : Page, IComponentConnector
	{
		// Token: 0x0600083B RID: 2107 RVA: 0x000242D4 File Offset: 0x000224D4
		public PageBlockUtilityReadableSize(BlockReadableSize block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00024300 File Offset: 0x00022500
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilityreadablesize.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00024330 File Offset: 0x00022530
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0002433A File Offset: 0x0002253A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003D4 RID: 980
		private BlockReadableSize vm;

		// Token: 0x040003D5 RID: 981
		private bool _contentLoaded;
	}
}

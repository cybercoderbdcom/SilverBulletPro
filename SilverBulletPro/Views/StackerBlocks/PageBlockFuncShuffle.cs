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
	// Token: 0x0200007E RID: 126
	public class PageBlockFuncShuffle : Page, IComponentConnector
	{
		// Token: 0x0600044C RID: 1100 RVA: 0x000176E0 File Offset: 0x000158E0
		public PageBlockFuncShuffle(BlockShuffle block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x000176F8 File Offset: 0x000158F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncshuffle.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00017728 File Offset: 0x00015928
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00017732 File Offset: 0x00015932
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000225 RID: 549
		private bool _contentLoaded;
	}
}

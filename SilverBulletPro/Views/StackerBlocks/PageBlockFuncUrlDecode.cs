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
	// Token: 0x02000096 RID: 150
	public class PageBlockFuncUrlDecode : Page, IComponentConnector
	{
		// Token: 0x060004B1 RID: 1201 RVA: 0x000184EB File Offset: 0x000166EB
		public PageBlockFuncUrlDecode(BlockUrlDecode block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00018500 File Offset: 0x00016700
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncurldecode.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00018530 File Offset: 0x00016730
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x0001853A File Offset: 0x0001673A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000248 RID: 584
		private bool _contentLoaded;
	}
}

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
	// Token: 0x02000095 RID: 149
	public class PageBlockFuncUnescape : Page, IComponentConnector
	{
		// Token: 0x060004AD RID: 1197 RVA: 0x00018493 File Offset: 0x00016693
		public PageBlockFuncUnescape(BlockUnescape block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x000184A8 File Offset: 0x000166A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncunescape.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000184D8 File Offset: 0x000166D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x000184E2 File Offset: 0x000166E2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000247 RID: 583
		private bool _contentLoaded;
	}
}

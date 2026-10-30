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
	// Token: 0x02000081 RID: 129
	public class PageBlockFuncGenerateGuid : Page, IComponentConnector
	{
		// Token: 0x06000458 RID: 1112 RVA: 0x000177EB File Offset: 0x000159EB
		public PageBlockFuncGenerateGuid(BlockGenerateGuid block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00017800 File Offset: 0x00015A00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/pageblockfuncgenerateguid.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00017830 File Offset: 0x00015A30
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0001783A File Offset: 0x00015A3A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000228 RID: 552
		private bool _contentLoaded;
	}
}

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
	// Token: 0x02000151 RID: 337
	public class PageBlockSolveKeyCaptcha : Page, IComponentConnector
	{
		// Token: 0x060007FB RID: 2043 RVA: 0x00023B29 File Offset: 0x00021D29
		public PageBlockSolveKeyCaptcha(BlockSolveKeyCaptcha block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x00023B40 File Offset: 0x00021D40
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblocksolvekeycaptcha.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00023B70 File Offset: 0x00021D70
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00023B7A File Offset: 0x00021D7A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003B8 RID: 952
		private bool _contentLoaded;
	}
}

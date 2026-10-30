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
	// Token: 0x0200014C RID: 332
	public class PageBlockSolveCapyCaptcha : Page, IComponentConnector
	{
		// Token: 0x060007E7 RID: 2023 RVA: 0x000237EF File Offset: 0x000219EF
		public PageBlockSolveCapyCaptcha(BlockSolveCapyCaptcha block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x00023804 File Offset: 0x00021A04
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblocksolvecapycaptcha.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x00023834 File Offset: 0x00021A34
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0002383E File Offset: 0x00021A3E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003B0 RID: 944
		private bool _contentLoaded;
	}
}

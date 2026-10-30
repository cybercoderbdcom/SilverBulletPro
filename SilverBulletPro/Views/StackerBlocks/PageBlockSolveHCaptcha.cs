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
	// Token: 0x0200014F RID: 335
	public class PageBlockSolveHCaptcha : Page, IComponentConnector
	{
		// Token: 0x060007F3 RID: 2035 RVA: 0x000238F7 File Offset: 0x00021AF7
		public PageBlockSolveHCaptcha(BlockSolveHCaptcha block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0002390C File Offset: 0x00021B0C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblocksolvehcaptcha.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0002393C File Offset: 0x00021B3C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00023946 File Offset: 0x00021B46
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003B3 RID: 947
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200014B RID: 331
	public class PageBlockReportLastSolution : Page, IComponentConnector
	{
		// Token: 0x060007E3 RID: 2019 RVA: 0x00023797 File Offset: 0x00021997
		public PageBlockReportLastSolution(BlockReportLastSolution block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x000237AC File Offset: 0x000219AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblockreportlastsolution.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x000237DC File Offset: 0x000219DC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x000237E6 File Offset: 0x000219E6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003AF RID: 943
		private bool _contentLoaded;
	}
}

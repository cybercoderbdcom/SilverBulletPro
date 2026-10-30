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
	// Token: 0x0200014D RID: 333
	public class PageBlockSolveFunCaptcha : Page, IComponentConnector
	{
		// Token: 0x060007EB RID: 2027 RVA: 0x00023847 File Offset: 0x00021A47
		public PageBlockSolveFunCaptcha(BlockSolveFunCaptcha block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0002385C File Offset: 0x00021A5C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblocksolvefuncaptcha.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0002388C File Offset: 0x00021A8C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x00023896 File Offset: 0x00021A96
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003B1 RID: 945
		private bool _contentLoaded;
	}
}

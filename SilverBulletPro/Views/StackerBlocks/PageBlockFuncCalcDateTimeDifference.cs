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
	// Token: 0x02000098 RID: 152
	public class PageBlockFuncCalcDateTimeDifference : Page, IComponentConnector
	{
		// Token: 0x060004B9 RID: 1209 RVA: 0x0001859B File Offset: 0x0001679B
		public PageBlockFuncCalcDateTimeDifference(BlockCalcDateTimeDifference block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x000185B0 File Offset: 0x000167B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/time/pageblockfunccalcdatetimedifference.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x000185E0 File Offset: 0x000167E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000185EA File Offset: 0x000167EA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400024A RID: 586
		private bool _contentLoaded;
	}
}

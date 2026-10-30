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
	// Token: 0x02000099 RID: 153
	public class PageBlockFuncCalcRelativeTime : Page, IComponentConnector
	{
		// Token: 0x060004BD RID: 1213 RVA: 0x000185F3 File Offset: 0x000167F3
		public PageBlockFuncCalcRelativeTime(BlockCalcRelativeTime block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00018608 File Offset: 0x00016808
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/time/pageblockfunccalcrelativetime.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00018638 File Offset: 0x00016838
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00018642 File Offset: 0x00016842
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400024B RID: 587
		private bool _contentLoaded;
	}
}

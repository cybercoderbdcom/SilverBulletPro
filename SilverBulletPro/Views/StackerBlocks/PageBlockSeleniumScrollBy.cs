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
	// Token: 0x02000145 RID: 325
	public class PageBlockSeleniumScrollBy : Page, IComponentConnector
	{
		// Token: 0x060007A8 RID: 1960 RVA: 0x00021D67 File Offset: 0x0001FF67
		public PageBlockSeleniumScrollBy(BlockSeleniumScrollBy block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x00021D7C File Offset: 0x0001FF7C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/selenium/page/pageblockseleniumscrollby.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00021DAC File Offset: 0x0001FFAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00021DB6 File Offset: 0x0001FFB6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400038F RID: 911
		private bool _contentLoaded;
	}
}

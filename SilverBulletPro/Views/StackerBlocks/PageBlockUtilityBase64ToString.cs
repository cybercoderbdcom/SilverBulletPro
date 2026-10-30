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
	// Token: 0x02000156 RID: 342
	public class PageBlockUtilityBase64ToString : Page, IComponentConnector
	{
		// Token: 0x0600080F RID: 2063 RVA: 0x00023E2B File Offset: 0x0002202B
		public PageBlockUtilityBase64ToString(BlockBase64ToString block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00023E40 File Offset: 0x00022040
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitybase64tostring.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00023E70 File Offset: 0x00022070
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00023E7A File Offset: 0x0002207A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003C1 RID: 961
		private bool _contentLoaded;
	}
}

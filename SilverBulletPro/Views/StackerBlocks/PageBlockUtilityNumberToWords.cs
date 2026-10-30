using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000160 RID: 352
	public class PageBlockUtilityNumberToWords : Page, IComponentConnector
	{
		// Token: 0x06000837 RID: 2103 RVA: 0x00024243 File Offset: 0x00022443
		public PageBlockUtilityNumberToWords(BlockNumberToWords block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl.Minimum = -2147483648.0;
			this.inputControl.Maximum = 2147483647.0;
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00024280 File Offset: 0x00022480
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitynumbertowords.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x000242B0 File Offset: 0x000224B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x000242BA File Offset: 0x000224BA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.inputControl = (NumStrInputBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040003D2 RID: 978
		internal NumStrInputBox inputControl;

		// Token: 0x040003D3 RID: 979
		private bool _contentLoaded;
	}
}

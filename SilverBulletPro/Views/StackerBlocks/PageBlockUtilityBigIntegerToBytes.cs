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
	// Token: 0x02000157 RID: 343
	public class PageBlockUtilityBigIntegerToBytes : Page, IComponentConnector
	{
		// Token: 0x06000813 RID: 2067 RVA: 0x00023E84 File Offset: 0x00022084
		public PageBlockUtilityBigIntegerToBytes(BlockBigIntegerToBytes block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00023EB0 File Offset: 0x000220B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitybigintegertobytes.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00023EE0 File Offset: 0x000220E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00023EEA File Offset: 0x000220EA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003C2 RID: 962
		public BlockBigIntegerToBytes vm;

		// Token: 0x040003C3 RID: 963
		private bool _contentLoaded;
	}
}

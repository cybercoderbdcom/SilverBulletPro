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
	// Token: 0x02000158 RID: 344
	public class PageBlockUtilityBinaryStringToBytes : Page, IComponentConnector
	{
		// Token: 0x06000817 RID: 2071 RVA: 0x00023EF4 File Offset: 0x000220F4
		public PageBlockUtilityBinaryStringToBytes(BlockBinaryStringToBytes block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00023F20 File Offset: 0x00022120
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitybinarystringtobytes.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00023F50 File Offset: 0x00022150
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00023F5A File Offset: 0x0002215A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003C4 RID: 964
		private BlockBinaryStringToBytes vm;

		// Token: 0x040003C5 RID: 965
		private bool _contentLoaded;
	}
}

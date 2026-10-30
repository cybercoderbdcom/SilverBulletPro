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
	// Token: 0x02000159 RID: 345
	public class PageBlockUtilityBytesToBase64 : Page, IComponentConnector
	{
		// Token: 0x0600081B RID: 2075 RVA: 0x00023F64 File Offset: 0x00022164
		public PageBlockUtilityBytesToBase64(BlockBytesToBase64 block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00023F90 File Offset: 0x00022190
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitybytestobase64.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00023FC0 File Offset: 0x000221C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00023FCA File Offset: 0x000221CA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003C6 RID: 966
		private BlockBytesToBase64 vm;

		// Token: 0x040003C7 RID: 967
		private bool _contentLoaded;
	}
}

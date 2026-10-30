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
	// Token: 0x0200015C RID: 348
	public class PageBlockUtilityBytesToHex : Page, IComponentConnector
	{
		// Token: 0x06000827 RID: 2087 RVA: 0x000240B4 File Offset: 0x000222B4
		public PageBlockUtilityBytesToHex(BlockBytesToHex block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x000240E0 File Offset: 0x000222E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitybytestohex.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00024110 File Offset: 0x00022310
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0002411A File Offset: 0x0002231A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003CC RID: 972
		private BlockBytesToHex vm;

		// Token: 0x040003CD RID: 973
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200015F RID: 351
	public class PageBlockUtilityIntegerToBytes : Page, IComponentConnector
	{
		// Token: 0x06000833 RID: 2099 RVA: 0x000241EB File Offset: 0x000223EB
		public PageBlockUtilityIntegerToBytes(BlockIntegerToBytes block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x00024200 File Offset: 0x00022400
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilityintegertobytes.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00024230 File Offset: 0x00022430
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0002423A File Offset: 0x0002243A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003D1 RID: 977
		private bool _contentLoaded;
	}
}

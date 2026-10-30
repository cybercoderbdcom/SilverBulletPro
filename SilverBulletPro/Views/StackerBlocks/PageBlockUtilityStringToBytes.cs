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
	// Token: 0x02000162 RID: 354
	public class PageBlockUtilityStringToBytes : Page, IComponentConnector
	{
		// Token: 0x0600083F RID: 2111 RVA: 0x00024344 File Offset: 0x00022544
		public PageBlockUtilityStringToBytes(BlockStringToBytes block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00024370 File Offset: 0x00022570
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitystringtobytes.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x000243A0 File Offset: 0x000225A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x000243AA File Offset: 0x000225AA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003D6 RID: 982
		private BlockStringToBytes vm;

		// Token: 0x040003D7 RID: 983
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200015B RID: 347
	public class PageBlockUtilityBytesToBinaryString : Page, IComponentConnector
	{
		// Token: 0x06000823 RID: 2083 RVA: 0x00024044 File Offset: 0x00022244
		public PageBlockUtilityBytesToBinaryString(BlockBytesToBinaryString block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00024070 File Offset: 0x00022270
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitybytestobinarystring.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x000240A0 File Offset: 0x000222A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x000240AA File Offset: 0x000222AA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003CA RID: 970
		private BlockBytesToBinaryString vm;

		// Token: 0x040003CB RID: 971
		private bool _contentLoaded;
	}
}

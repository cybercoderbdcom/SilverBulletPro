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
	// Token: 0x02000168 RID: 360
	public class PageBlockUtilityFileDelete : Page, IComponentConnector
	{
		// Token: 0x0600085B RID: 2139 RVA: 0x00024873 File Offset: 0x00022A73
		public PageBlockUtilityFileDelete(BlockFileDelete block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00024888 File Offset: 0x00022A88
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfiledelete.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x000248B8 File Offset: 0x00022AB8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x000248C2 File Offset: 0x00022AC2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003E4 RID: 996
		private bool _contentLoaded;
	}
}

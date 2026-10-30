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
	// Token: 0x02000164 RID: 356
	public class PageBlockUtilityCreatePath : Page, IComponentConnector
	{
		// Token: 0x06000847 RID: 2119 RVA: 0x0002440C File Offset: 0x0002260C
		public PageBlockUtilityCreatePath(BlockCreateDirPath block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00024438 File Offset: 0x00022638
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilitycreatedirpath.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x00024468 File Offset: 0x00022668
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x00024472 File Offset: 0x00022672
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003D9 RID: 985
		private BlockCreateDirPath vm;

		// Token: 0x040003DA RID: 986
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200016A RID: 362
	public class PageBlockUtilityFileMove : Page, IComponentConnector
	{
		// Token: 0x06000863 RID: 2147 RVA: 0x0002493B File Offset: 0x00022B3B
		public PageBlockUtilityFileMove(BlockFileMove block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x00024950 File Offset: 0x00022B50
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfilemove.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x00024980 File Offset: 0x00022B80
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0002498A File Offset: 0x00022B8A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003E7 RID: 999
		private bool _contentLoaded;
	}
}

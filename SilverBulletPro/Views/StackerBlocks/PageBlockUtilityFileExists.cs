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
	// Token: 0x02000169 RID: 361
	public class PageBlockUtilityFileExists : Page, IComponentConnector
	{
		// Token: 0x0600085F RID: 2143 RVA: 0x000248CC File Offset: 0x00022ACC
		public PageBlockUtilityFileExists(BlockFileExists block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x000248F8 File Offset: 0x00022AF8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfileexists.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00024928 File Offset: 0x00022B28
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00024932 File Offset: 0x00022B32
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003E5 RID: 997
		private BlockFileExists vm;

		// Token: 0x040003E6 RID: 998
		private bool _contentLoaded;
	}
}

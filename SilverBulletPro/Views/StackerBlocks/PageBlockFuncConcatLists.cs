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
	// Token: 0x02000074 RID: 116
	public class PageBlockFuncConcatLists : Page, IComponentConnector
	{
		// Token: 0x06000424 RID: 1060 RVA: 0x0001725C File Offset: 0x0001545C
		public PageBlockFuncConcatLists(BlockConcatLists block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00017274 File Offset: 0x00015474
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncconcatlists.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x000172A4 File Offset: 0x000154A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000172AE File Offset: 0x000154AE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000219 RID: 537
		private bool _contentLoaded;
	}
}

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
	// Token: 0x02000080 RID: 128
	public class PageBlockFuncZipLists : Page, IComponentConnector
	{
		// Token: 0x06000454 RID: 1108 RVA: 0x00017793 File Offset: 0x00015993
		public PageBlockFuncZipLists(BlockZipLists block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000177A8 File Offset: 0x000159A8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncziplists.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x000177D8 File Offset: 0x000159D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x000177E2 File Offset: 0x000159E2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000227 RID: 551
		private bool _contentLoaded;
	}
}

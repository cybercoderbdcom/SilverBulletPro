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
	// Token: 0x02000091 RID: 145
	public class PageBlockFuncToTitlecase : Page, IComponentConnector
	{
		// Token: 0x0600049B RID: 1179 RVA: 0x00018253 File Offset: 0x00016453
		public PageBlockFuncToTitlecase(BlockToTitleCase block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00018268 File Offset: 0x00016468
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfunctotitlecase.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x00018298 File Offset: 0x00016498
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x000182A2 File Offset: 0x000164A2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000242 RID: 578
		private bool _contentLoaded;
	}
}

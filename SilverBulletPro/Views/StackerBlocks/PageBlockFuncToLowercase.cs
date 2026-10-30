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
	// Token: 0x02000090 RID: 144
	public class PageBlockFuncToLowercase : Page, IComponentConnector
	{
		// Token: 0x06000497 RID: 1175 RVA: 0x000181FB File Offset: 0x000163FB
		public PageBlockFuncToLowercase(BlockToLowerCase block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00018210 File Offset: 0x00016410
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfunctolowercase.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00018240 File Offset: 0x00016440
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0001824A File Offset: 0x0001644A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000241 RID: 577
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200008D RID: 141
	public class PageBlockFuncReverse : Page, IComponentConnector
	{
		// Token: 0x0600048A RID: 1162 RVA: 0x00017F37 File Offset: 0x00016137
		public PageBlockFuncReverse(BlockReverseString block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00017F4C File Offset: 0x0001614C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncreverse.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00017F7C File Offset: 0x0001617C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00017F86 File Offset: 0x00016186
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400023A RID: 570
		private bool _contentLoaded;
	}
}

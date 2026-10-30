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
	// Token: 0x02000086 RID: 134
	public class PageBlockFuncEncodeHtmlEntities : Page, IComponentConnector
	{
		// Token: 0x0600046C RID: 1132 RVA: 0x00017A3F File Offset: 0x00015C3F
		public PageBlockFuncEncodeHtmlEntities(BlockEncodeHtmlEntities block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00017A54 File Offset: 0x00015C54
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncencodehtmlentities.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00017A84 File Offset: 0x00015C84
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00017A8E File Offset: 0x00015C8E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400022F RID: 559
		private bool _contentLoaded;
	}
}

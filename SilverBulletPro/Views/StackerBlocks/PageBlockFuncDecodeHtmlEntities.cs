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
	// Token: 0x02000085 RID: 133
	public class PageBlockFuncDecodeHtmlEntities : Page, IComponentConnector
	{
		// Token: 0x06000468 RID: 1128 RVA: 0x000179E7 File Offset: 0x00015BE7
		public PageBlockFuncDecodeHtmlEntities(BlockDecodeHtmlEntities block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x000179FC File Offset: 0x00015BFC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncdecodehtmlentities.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00017A2C File Offset: 0x00015C2C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00017A36 File Offset: 0x00015C36
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400022E RID: 558
		private bool _contentLoaded;
	}
}

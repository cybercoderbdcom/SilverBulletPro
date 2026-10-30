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
	// Token: 0x0200009C RID: 156
	public class PageBlockFuncDateToSolar : Page, IComponentConnector
	{
		// Token: 0x060004C9 RID: 1225 RVA: 0x0001878C File Offset: 0x0001698C
		public PageBlockFuncDateToSolar(BlockDateToSolar block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x000187A4 File Offset: 0x000169A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/time/pageblockfuncdatetosolar.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x000187D4 File Offset: 0x000169D4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x000187DE File Offset: 0x000169DE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400024F RID: 591
		private bool _contentLoaded;
	}
}

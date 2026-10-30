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
	// Token: 0x0200009F RID: 159
	public class PageBlockFuncUnixTimeToISO8601 : Page, IComponentConnector
	{
		// Token: 0x060004D5 RID: 1237 RVA: 0x000189B8 File Offset: 0x00016BB8
		public PageBlockFuncUnixTimeToISO8601(BlockUnixTimeToISO8601 block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000189D0 File Offset: 0x00016BD0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/time/pageblockfuncunixtimetoiso8601.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00018A00 File Offset: 0x00016C00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00018A0A File Offset: 0x00016C0A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000254 RID: 596
		private bool _contentLoaded;
	}
}

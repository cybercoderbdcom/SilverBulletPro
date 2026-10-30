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
	// Token: 0x02000176 RID: 374
	public class PageBlockUtilityDelay : Page, IComponentConnector
	{
		// Token: 0x0600089B RID: 2203 RVA: 0x0002540F File Offset: 0x0002360F
		public PageBlockUtilityDelay(BlockDelay block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x00025424 File Offset: 0x00023624
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/pageblockutilitydelay.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x00025454 File Offset: 0x00023654
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0002545E File Offset: 0x0002365E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000401 RID: 1025
		private bool _contentLoaded;
	}
}

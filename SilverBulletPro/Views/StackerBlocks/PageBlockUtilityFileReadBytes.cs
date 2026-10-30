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
	// Token: 0x0200016C RID: 364
	public class PageBlockUtilityFileReadBytes : Page, IComponentConnector
	{
		// Token: 0x0600086D RID: 2157 RVA: 0x00024B3E File Offset: 0x00022D3E
		public PageBlockUtilityFileReadBytes(BlockFileReadBytes block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00024B54 File Offset: 0x00022D54
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfilereadbytes.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00024B84 File Offset: 0x00022D84
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00024B8E File Offset: 0x00022D8E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003EB RID: 1003
		private bool _contentLoaded;
	}
}

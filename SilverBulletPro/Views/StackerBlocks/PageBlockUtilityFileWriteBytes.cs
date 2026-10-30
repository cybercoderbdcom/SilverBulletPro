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
	// Token: 0x0200016F RID: 367
	public class PageBlockUtilityFileWriteBytes : Page, IComponentConnector
	{
		// Token: 0x0600087D RID: 2173 RVA: 0x00024EEE File Offset: 0x000230EE
		public PageBlockUtilityFileWriteBytes(BlockFileWriteBytes block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00024F04 File Offset: 0x00023104
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfilewritebytes.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00024F34 File Offset: 0x00023134
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00024F3E File Offset: 0x0002313E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003F2 RID: 1010
		private bool _contentLoaded;
	}
}

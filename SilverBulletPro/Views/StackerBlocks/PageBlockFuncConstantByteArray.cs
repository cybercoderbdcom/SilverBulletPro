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
	// Token: 0x0200004B RID: 75
	public class PageBlockFuncConstantByteArray : Page, IComponentConnector
	{
		// Token: 0x06000373 RID: 883 RVA: 0x00015047 File Offset: 0x00013247
		public PageBlockFuncConstantByteArray(BlockConstantByteArray block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0001505C File Offset: 0x0001325C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/constants/pageblockfuncconstantbytearray.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0001508C File Offset: 0x0001328C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00015096 File Offset: 0x00013296
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001A9 RID: 425
		private bool _contentLoaded;
	}
}

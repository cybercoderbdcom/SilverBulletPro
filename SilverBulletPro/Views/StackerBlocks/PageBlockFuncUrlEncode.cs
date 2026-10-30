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
	// Token: 0x02000097 RID: 151
	public class PageBlockFuncUrlEncode : Page, IComponentConnector
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x00018543 File Offset: 0x00016743
		public PageBlockFuncUrlEncode(BlockUrlEncode block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00018558 File Offset: 0x00016758
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncurlencode.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00018588 File Offset: 0x00016788
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x00018592 File Offset: 0x00016792
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000249 RID: 585
		private bool _contentLoaded;
	}
}

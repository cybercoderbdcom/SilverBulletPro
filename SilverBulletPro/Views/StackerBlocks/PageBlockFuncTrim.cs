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
	// Token: 0x02000094 RID: 148
	public class PageBlockFuncTrim : Page, IComponentConnector
	{
		// Token: 0x060004A9 RID: 1193 RVA: 0x0001843A File Offset: 0x0001663A
		public PageBlockFuncTrim(BlockTrim block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00018450 File Offset: 0x00016650
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfunctrim.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00018480 File Offset: 0x00016680
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x0001848A File Offset: 0x0001668A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000246 RID: 582
		private bool _contentLoaded;
	}
}

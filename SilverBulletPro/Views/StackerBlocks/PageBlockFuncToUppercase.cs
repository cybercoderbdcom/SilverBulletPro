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
	// Token: 0x02000092 RID: 146
	public class PageBlockFuncToUppercase : Page, IComponentConnector
	{
		// Token: 0x0600049F RID: 1183 RVA: 0x000182AB File Offset: 0x000164AB
		public PageBlockFuncToUppercase(BlockToUpperCase block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x000182C0 File Offset: 0x000164C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfunctouppercase.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x000182F0 File Offset: 0x000164F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x000182FA File Offset: 0x000164FA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000243 RID: 579
		private bool _contentLoaded;
	}
}

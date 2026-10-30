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
	// Token: 0x02000155 RID: 341
	public class PageBlockUtilityBase64ToBytes : Page, IComponentConnector
	{
		// Token: 0x0600080B RID: 2059 RVA: 0x00023DBC File Offset: 0x00021FBC
		public PageBlockUtilityBase64ToBytes(BlockBase64ToBytes block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00023DE8 File Offset: 0x00021FE8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitybase64tobytes.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00023E18 File Offset: 0x00022018
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00023E22 File Offset: 0x00022022
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003BF RID: 959
		private BlockBase64ToBytes vm;

		// Token: 0x040003C0 RID: 960
		private bool _contentLoaded;
	}
}

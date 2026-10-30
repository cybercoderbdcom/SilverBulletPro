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
	// Token: 0x02000177 RID: 375
	public class PageBlockUtilityGetHwid : Page, IComponentConnector
	{
		// Token: 0x0600089F RID: 2207 RVA: 0x00025467 File Offset: 0x00023667
		public PageBlockUtilityGetHwid(BlockGetHwid block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x0002547C File Offset: 0x0002367C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/pageblockutilitygethwid.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x000254AC File Offset: 0x000236AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000254B6 File Offset: 0x000236B6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000402 RID: 1026
		private bool _contentLoaded;
	}
}

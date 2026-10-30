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
	// Token: 0x02000175 RID: 373
	public class PageBlockUtilityClearCookies : Page, IComponentConnector
	{
		// Token: 0x06000897 RID: 2199 RVA: 0x000253B7 File Offset: 0x000235B7
		public PageBlockUtilityClearCookies(BlockClearCookies block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x000253CC File Offset: 0x000235CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/pageblockutilityclearcookies.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x000253FC File Offset: 0x000235FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00025406 File Offset: 0x00023606
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000400 RID: 1024
		private bool _contentLoaded;
	}
}

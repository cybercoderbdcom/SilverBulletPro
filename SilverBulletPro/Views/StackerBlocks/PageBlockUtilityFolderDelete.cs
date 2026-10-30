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
	// Token: 0x02000171 RID: 369
	public class PageBlockUtilityFolderDelete : Page, IComponentConnector
	{
		// Token: 0x06000887 RID: 2183 RVA: 0x00025124 File Offset: 0x00023324
		public PageBlockUtilityFolderDelete(BlockFolderDelete block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00025150 File Offset: 0x00023350
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfolderdelete.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00025180 File Offset: 0x00023380
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x0002518A File Offset: 0x0002338A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003F7 RID: 1015
		private BlockFolderDelete vm;

		// Token: 0x040003F8 RID: 1016
		private bool _contentLoaded;
	}
}

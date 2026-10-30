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
	// Token: 0x0200015A RID: 346
	public class PageBlockUtilityBytesToBigInteger : Page, IComponentConnector
	{
		// Token: 0x0600081F RID: 2079 RVA: 0x00023FD4 File Offset: 0x000221D4
		public PageBlockUtilityBytesToBigInteger(BlockBytesToBigInteger block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00024000 File Offset: 0x00022200
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitybytestobiginteger.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x00024030 File Offset: 0x00022230
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0002403A File Offset: 0x0002223A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003C8 RID: 968
		private BlockBytesToBigInteger vm;

		// Token: 0x040003C9 RID: 969
		private bool _contentLoaded;
	}
}

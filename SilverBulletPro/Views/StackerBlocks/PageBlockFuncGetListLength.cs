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
	// Token: 0x02000075 RID: 117
	public class PageBlockFuncGetListLength : Page, IComponentConnector
	{
		// Token: 0x06000428 RID: 1064 RVA: 0x000172B7 File Offset: 0x000154B7
		public PageBlockFuncGetListLength(BlockGetListLength block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000172CC File Offset: 0x000154CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncgetlistlength.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x000172FC File Offset: 0x000154FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00017306 File Offset: 0x00015506
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400021A RID: 538
		private bool _contentLoaded;
	}
}

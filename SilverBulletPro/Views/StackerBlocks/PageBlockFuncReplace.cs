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
	// Token: 0x0200008C RID: 140
	public class PageBlockFuncReplace : Page, IComponentConnector
	{
		// Token: 0x06000486 RID: 1158 RVA: 0x00017EDF File Offset: 0x000160DF
		public PageBlockFuncReplace(BlockReplaceString block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00017EF4 File Offset: 0x000160F4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfuncreplace.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00017F24 File Offset: 0x00016124
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00017F2E File Offset: 0x0001612E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000239 RID: 569
		private bool _contentLoaded;
	}
}

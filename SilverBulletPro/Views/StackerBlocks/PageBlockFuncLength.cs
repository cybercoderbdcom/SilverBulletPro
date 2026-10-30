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
	// Token: 0x02000087 RID: 135
	public class PageBlockFuncLength : Page, IComponentConnector
	{
		// Token: 0x06000470 RID: 1136 RVA: 0x00017A97 File Offset: 0x00015C97
		public PageBlockFuncLength(BlockStrLength block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00017AAC File Offset: 0x00015CAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfunclength.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00017ADC File Offset: 0x00015CDC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00017AE6 File Offset: 0x00015CE6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000230 RID: 560
		private bool _contentLoaded;
	}
}

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
	// Token: 0x02000084 RID: 132
	public class PageBlockFuncCountOccurrences : Page, IComponentConnector
	{
		// Token: 0x06000464 RID: 1124 RVA: 0x0001798C File Offset: 0x00015B8C
		public PageBlockFuncCountOccurrences(BlockCountOccurrences block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x000179A4 File Offset: 0x00015BA4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfunccountoccurrences.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000179D4 File Offset: 0x00015BD4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x000179DE File Offset: 0x00015BDE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400022D RID: 557
		private bool _contentLoaded;
	}
}

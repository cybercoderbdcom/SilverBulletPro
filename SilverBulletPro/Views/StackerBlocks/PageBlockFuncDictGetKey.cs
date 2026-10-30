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
	// Token: 0x02000061 RID: 97
	public class PageBlockFuncDictGetKey : Page, IComponentConnector
	{
		// Token: 0x060003D6 RID: 982 RVA: 0x0001653F File Offset: 0x0001473F
		public PageBlockFuncDictGetKey(BlockDictGetKey block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00016554 File Offset: 0x00014754
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/dictionary/pageblockfuncdictgetkey.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x00016584 File Offset: 0x00014784
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0001658E File Offset: 0x0001478E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001EF RID: 495
		private bool _contentLoaded;
	}
}

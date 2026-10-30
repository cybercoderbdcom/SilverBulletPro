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
	// Token: 0x02000064 RID: 100
	public class PageBlockFuncDictionaryToString : Page, IComponentConnector
	{
		// Token: 0x060003E2 RID: 994 RVA: 0x00016647 File Offset: 0x00014847
		public PageBlockFuncDictionaryToString(BlockDictionaryToString block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0001665C File Offset: 0x0001485C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/dictionary/pageblockfuncdictionarytostring.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0001668C File Offset: 0x0001488C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00016696 File Offset: 0x00014896
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001F2 RID: 498
		private bool _contentLoaded;
	}
}

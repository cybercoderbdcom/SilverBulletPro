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
	// Token: 0x02000062 RID: 98
	public class PageBlockFuncDictGetValue : Page, IComponentConnector
	{
		// Token: 0x060003DA RID: 986 RVA: 0x00016597 File Offset: 0x00014797
		public PageBlockFuncDictGetValue(BlockDictGetValue block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000165AC File Offset: 0x000147AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/dictionary/pageblockfuncdictgetvalue.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x000165DC File Offset: 0x000147DC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x000165E6 File Offset: 0x000147E6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001F0 RID: 496
		private bool _contentLoaded;
	}
}

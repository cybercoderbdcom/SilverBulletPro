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
	// Token: 0x02000063 RID: 99
	public class PageBlockFuncDictionaryToList : Page, IComponentConnector
	{
		// Token: 0x060003DE RID: 990 RVA: 0x000165EF File Offset: 0x000147EF
		public PageBlockFuncDictionaryToList(BlockDictionaryToList block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00016604 File Offset: 0x00014804
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/dictionary/pageblockfuncdictionarytolist.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00016634 File Offset: 0x00014834
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0001663E File Offset: 0x0001483E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001F1 RID: 497
		private bool _contentLoaded;
	}
}

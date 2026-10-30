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
	// Token: 0x02000060 RID: 96
	public class PageBlockFuncAddKeyValuePair : Page, IComponentConnector
	{
		// Token: 0x060003D2 RID: 978 RVA: 0x000164E4 File Offset: 0x000146E4
		public PageBlockFuncAddKeyValuePair(BlockAddKeyValuePair block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x000164FC File Offset: 0x000146FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/dictionary/pageblockfuncaddkeyvaluepair.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0001652C File Offset: 0x0001472C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00016536 File Offset: 0x00014736
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001EE RID: 494
		private bool _contentLoaded;
	}
}

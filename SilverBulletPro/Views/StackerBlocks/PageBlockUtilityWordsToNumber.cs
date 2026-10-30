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
	// Token: 0x02000163 RID: 355
	public class PageBlockUtilityWordsToNumber : Page, IComponentConnector
	{
		// Token: 0x06000843 RID: 2115 RVA: 0x000243B3 File Offset: 0x000225B3
		public PageBlockUtilityWordsToNumber(BlockWordsToNumber block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x000243C8 File Offset: 0x000225C8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/conversion/pageblockutilitywordstonumber.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x000243F8 File Offset: 0x000225F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x00024402 File Offset: 0x00022602
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003D8 RID: 984
		private bool _contentLoaded;
	}
}

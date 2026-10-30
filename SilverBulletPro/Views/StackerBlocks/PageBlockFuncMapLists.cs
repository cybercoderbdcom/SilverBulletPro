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
	// Token: 0x0200007A RID: 122
	public class PageBlockFuncMapLists : Page, IComponentConnector
	{
		// Token: 0x0600043C RID: 1084 RVA: 0x0001746F File Offset: 0x0001566F
		public PageBlockFuncMapLists(BlockMapLists block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00017484 File Offset: 0x00015684
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncmaplists.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000174B4 File Offset: 0x000156B4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000174BE File Offset: 0x000156BE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400021F RID: 543
		private bool _contentLoaded;
	}
}

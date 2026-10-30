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
	// Token: 0x02000076 RID: 118
	public class PageBlockFuncGetRandomItem : Page, IComponentConnector
	{
		// Token: 0x0600042C RID: 1068 RVA: 0x0001730F File Offset: 0x0001550F
		public PageBlockFuncGetRandomItem(BlockGetRandomItem block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00017324 File Offset: 0x00015524
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfuncgetrandomitem.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00017354 File Offset: 0x00015554
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0001735E File Offset: 0x0001555E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400021B RID: 539
		private bool _contentLoaded;
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000083 RID: 131
	public class PageBlockFuncCharAt : Page, IComponentConnector
	{
		// Token: 0x06000460 RID: 1120 RVA: 0x00017920 File Offset: 0x00015B20
		public PageBlockFuncCharAt(BlockCharAt block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00017938 File Offset: 0x00015B38
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfunccharat.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00017968 File Offset: 0x00015B68
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00017972 File Offset: 0x00015B72
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.indexNum = (NumStrInputBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0400022B RID: 555
		internal NumStrInputBox indexNum;

		// Token: 0x0400022C RID: 556
		private bool _contentLoaded;
	}
}

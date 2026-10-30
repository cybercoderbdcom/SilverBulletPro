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
	// Token: 0x02000079 RID: 121
	public class PageBlockFuncListToDictionary : Page, IComponentConnector
	{
		// Token: 0x06000438 RID: 1080 RVA: 0x00017417 File Offset: 0x00015617
		public PageBlockFuncListToDictionary(BlockListToDictionary block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0001742C File Offset: 0x0001562C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/list/pageblockfunclisttodictionary.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0001745C File Offset: 0x0001565C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00017466 File Offset: 0x00015666
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400021E RID: 542
		private bool _contentLoaded;
	}
}

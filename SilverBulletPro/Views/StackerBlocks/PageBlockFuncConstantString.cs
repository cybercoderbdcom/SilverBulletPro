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
	// Token: 0x0200004E RID: 78
	public class PageBlockFuncConstantString : Page, IComponentConnector
	{
		// Token: 0x06000383 RID: 899 RVA: 0x00015352 File Offset: 0x00013552
		public PageBlockFuncConstantString(BlockConstantString block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00015368 File Offset: 0x00013568
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/constants/pageblockfuncconstantstring.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x00015398 File Offset: 0x00013598
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x000153A2 File Offset: 0x000135A2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001AE RID: 430
		private bool _contentLoaded;
	}
}

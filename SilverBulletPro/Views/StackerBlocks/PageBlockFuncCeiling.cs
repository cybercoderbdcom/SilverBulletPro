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
	// Token: 0x02000067 RID: 103
	public class PageBlockFuncCeiling : Page, IComponentConnector
	{
		// Token: 0x060003EF RID: 1007 RVA: 0x000168E4 File Offset: 0x00014AE4
		public PageBlockFuncCeiling(BlockCeiling block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl.Minimum = double.MinValue;
			this.inputControl.Maximum = double.MaxValue;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00016924 File Offset: 0x00014B24
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/float/pageblockfuncceiling.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00016954 File Offset: 0x00014B54
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0001695E File Offset: 0x00014B5E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.inputControl = (NumStrInputBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040001F9 RID: 505
		internal NumStrInputBox inputControl;

		// Token: 0x040001FA RID: 506
		private bool _contentLoaded;
	}
}

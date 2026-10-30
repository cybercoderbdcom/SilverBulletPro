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
	// Token: 0x02000069 RID: 105
	public class PageBlockFuncFloor : Page, IComponentConnector
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x00016A43 File Offset: 0x00014C43
		public PageBlockFuncFloor(BlockFloor block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl.Minimum = double.MinValue;
			this.inputControl.Maximum = double.MaxValue;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00016A80 File Offset: 0x00014C80
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/float/pageblockfuncfloor.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00016AB0 File Offset: 0x00014CB0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00016ABA File Offset: 0x00014CBA
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

		// Token: 0x040001FC RID: 508
		internal NumStrInputBox inputControl;

		// Token: 0x040001FD RID: 509
		private bool _contentLoaded;
	}
}

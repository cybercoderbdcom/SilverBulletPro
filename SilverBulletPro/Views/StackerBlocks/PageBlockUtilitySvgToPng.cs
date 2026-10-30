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
	// Token: 0x02000174 RID: 372
	public class PageBlockUtilitySvgToPng : Page, IComponentConnector
	{
		// Token: 0x06000893 RID: 2195 RVA: 0x000252E0 File Offset: 0x000234E0
		public PageBlockUtilitySvgToPng(BlockSvgToPng block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.inputControl1.Minimum = -2147483648.0;
			this.inputControl1.Maximum = 2147483647.0;
			this.inputControl2.Minimum = -2147483648.0;
			this.inputControl2.Maximum = 2147483647.0;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00025350 File Offset: 0x00023550
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/images/pageblockutilitysvgtopng.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00025380 File Offset: 0x00023580
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0002538A File Offset: 0x0002358A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.inputControl1 = (NumStrInputBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.inputControl2 = (NumStrInputBox)target;
		}

		// Token: 0x040003FD RID: 1021
		internal NumStrInputBox inputControl1;

		// Token: 0x040003FE RID: 1022
		internal NumStrInputBox inputControl2;

		// Token: 0x040003FF RID: 1023
		private bool _contentLoaded;
	}
}

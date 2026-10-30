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
	// Token: 0x02000058 RID: 88
	public class PageBlockFuncJwtEncode : Page, IComponentConnector
	{
		// Token: 0x060003AE RID: 942 RVA: 0x00015CA8 File Offset: 0x00013EA8
		public PageBlockFuncJwtEncode(BlockJwtEncode block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.algorithmBox.Items.Add(0);
			this.algorithmBox.Items.Add(1);
			this.algorithmBox.Items.Add(2);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00015D10 File Offset: 0x00013F10
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncjwtencode.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00015D40 File Offset: 0x00013F40
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00015D4A File Offset: 0x00013F4A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.outputVar = (VarCapOutputBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.algorithmBox = (ComboBox)target;
		}

		// Token: 0x040001CE RID: 462
		internal VarCapOutputBox outputVar;

		// Token: 0x040001CF RID: 463
		internal ComboBox algorithmBox;

		// Token: 0x040001D0 RID: 464
		private bool _contentLoaded;
	}
}

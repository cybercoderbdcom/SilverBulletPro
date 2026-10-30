using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Rebex.IO;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000DA RID: 218
	public class PageBlockReqsFtpDelete : Page, IComponentConnector
	{
		// Token: 0x060005E6 RID: 1510 RVA: 0x0001C9AC File Offset: 0x0001ABAC
		public PageBlockReqsFtpDelete(BlockFtpDelete block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(TraversalMode)))
			{
				TraversalMode traversalMode = (TraversalMode)obj;
				this.traversalModeBox.Items.Add(traversalMode);
			}
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0001CA34 File Offset: 0x0001AC34
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpdelete.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0001CA64 File Offset: 0x0001AC64
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0001CA6E File Offset: 0x0001AC6E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.traversalModeBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040002C4 RID: 708
		internal ComboBox traversalModeBox;

		// Token: 0x040002C5 RID: 709
		private bool _contentLoaded;
	}
}

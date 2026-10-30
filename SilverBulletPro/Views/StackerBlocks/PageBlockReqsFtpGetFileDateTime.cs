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
	// Token: 0x020000E2 RID: 226
	public class PageBlockReqsFtpGetFileDateTime : Page, IComponentConnector
	{
		// Token: 0x06000606 RID: 1542 RVA: 0x0001CEFF File Offset: 0x0001B0FF
		public PageBlockReqsFtpGetFileDateTime(BlockFtpGetFileDateTime block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0001CF14 File Offset: 0x0001B114
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpgetfiledatetime.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0001CF44 File Offset: 0x0001B144
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0001CF4E File Offset: 0x0001B14E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002D1 RID: 721
		private bool _contentLoaded;
	}
}

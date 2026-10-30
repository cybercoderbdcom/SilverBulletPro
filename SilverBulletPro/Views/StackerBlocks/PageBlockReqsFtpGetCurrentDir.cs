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
	// Token: 0x020000E1 RID: 225
	public class PageBlockReqsFtpGetCurrentDir : Page, IComponentConnector
	{
		// Token: 0x06000602 RID: 1538 RVA: 0x0001CEA7 File Offset: 0x0001B0A7
		public PageBlockReqsFtpGetCurrentDir(BlockFtpGetCurrentDirectory block)
		{
			this.InitializeComponent();
			base.DataContext = block;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0001CEBC File Offset: 0x0001B0BC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpgetcurrentdir.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0001CEEC File Offset: 0x0001B0EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0001CEF6 File Offset: 0x0001B0F6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002D0 RID: 720
		private bool _contentLoaded;
	}
}

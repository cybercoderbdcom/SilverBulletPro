using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000DE RID: 222
	public class PageBlockReqsFtpDownloadFile : Page, IComponentConnector
	{
		// Token: 0x060005F6 RID: 1526 RVA: 0x0001CD18 File Offset: 0x0001AF18
		public PageBlockReqsFtpDownloadFile(BlockFtpDownloadFile block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(FileMode)))
			{
				FileMode fileMode = (FileMode)obj;
				this.fileModeBox.Items.Add(fileMode);
			}
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0001CDA0 File Offset: 0x0001AFA0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpdownloadfile.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0001CDD0 File Offset: 0x0001AFD0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0001CDDA File Offset: 0x0001AFDA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.fileModeBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040002CC RID: 716
		internal ComboBox fileModeBox;

		// Token: 0x040002CD RID: 717
		private bool _contentLoaded;
	}
}

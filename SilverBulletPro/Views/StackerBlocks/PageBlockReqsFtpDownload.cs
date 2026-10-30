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
	// Token: 0x020000DD RID: 221
	public class PageBlockReqsFtpDownload : Page, IComponentConnector
	{
		// Token: 0x060005F2 RID: 1522 RVA: 0x0001CB3C File Offset: 0x0001AD3C
		public PageBlockReqsFtpDownload(BlockFtpDownload block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(TraversalMode)))
			{
				TraversalMode traversalMode = (TraversalMode)obj;
				this.traversalModeBox.Items.Add(traversalMode);
			}
			foreach (object obj2 in Enum.GetValues(typeof(TransferMethod)))
			{
				TransferMethod transferMethod = (TransferMethod)obj2;
				this.transferMethodBox.Items.Add(transferMethod);
			}
			foreach (object obj3 in Enum.GetValues(typeof(ActionOnExistingFiles)))
			{
				ActionOnExistingFiles actionOnExistingFiles = (ActionOnExistingFiles)obj3;
				this.actionOnExistingFilesBox.Items.Add(actionOnExistingFiles);
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001CC88 File Offset: 0x0001AE88
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpdownload.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0001CCB8 File Offset: 0x0001AEB8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0001CCC4 File Offset: 0x0001AEC4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.traversalModeBox = (ComboBox)target;
				return;
			case 2:
				this.transferMethodBox = (ComboBox)target;
				return;
			case 3:
				this.actionOnExistingFilesBox = (ComboBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040002C8 RID: 712
		internal ComboBox traversalModeBox;

		// Token: 0x040002C9 RID: 713
		internal ComboBox transferMethodBox;

		// Token: 0x040002CA RID: 714
		internal ComboBox actionOnExistingFilesBox;

		// Token: 0x040002CB RID: 715
		private bool _contentLoaded;
	}
}

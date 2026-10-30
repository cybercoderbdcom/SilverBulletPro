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
	// Token: 0x020000E8 RID: 232
	public class PageBlockReqsFtpUpload : Page, IComponentConnector
	{
		// Token: 0x0600061E RID: 1566 RVA: 0x0001D110 File Offset: 0x0001B310
		public PageBlockReqsFtpUpload(BlockFtpUpload block)
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

		// Token: 0x0600061F RID: 1567 RVA: 0x0001D25C File Offset: 0x0001B45C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/ftp/pageblockreqsftpupload.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0001D28C File Offset: 0x0001B48C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0001D298 File Offset: 0x0001B498
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

		// Token: 0x040002D7 RID: 727
		internal ComboBox traversalModeBox;

		// Token: 0x040002D8 RID: 728
		internal ComboBox transferMethodBox;

		// Token: 0x040002D9 RID: 729
		internal ComboBox actionOnExistingFilesBox;

		// Token: 0x040002DA RID: 730
		private bool _contentLoaded;
	}
}

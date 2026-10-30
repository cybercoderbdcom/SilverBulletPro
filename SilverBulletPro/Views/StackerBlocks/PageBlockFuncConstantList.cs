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
	// Token: 0x0200004D RID: 77
	public class PageBlockFuncConstantList : Page, IComponentConnector
	{
		// Token: 0x0600037D RID: 893 RVA: 0x000151FA File Offset: 0x000133FA
		public PageBlockFuncConstantList(BlockConstantList block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtValues.AddItems(block.Strings);
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00015220 File Offset: 0x00013420
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfoScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfoScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
			}
			catch
			{
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00015278 File Offset: 0x00013478
		private void Page_Unloaded(object sender, RoutedEventArgs e)
		{
			try
			{
				Action enableScrolling = GlobalData.MainWindow.ConfigsSecionPage.StackerPage.EnableScrolling;
				if (enableScrolling != null)
				{
					enableScrolling();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000152BC File Offset: 0x000134BC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/constants/pageblockfuncconstantlist.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000381 RID: 897 RVA: 0x000152EC File Offset: 0x000134EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000382 RID: 898 RVA: 0x000152F8 File Offset: 0x000134F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((PageBlockFuncConstantList)target).Loaded += this.Page_Loaded;
				((PageBlockFuncConstantList)target).Unloaded += this.Page_Unloaded;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.rtValues = (RichTextInputBox)target;
		}

		// Token: 0x040001AC RID: 428
		internal RichTextInputBox rtValues;

		// Token: 0x040001AD RID: 429
		private bool _contentLoaded;
	}
}

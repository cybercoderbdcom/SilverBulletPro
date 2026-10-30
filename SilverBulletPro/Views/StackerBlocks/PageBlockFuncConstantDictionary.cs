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
	// Token: 0x0200004C RID: 76
	public class PageBlockFuncConstantDictionary : Page, IComponentConnector
	{
		// Token: 0x06000377 RID: 887 RVA: 0x0001509F File Offset: 0x0001329F
		public PageBlockFuncConstantDictionary(BlockConstantDictionary block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtValues.AddItems(block.Dictionary);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x000150C8 File Offset: 0x000132C8
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

		// Token: 0x06000379 RID: 889 RVA: 0x00015120 File Offset: 0x00013320
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

		// Token: 0x0600037A RID: 890 RVA: 0x00015164 File Offset: 0x00013364
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/constants/pageblockfuncconstantdictionary.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00015194 File Offset: 0x00013394
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x000151A0 File Offset: 0x000133A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((PageBlockFuncConstantDictionary)target).Loaded += this.Page_Loaded;
				((PageBlockFuncConstantDictionary)target).Unloaded += this.Page_Unloaded;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.rtValues = (RichTextInputBox)target;
		}

		// Token: 0x040001AA RID: 426
		internal RichTextInputBox rtValues;

		// Token: 0x040001AB RID: 427
		private bool _contentLoaded;
	}
}

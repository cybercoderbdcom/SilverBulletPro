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
	// Token: 0x02000093 RID: 147
	public class PageBlockFuncTranslate : Page, IComponentConnector
	{
		// Token: 0x060004A3 RID: 1187 RVA: 0x00018303 File Offset: 0x00016503
		public PageBlockFuncTranslate(BlockTranslate block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtValues.AddItems(block.Translations);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0001832C File Offset: 0x0001652C
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

		// Token: 0x060004A5 RID: 1189 RVA: 0x00018384 File Offset: 0x00016584
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

		// Token: 0x060004A6 RID: 1190 RVA: 0x000183C8 File Offset: 0x000165C8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/string/pageblockfunctranslate.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x000183F8 File Offset: 0x000165F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00018402 File Offset: 0x00016602
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((PageBlockFuncTranslate)target).Unloaded += this.Page_Unloaded;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.rtValues = (RichTextInputBox)target;
		}

		// Token: 0x04000244 RID: 580
		internal RichTextInputBox rtValues;

		// Token: 0x04000245 RID: 581
		private bool _contentLoaded;
	}
}

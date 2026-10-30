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
	// Token: 0x020000A3 RID: 163
	public class PageBlockLambdaParser : Page, IComponentConnector
	{
		// Token: 0x060004F7 RID: 1271 RVA: 0x000199D7 File Offset: 0x00017BD7
		public PageBlockLambdaParser(BlockLambdaParser block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.rtContextVariables.AddItems(block.ContextVariables);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00019A00 File Offset: 0x00017C00
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

		// Token: 0x060004F9 RID: 1273 RVA: 0x00019A58 File Offset: 0x00017C58
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

		// Token: 0x060004FA RID: 1274 RVA: 0x00019A9C File Offset: 0x00017C9C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/parsing/pageblocklambdaparser.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00019ACC File Offset: 0x00017CCC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00019AD8 File Offset: 0x00017CD8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((PageBlockLambdaParser)target).Loaded += this.Page_Loaded;
				((PageBlockLambdaParser)target).Unloaded += this.Page_Unloaded;
				return;
			case 2:
				this.outputVar = (VarCapOutputBox)target;
				return;
			case 3:
				this.rtContextVariables = (RichTextInputBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000261 RID: 609
		internal VarCapOutputBox outputVar;

		// Token: 0x04000262 RID: 610
		internal RichTextInputBox rtContextVariables;

		// Token: 0x04000263 RID: 611
		private bool _contentLoaded;
	}
}

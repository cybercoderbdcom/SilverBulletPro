using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000178 RID: 376
	public class PageBlockUtilityTlgSendMessage : Page, IComponentConnector
	{
		// Token: 0x060008A3 RID: 2211 RVA: 0x000254C0 File Offset: 0x000236C0
		public PageBlockUtilityTlgSendMessage(BlockTlgSendMessage block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			this.rtInputBox.AddItems(block.Messages);
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x000254FC File Offset: 0x000236FC
		private void RadioButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string a = (sender as RadioButton).Tag.ToString();
				if (!(a == "Html"))
				{
					if (!(a == "Markdown"))
					{
						if (!(a == "MarkdownV2"))
						{
							this.vm.Mode = 0;
						}
						else
						{
							this.vm.Mode = 3;
						}
					}
					else
					{
						this.vm.Mode = 1;
					}
				}
				else
				{
					this.vm.Mode = 2;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00025590 File Offset: 0x00023790
		private void SetParseMode()
		{
			try
			{
				switch (this.vm.Mode)
				{
				case 1:
					this.rbMarkdown.IsChecked = new bool?(true);
					this.rbMarkdown.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
					break;
				case 2:
					this.rbHtml.IsChecked = new bool?(true);
					this.rbHtml.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
					break;
				case 3:
					this.rbMarkdownV2.IsChecked = new bool?(true);
					this.rbMarkdownV2.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
					break;
				default:
					this.rbDefault.IsChecked = new bool?(true);
					this.rbDefault.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
					break;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00025674 File Offset: 0x00023874
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (!this.initControls)
			{
				this.SetParseMode();
				this.initControls = true;
			}
			try
			{
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfoScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
				GlobalData.MainWindow.ConfigsSecionPage.StackerPage.BlockInfoScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
			}
			catch
			{
			}
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x000256E0 File Offset: 0x000238E0
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

		// Token: 0x060008A8 RID: 2216 RVA: 0x00025724 File Offset: 0x00023924
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/telegram/pageblockutilitytlgsendmessage.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00025754 File Offset: 0x00023954
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00025760 File Offset: 0x00023960
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((PageBlockUtilityTlgSendMessage)target).Loaded += this.Page_Loaded;
				((PageBlockUtilityTlgSendMessage)target).Unloaded += this.Page_Unloaded;
				return;
			case 2:
				this.rbDefault = (RadioButton)target;
				this.rbDefault.Click += this.RadioButton_Click;
				return;
			case 3:
				this.rbMarkdown = (RadioButton)target;
				this.rbMarkdown.Click += this.RadioButton_Click;
				return;
			case 4:
				this.rbHtml = (RadioButton)target;
				this.rbHtml.Click += this.RadioButton_Click;
				return;
			case 5:
				this.rbMarkdownV2 = (RadioButton)target;
				this.rbMarkdownV2.Click += this.RadioButton_Click;
				return;
			case 6:
				this.rtInputBox = (RichTextInputBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000403 RID: 1027
		private BlockTlgSendMessage vm;

		// Token: 0x04000404 RID: 1028
		private bool initControls;

		// Token: 0x04000405 RID: 1029
		internal RadioButton rbDefault;

		// Token: 0x04000406 RID: 1030
		internal RadioButton rbMarkdown;

		// Token: 0x04000407 RID: 1031
		internal RadioButton rbHtml;

		// Token: 0x04000408 RID: 1032
		internal RadioButton rbMarkdownV2;

		// Token: 0x04000409 RID: 1033
		internal RichTextInputBox rtInputBox;

		// Token: 0x0400040A RID: 1034
		private bool _contentLoaded;
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Models;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000170 RID: 368
	public class PageBlockUtilityFileWriteLines : Page, IComponentConnector
	{
		// Token: 0x06000881 RID: 2177 RVA: 0x00024F48 File Offset: 0x00023148
		public PageBlockUtilityFileWriteLines(BlockFileWriteLines block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			foreach (EncodingInfo encodingInfo in Encoding.GetEncodings())
			{
				this.encodingComboBox.Items.Add(new EncodeModel
				{
					Info = encodingInfo,
					Name = encodingInfo.Name,
					DisplayName = encodingInfo.DisplayName
				});
			}
			this.encodingComboBox.SelectedItem = this.encodingComboBox.Items.Cast<EncodeModel>().FirstOrDefault((EncodeModel e) => e.Name.ToUpper() == this.vm.StringEncoding.BodyName.ToUpper());
			this.rtLines.AddItems(block.Contents);
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x00024FFC File Offset: 0x000231FC
		private void EncodingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				EncodeModel encodeModel = this.encodingComboBox.SelectedItem as EncodeModel;
				int codepage;
				if (int.TryParse(encodeModel.Name, out codepage))
				{
					this.vm.StringEncoding = Encoding.GetEncoding(codepage);
				}
				else
				{
					this.vm.StringEncoding = Encoding.GetEncoding(encodeModel.Name);
				}
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00025070 File Offset: 0x00023270
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfilewritelines.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x000250A0 File Offset: 0x000232A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x000250AC File Offset: 0x000232AC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.rtLines = (RichTextInputBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.encodingComboBox = (ComboBox)target;
			this.encodingComboBox.SelectionChanged += this.EncodingComboBox_SelectionChanged;
		}

		// Token: 0x040003F3 RID: 1011
		private BlockFileWriteLines vm;

		// Token: 0x040003F4 RID: 1012
		internal RichTextInputBox rtLines;

		// Token: 0x040003F5 RID: 1013
		internal ComboBox encodingComboBox;

		// Token: 0x040003F6 RID: 1014
		private bool _contentLoaded;
	}
}

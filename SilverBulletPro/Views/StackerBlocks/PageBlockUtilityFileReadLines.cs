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

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x0200016D RID: 365
	public class PageBlockUtilityFileReadLines : Page, IComponentConnector
	{
		// Token: 0x06000871 RID: 2161 RVA: 0x00024B98 File Offset: 0x00022D98
		public PageBlockUtilityFileReadLines(BlockFileReadLines block)
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
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00024C3C File Offset: 0x00022E3C
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

		// Token: 0x06000873 RID: 2163 RVA: 0x00024CB0 File Offset: 0x00022EB0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfilereadlines.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00024CE0 File Offset: 0x00022EE0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00024CEA File Offset: 0x00022EEA
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.encodingComboBox = (ComboBox)target;
				this.encodingComboBox.SelectionChanged += this.EncodingComboBox_SelectionChanged;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040003EC RID: 1004
		private BlockFileReadLines vm;

		// Token: 0x040003ED RID: 1005
		internal ComboBox encodingComboBox;

		// Token: 0x040003EE RID: 1006
		private bool _contentLoaded;
	}
}

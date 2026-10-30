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
	// Token: 0x0200016B RID: 363
	public class PageBlockUtilityFileRead : Page, IComponentConnector
	{
		// Token: 0x06000867 RID: 2151 RVA: 0x00024994 File Offset: 0x00022B94
		public PageBlockUtilityFileRead(BlockFileRead block)
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

		// Token: 0x06000868 RID: 2152 RVA: 0x00024A38 File Offset: 0x00022C38
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

		// Token: 0x06000869 RID: 2153 RVA: 0x00024AAC File Offset: 0x00022CAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfileread.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00024ADC File Offset: 0x00022CDC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00024AE6 File Offset: 0x00022CE6
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

		// Token: 0x040003E8 RID: 1000
		private BlockFileRead vm;

		// Token: 0x040003E9 RID: 1001
		internal ComboBox encodingComboBox;

		// Token: 0x040003EA RID: 1002
		private bool _contentLoaded;
	}
}

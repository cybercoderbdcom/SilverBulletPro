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
	// Token: 0x0200016E RID: 366
	public class PageBlockUtilityFileWrite : Page, IComponentConnector
	{
		// Token: 0x06000877 RID: 2167 RVA: 0x00024D44 File Offset: 0x00022F44
		public PageBlockUtilityFileWrite(BlockFileWrite block)
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

		// Token: 0x06000878 RID: 2168 RVA: 0x00024DE8 File Offset: 0x00022FE8
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

		// Token: 0x06000879 RID: 2169 RVA: 0x00024E5C File Offset: 0x0002305C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfilewrite.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00024E8C File Offset: 0x0002308C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00024E96 File Offset: 0x00023096
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

		// Token: 0x040003EF RID: 1007
		private BlockFileWrite vm;

		// Token: 0x040003F0 RID: 1008
		internal ComboBox encodingComboBox;

		// Token: 0x040003F1 RID: 1009
		private bool _contentLoaded;
	}
}

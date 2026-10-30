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
	// Token: 0x02000165 RID: 357
	public class PageBlockUtilityFileAppend : Page, IComponentConnector
	{
		// Token: 0x0600084B RID: 2123 RVA: 0x0002447C File Offset: 0x0002267C
		public PageBlockUtilityFileAppend(BlockFileAppend block)
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

		// Token: 0x0600084C RID: 2124 RVA: 0x00024520 File Offset: 0x00022720
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

		// Token: 0x0600084D RID: 2125 RVA: 0x00024594 File Offset: 0x00022794
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilityfileappend.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x000245C4 File Offset: 0x000227C4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x000245CE File Offset: 0x000227CE
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

		// Token: 0x040003DB RID: 987
		private BlockFileAppend vm;

		// Token: 0x040003DC RID: 988
		internal ComboBox encodingComboBox;

		// Token: 0x040003DD RID: 989
		private bool _contentLoaded;
	}
}

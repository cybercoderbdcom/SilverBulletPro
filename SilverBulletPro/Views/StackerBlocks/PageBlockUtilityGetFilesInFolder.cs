using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000173 RID: 371
	public class PageBlockUtilityGetFilesInFolder : Page, IComponentConnector
	{
		// Token: 0x0600088F RID: 2191 RVA: 0x000251EC File Offset: 0x000233EC
		public PageBlockUtilityGetFilesInFolder(BlockGetFilesInFolder block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			foreach (object newItem in Enum.GetValues(typeof(SearchOption)))
			{
				this.searchOptionComboBox.Items.Add(newItem);
			}
			this.searchOptionComboBox.SelectedItem = this.vm.SearchOption;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0002528C File Offset: 0x0002348C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/utility/files/pageblockutilitygetfilesinfolder.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x000252BC File Offset: 0x000234BC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x000252C6 File Offset: 0x000234C6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.searchOptionComboBox = (ComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040003FA RID: 1018
		private BlockGetFilesInFolder vm;

		// Token: 0x040003FB RID: 1019
		internal ComboBox searchOptionComboBox;

		// Token: 0x040003FC RID: 1020
		private bool _contentLoaded;
	}
}

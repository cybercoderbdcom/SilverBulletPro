using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Blocks;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000065 RID: 101
	public class PageBlockFuncDictRemove : Page, IComponentConnector
	{
		// Token: 0x060003E6 RID: 998 RVA: 0x000166A0 File Offset: 0x000148A0
		public PageBlockFuncDictRemove(BlockDictRemove blcok)
		{
			this.InitializeComponent();
			foreach (object obj in Enum.GetValues(typeof(DictRemoveType)))
			{
				DictRemoveType dictRemoveType = (DictRemoveType)obj;
				this.removeTypeBox.Items.Add(EnumExtension.GetDescription(dictRemoveType));
			}
			this.vm = blcok;
			base.DataContext = blcok;
			try
			{
				this.removeTypeBox.SelectedIndex = this.vm.DictRemoveType;
			}
			catch
			{
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0001675C File Offset: 0x0001495C
		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				int selectedIndex = this.removeTypeBox.SelectedIndex;
				if (selectedIndex != 0)
				{
					if (selectedIndex == 1)
					{
						this.inputControl.Label = EnumExtension.GetDescription(1);
						this.vm.DictRemoveType = this.removeTypeBox.SelectedIndex;
					}
				}
				else
				{
					this.inputControl.Label = EnumExtension.GetDescription(0);
					this.vm.DictRemoveType = this.removeTypeBox.SelectedIndex;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x000167F0 File Offset: 0x000149F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/dictionary/pageblockfuncdictremove.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00016820 File Offset: 0x00014A20
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0001682C File Offset: 0x00014A2C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.inputControl = (TextInputBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.removeTypeBox = (ComboBox)target;
			this.removeTypeBox.SelectionChanged += this.ComboBox_SelectionChanged;
		}

		// Token: 0x040001F3 RID: 499
		private BlockDictRemove vm;

		// Token: 0x040001F4 RID: 500
		private TextInputBox inputControl;

		// Token: 0x040001F5 RID: 501
		internal ComboBox removeTypeBox;

		// Token: 0x040001F6 RID: 502
		private bool _contentLoaded;
	}
}

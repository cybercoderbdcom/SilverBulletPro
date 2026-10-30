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
using SilverBulletPro.Core.Functions.Crypto;
using SilverBulletPro.Views.UserControls;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000055 RID: 85
	public class PageBlockFuncHash : Page, IComponentConnector
	{
		// Token: 0x0600039F RID: 927 RVA: 0x0001582C File Offset: 0x00013A2C
		public PageBlockFuncHash(BlockHash block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(HashFunc)))
			{
				HashFunc hashFunc = (HashFunc)obj;
				this.hashFuncBox.Items.Add(EnumExtension.GetDescription(hashFunc));
			}
			this.hashFuncBox.SelectedIndex = this.vm.HashFunc;
			this.keyControl.Visibility = ((this.vm.HashFunc == 16) ? Visibility.Visible : Visibility.Collapsed);
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x000158F4 File Offset: 0x00013AF4
		private void HashFuncBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.vm.HashFunc = this.hashFuncBox.SelectedIndex;
			}
			catch
			{
			}
			if (this.vm.HashFunc == 11)
			{
				this.inputControl.ModesOfInput = new InputMode?(51);
			}
			else
			{
				this.inputControl.ModesOfInput = new InputMode?(63);
			}
			this.keyControl.Visibility = ((this.vm.HashFunc == 16) ? Visibility.Visible : Visibility.Collapsed);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00015980 File Offset: 0x00013B80
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfunchash.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x000159B0 File Offset: 0x00013BB0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x000159BC File Offset: 0x00013BBC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.outputVar = (VarCapOutputBox)target;
				return;
			case 2:
				this.inputControl = (TextInputBox)target;
				return;
			case 3:
				this.keyControl = (TextInputBox)target;
				return;
			case 4:
				this.hashFuncBox = (ComboBox)target;
				this.hashFuncBox.SelectionChanged += this.HashFuncBox_SelectionChanged;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040001C0 RID: 448
		private BlockHash vm;

		// Token: 0x040001C1 RID: 449
		internal VarCapOutputBox outputVar;

		// Token: 0x040001C2 RID: 450
		internal TextInputBox inputControl;

		// Token: 0x040001C3 RID: 451
		internal TextInputBox keyControl;

		// Token: 0x040001C4 RID: 452
		internal ComboBox hashFuncBox;

		// Token: 0x040001C5 RID: 453
		private bool _contentLoaded;
	}
}

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
	// Token: 0x0200005A RID: 90
	public class PageBlockFuncRsaDecrypt : Page, IComponentConnector
	{
		// Token: 0x060003B8 RID: 952 RVA: 0x00015F50 File Offset: 0x00014150
		public PageBlockFuncRsaDecrypt(BlockRsaDecrypt block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			this.CheckBox_Click(null, null);
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00015F84 File Offset: 0x00014184
		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.vm.XmlParam)
				{
					this.dParamControl.Visibility = (this.modulusControl.Visibility = Visibility.Collapsed);
					this.xmlParamControl.Visibility = Visibility.Visible;
				}
				else
				{
					this.dParamControl.Visibility = (this.modulusControl.Visibility = Visibility.Visible);
					this.xmlParamControl.Visibility = Visibility.Collapsed;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00016004 File Offset: 0x00014204
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncrsadecrypt.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x00016034 File Offset: 0x00014234
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00016040 File Offset: 0x00014240
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
				this.modulusControl = (TextInputBox)target;
				return;
			case 3:
				this.dParamControl = (TextInputBox)target;
				return;
			case 4:
				this.xmlParamControl = (TextInputBox)target;
				return;
			case 5:
				((CheckBox)target).Click += this.CheckBox_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040001D5 RID: 469
		private BlockRsaDecrypt vm;

		// Token: 0x040001D6 RID: 470
		internal VarCapOutputBox outputVar;

		// Token: 0x040001D7 RID: 471
		internal TextInputBox modulusControl;

		// Token: 0x040001D8 RID: 472
		internal TextInputBox dParamControl;

		// Token: 0x040001D9 RID: 473
		internal TextInputBox xmlParamControl;

		// Token: 0x040001DA RID: 474
		private bool _contentLoaded;
	}
}

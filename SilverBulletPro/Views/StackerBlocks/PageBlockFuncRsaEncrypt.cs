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
	// Token: 0x0200005C RID: 92
	public class PageBlockFuncRsaEncrypt : Page, IComponentConnector
	{
		// Token: 0x060003C1 RID: 961 RVA: 0x000161E4 File Offset: 0x000143E4
		public PageBlockFuncRsaEncrypt(BlockRsaEncrypt block)
		{
			this.InitializeComponent();
			this.vm = block;
			base.DataContext = block;
			this.CheckBox_Click(null, null);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00016218 File Offset: 0x00014418
		private void CheckBox_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.vm.XmlParam)
				{
					this.exponentControl.Visibility = (this.modulusControl.Visibility = Visibility.Collapsed);
					this.xmlParamControl.Visibility = Visibility.Visible;
				}
				else
				{
					this.exponentControl.Visibility = (this.modulusControl.Visibility = Visibility.Visible);
					this.xmlParamControl.Visibility = Visibility.Collapsed;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00016298 File Offset: 0x00014498
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/functions/crypto/pageblockfuncrsaencrypt.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x000162C8 File Offset: 0x000144C8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x000162D4 File Offset: 0x000144D4
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
				this.exponentControl = (TextInputBox)target;
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

		// Token: 0x040001DF RID: 479
		private BlockRsaEncrypt vm;

		// Token: 0x040001E0 RID: 480
		internal VarCapOutputBox outputVar;

		// Token: 0x040001E1 RID: 481
		internal TextInputBox modulusControl;

		// Token: 0x040001E2 RID: 482
		internal TextInputBox exponentControl;

		// Token: 0x040001E3 RID: 483
		internal TextInputBox xmlParamControl;

		// Token: 0x040001E4 RID: 484
		private bool _contentLoaded;
	}
}

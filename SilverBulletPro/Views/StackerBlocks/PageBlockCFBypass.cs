using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x020000EA RID: 234
	public class PageBlockCFBypass : Page, IComponentConnector
	{
		// Token: 0x06000626 RID: 1574 RVA: 0x0001D354 File Offset: 0x0001B554
		public PageBlockCFBypass(BlockCFBypass block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			this.methodComboBox.Items.Add(0);
			this.methodComboBox.Items.Add(4);
			this.contentTypeComboBox.Items.Add("application/x-www-form-urlencoded");
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0001D3B8 File Offset: 0x0001B5B8
		private void MethodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0001D3BA File Offset: 0x0001B5BA
		private void CustomCookiesRTB_LostFocus(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001D3BC File Offset: 0x0001B5BC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/requests/http/pageblockcfbypass.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0001D3EC File Offset: 0x0001B5EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0001D3F8 File Offset: 0x0001B5F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.methodComboBox = (ComboBox)target;
				this.methodComboBox.SelectionChanged += this.MethodComboBox_SelectionChanged;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.contentTypeComboBox = (ComboBox)target;
		}

		// Token: 0x040002DD RID: 733
		internal ComboBox methodComboBox;

		// Token: 0x040002DE RID: 734
		internal ComboBox contentTypeComboBox;

		// Token: 0x040002DF RID: 735
		private bool _contentLoaded;
	}
}

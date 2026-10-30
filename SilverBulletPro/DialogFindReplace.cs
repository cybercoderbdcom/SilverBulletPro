using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using HandyControl.Controls;
using SilverBulletPro.FindReplace;

namespace SilverBulletPro
{
	// Token: 0x02000023 RID: 35
	public class DialogFindReplace : GlowWindow, IComponentConnector
	{
		// Token: 0x06000137 RID: 311 RVA: 0x0000A88C File Offset: 0x00008A8C
		public DialogFindReplace(FindReplaceMgr findReplaceMgr)
		{
			this.InitializeComponent();
			base.Owner = Application.Current.MainWindow;
			this.vm = findReplaceMgr;
			base.DataContext = findReplaceMgr;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000A8C5 File Offset: 0x00008AC5
		private void FindNextClick(object sender, RoutedEventArgs e)
		{
			this.vm.FindNext(false);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000A8D3 File Offset: 0x00008AD3
		private void ReplaceClick(object sender, RoutedEventArgs e)
		{
			this.vm.Replace();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000A8E0 File Offset: 0x00008AE0
		private void ReplaceAllClick(object sender, RoutedEventArgs e)
		{
			this.vm.ReplaceAll(true);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000A8EE File Offset: 0x00008AEE
		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000A900 File Offset: 0x00008B00
		public static void ShowFind(FindReplaceMgr findReplaceMgr)
		{
			if (findReplaceMgr.OwnerWindow == null)
			{
				findReplaceMgr.OwnerWindow = Application.Current.MainWindow;
			}
			findReplaceMgr.AllowReplace = false;
			findReplaceMgr.Dialog.tabReplace.Visibility = Visibility.Collapsed;
			findReplaceMgr.Dialog.tabFind.Visibility = Visibility.Visible;
			findReplaceMgr.ShowAsFind("Find");
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000A95C File Offset: 0x00008B5C
		public static void ShowReplace(FindReplaceMgr findReplaceMgr)
		{
			if (findReplaceMgr.OwnerWindow == null)
			{
				findReplaceMgr.OwnerWindow = Application.Current.MainWindow;
			}
			findReplaceMgr.AllowReplace = true;
			findReplaceMgr.Dialog.tabFind.Visibility = Visibility.Collapsed;
			findReplaceMgr.Dialog.tabReplace.Visibility = Visibility.Visible;
			findReplaceMgr.ShowAsReplace("Replace");
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000A9B8 File Offset: 0x00008BB8
		public static void ShowFindReplace(FindReplaceMgr findReplaceMgr, bool selectReplaceTab = false)
		{
			if (findReplaceMgr.OwnerWindow == null)
			{
				findReplaceMgr.OwnerWindow = Application.Current.MainWindow;
			}
			findReplaceMgr.Dialog.tabFind.Visibility = Visibility.Visible;
			findReplaceMgr.Dialog.tabReplace.Visibility = Visibility.Visible;
			if (!selectReplaceTab)
			{
				findReplaceMgr.ShowAsFind("");
				return;
			}
			findReplaceMgr.ShowAsReplace("");
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000AA19 File Offset: 0x00008C19
		private static object GetEditor(IEnumerable editors)
		{
			IEnumerator enumerator = editors.GetEnumerator();
			enumerator.MoveNext();
			return enumerator.Current;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000AA30 File Offset: 0x00008C30
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogfindreplace.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000AA60 File Offset: 0x00008C60
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((DialogFindReplace)target).KeyDown += this.Window_KeyDown;
				return;
			case 2:
				this.tabMain = (TabControl)target;
				return;
			case 3:
				this.tabFind = (TabItem)target;
				return;
			case 4:
				this.txtFind = (TextBox)target;
				return;
			case 5:
				((Button)target).Click += this.FindNextClick;
				return;
			case 6:
				this.tabReplace = (TabItem)target;
				return;
			case 7:
				this.txtFind2 = (TextBox)target;
				return;
			case 8:
				this.txtReplace = (TextBox)target;
				return;
			case 9:
				((Button)target).Click += this.FindNextClick;
				return;
			case 10:
				((Button)target).Click += this.ReplaceClick;
				return;
			case 11:
				((Button)target).Click += this.ReplaceAllClick;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0400009C RID: 156
		public FindReplaceMgr vm;

		// Token: 0x0400009D RID: 157
		internal TabControl tabMain;

		// Token: 0x0400009E RID: 158
		internal TabItem tabFind;

		// Token: 0x0400009F RID: 159
		internal TextBox txtFind;

		// Token: 0x040000A0 RID: 160
		internal TabItem tabReplace;

		// Token: 0x040000A1 RID: 161
		internal TextBox txtFind2;

		// Token: 0x040000A2 RID: 162
		internal TextBox txtReplace;

		// Token: 0x040000A3 RID: 163
		private bool _contentLoaded;
	}
}

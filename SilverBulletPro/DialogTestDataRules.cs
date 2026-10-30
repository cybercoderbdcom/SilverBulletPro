using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using SilverBulletPro.Core.Models;
using SilverBulletPro.ViewModels;

namespace SilverBulletPro
{
	// Token: 0x0200002D RID: 45
	public class DialogTestDataRules : Page, IComponentConnector
	{
		// Token: 0x06000198 RID: 408 RVA: 0x0000CE13 File Offset: 0x0000B013
		public DialogTestDataRules(string testData, string wordlistType, IEnumerable<DataRule> rules)
		{
			this.vm = new TestDataRulesDialogViewModel(testData, wordlistType, rules);
			base.DataContext = this.vm;
			this.InitializeComponent();
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000CE3C File Offset: 0x0000B03C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogtestdatarules.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000CE6C File Offset: 0x0000B06C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040000D4 RID: 212
		private readonly TestDataRulesDialogViewModel vm;

		// Token: 0x040000D5 RID: 213
		private bool _contentLoaded;
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using CaptchaSharp.Enums;
using SilverBulletPro.Core.Blocks;

namespace SilverBulletPro.Views.StackerBlocks
{
	// Token: 0x02000154 RID: 340
	public class PageBlockSolveTextCaptcha : Page, IComponentConnector
	{
		// Token: 0x06000807 RID: 2055 RVA: 0x00023C6C File Offset: 0x00021E6C
		public PageBlockSolveTextCaptcha(BlockSolveTextCaptcha block)
		{
			this.InitializeComponent();
			base.DataContext = block;
			foreach (object obj in Enum.GetValues(typeof(CaptchaLanguageGroup)))
			{
				CaptchaLanguageGroup captchaLanguageGroup = (CaptchaLanguageGroup)obj;
				this.langGroupComboBox.Items.Add(captchaLanguageGroup);
			}
			foreach (object obj2 in Enum.GetValues(typeof(CaptchaLanguage)))
			{
				CaptchaLanguage captchaLanguage = (CaptchaLanguage)obj2;
				this.langComboBox.Items.Add(captchaLanguage);
			}
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x00023D54 File Offset: 0x00021F54
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblocksolvetextcaptcha.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00023D84 File Offset: 0x00021F84
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00023D8E File Offset: 0x00021F8E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.langGroupComboBox = (ComboBox)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.langComboBox = (ComboBox)target;
		}

		// Token: 0x040003BC RID: 956
		internal ComboBox langGroupComboBox;

		// Token: 0x040003BD RID: 957
		internal ComboBox langComboBox;

		// Token: 0x040003BE RID: 958
		private bool _contentLoaded;
	}
}

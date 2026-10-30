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
	// Token: 0x02000150 RID: 336
	public class PageBlockSolveImageCaptcha : Page, IComponentConnector
	{
		// Token: 0x060007F7 RID: 2039 RVA: 0x00023950 File Offset: 0x00021B50
		public PageBlockSolveImageCaptcha(BlockSolveImageCaptcha block)
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
			foreach (object obj3 in Enum.GetValues(typeof(CharacterSet)))
			{
				CharacterSet characterSet = (CharacterSet)obj3;
				this.characterSetComboBox.Items.Add(characterSet);
			}
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00023A9C File Offset: 0x00021C9C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/stackerblocks/solvers/pageblocksolveimagecaptcha.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00023ACC File Offset: 0x00021CCC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x00023AD8 File Offset: 0x00021CD8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.langGroupComboBox = (ComboBox)target;
				return;
			case 2:
				this.langComboBox = (ComboBox)target;
				return;
			case 3:
				this.characterSetComboBox = (ComboBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040003B4 RID: 948
		internal ComboBox langGroupComboBox;

		// Token: 0x040003B5 RID: 949
		internal ComboBox langComboBox;

		// Token: 0x040003B6 RID: 950
		internal ComboBox characterSetComboBox;

		// Token: 0x040003B7 RID: 951
		private bool _contentLoaded;
	}
}

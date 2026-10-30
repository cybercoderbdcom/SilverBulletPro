using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace SilverBulletPro.Views.Dialogs
{
	// Token: 0x020001A8 RID: 424
	public partial class CustomInputDialog : Page
	{
		// Token: 0x06000BDA RID: 3034 RVA: 0x00040484 File Offset: 0x0003E684
		public CustomInputDialog(string question, IEnumerable defaultAnswer, Action<string> onAnswer)
		{
			this.OnAnswer = onAnswer;
			this.InitializeComponent();
			this.blockQuestion.Text = question;
			this.answerComboBox.ItemsSource = defaultAnswer;
			this.answerComboBox.SelectedIndex = 0;
			this.answerComboBox.Focus();
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x000404D4 File Offset: 0x0003E6D4
		private void Ok_Click(object sender, RoutedEventArgs e)
		{
			this.OnAnswer(this.answerComboBox.Text);
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x000404FC File Offset: 0x0003E6FC
		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x00040510 File Offset: 0x0003E710
		private void Border_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Return)
				{
					this.Ok_Click(sender, e);
				}
			}
			catch
			{
			}
		}

		// Token: 0x040005E8 RID: 1512
		private readonly Action<string> OnAnswer;
	}
}

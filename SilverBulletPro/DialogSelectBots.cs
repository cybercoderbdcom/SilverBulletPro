using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using SilverBulletPro.Core.Runners;

namespace SilverBulletPro
{
	// Token: 0x02000026 RID: 38
	public class DialogSelectBots : Page, IComponentConnector
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0000B0F3 File Offset: 0x000092F3
		// (set) Token: 0x06000152 RID: 338 RVA: 0x0000B0FB File Offset: 0x000092FB
		public object Caller { get; set; }

		// Token: 0x06000153 RID: 339 RVA: 0x0000B104 File Offset: 0x00009304
		public DialogSelectBots(object caller, int initial = 1)
		{
			this.InitializeComponent();
			this.Caller = caller;
			this.botsNumberTextbox.Text = initial.ToString();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000B12C File Offset: 0x0000932C
		private void selectButton_Click(object sender, RoutedEventArgs e)
		{
			int botsAmount = 1;
			int.TryParse(this.botsNumberTextbox.Text, out botsAmount);
			if (this.Caller.GetType() == typeof(RunnerViewModel))
			{
				(this.Caller as RunnerViewModel).Options.BotsAmount = botsAmount;
			}
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000B190 File Offset: 0x00009390
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				this.botsNumberTextbox.CaretIndex = this.botsNumberTextbox.Text.Length;
				this.botsNumberTextbox.Focus();
			}
			catch
			{
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000B1DC File Offset: 0x000093DC
		private void botsNumberTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			try
			{
				Regex regex = new Regex("[^0-9]+");
				e.Handled = regex.IsMatch(e.Text);
				if (!e.Handled)
				{
					TextBox textBox = (TextBox)sender;
					string str = textBox.Text;
					if (textBox.SelectedText != string.Empty)
					{
						str = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectedText.Length);
					}
					int num = int.Parse(str + e.Text);
					e.Handled = (num > 200 || num <= 0);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000B28C File Offset: 0x0000948C
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Return)
				{
					this.selectButton_Click(null, null);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000B2C0 File Offset: 0x000094C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogselectbots.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000B2F0 File Offset: 0x000094F0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((DialogSelectBots)target).KeyDown += this.Page_KeyDown;
				((DialogSelectBots)target).Loaded += this.Page_Loaded;
				return;
			case 2:
				this.botsNumberTextbox = (TextBox)target;
				this.botsNumberTextbox.PreviewTextInput += this.botsNumberTextbox_PreviewTextInput;
				return;
			case 3:
				this.selectButton = (Button)target;
				this.selectButton.Click += this.selectButton_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000AF RID: 175
		internal TextBox botsNumberTextbox;

		// Token: 0x040000B0 RID: 176
		internal Button selectButton;

		// Token: 0x040000B1 RID: 177
		private bool _contentLoaded;
	}
}

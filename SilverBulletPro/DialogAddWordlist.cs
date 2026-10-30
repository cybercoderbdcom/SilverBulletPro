using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.Win32;
using SilverBulletPro.Core.Models;
using SilverBulletPro.Views.Main;

namespace SilverBulletPro
{
	// Token: 0x02000020 RID: 32
	public class DialogAddWordlist : Page, IComponentConnector
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00009F2E File Offset: 0x0000812E
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00009F36 File Offset: 0x00008136
		public object Caller { get; set; }

		// Token: 0x0600011B RID: 283 RVA: 0x00009F40 File Offset: 0x00008140
		public DialogAddWordlist(object caller)
		{
			this.InitializeComponent();
			this.Caller = caller;
			foreach (string newItem in GlobalData.Settings.Environment.GetWordlistTypeNames())
			{
				this.typeCombobox.Items.Add(newItem);
			}
			this.typeCombobox.SelectedIndex = 0;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00009FC8 File Offset: 0x000081C8
		private void acceptButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.Caller.GetType() == typeof(WordlistManager))
			{
				if (this.nameTextbox.Text.Trim() == string.Empty)
				{
					Alert.Error("The name cannot be blank", "Error", false);
					return;
				}
				string text = this.locationTextbox.Text;
				string currentDirectory = Directory.GetCurrentDirectory();
				if (text.StartsWith(currentDirectory))
				{
					text = text.Substring(currentDirectory.Length + 1);
				}
				Wordlist wordlist = new Wordlist(this.nameTextbox.Text, text, this.typeCombobox.Text, this.purposeTextbox.Text, true, false, false);
				((WordlistManager)this.Caller).AddWordlist(wordlist);
			}
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000A098 File Offset: 0x00008298
		private void OpenWordlistButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Wordlist files | *.txt";
			openFileDialog.FilterIndex = 1;
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = false;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				return;
			}
			this.locationTextbox.Text = openFileDialog.FileName;
			if (string.IsNullOrWhiteSpace(this.nameTextbox.Text))
			{
				this.nameTextbox.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
			}
			try
			{
				string text = File.ReadLines(openFileDialog.FileName).First<string>();
				this.typeCombobox.Text = GlobalData.Settings.Environment.RecognizeWordlistType(text);
			}
			catch
			{
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000A158 File Offset: 0x00008358
		private void TextBox_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
					if (array != null && array.Length != 0 && File.Exists(array[0]) && Path.GetExtension(array[0]).ToLower() == ".txt")
					{
						((TextBox)sender).Text = array[0];
						if (string.IsNullOrWhiteSpace(this.nameTextbox.Text))
						{
							this.nameTextbox.Text = Path.GetFileNameWithoutExtension(array[0]);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000A200 File Offset: 0x00008400
		private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000A209 File Offset: 0x00008409
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.acceptButton_Click(this, new RoutedEventArgs());
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000A220 File Offset: 0x00008420
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogaddwordlist.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000A250 File Offset: 0x00008450
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((DialogAddWordlist)target).KeyDown += this.Page_KeyDown;
				return;
			case 2:
				this.locationTextbox = (TextBox)target;
				this.locationTextbox.Drop += this.TextBox_Drop;
				this.locationTextbox.PreviewDragOver += this.TextBox_PreviewDragOver;
				return;
			case 3:
				((Button)target).Click += this.OpenWordlistButton_Click;
				return;
			case 4:
				this.nameTextbox = (TextBox)target;
				return;
			case 5:
				this.typeCombobox = (ComboBox)target;
				return;
			case 6:
				this.purposeTextbox = (TextBox)target;
				return;
			case 7:
				this.acceptButton = (Button)target;
				this.acceptButton.Click += this.acceptButton_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000089 RID: 137
		internal TextBox locationTextbox;

		// Token: 0x0400008A RID: 138
		internal TextBox nameTextbox;

		// Token: 0x0400008B RID: 139
		internal ComboBox typeCombobox;

		// Token: 0x0400008C RID: 140
		internal TextBox purposeTextbox;

		// Token: 0x0400008D RID: 141
		internal Button acceptButton;

		// Token: 0x0400008E RID: 142
		private bool _contentLoaded;
	}
}

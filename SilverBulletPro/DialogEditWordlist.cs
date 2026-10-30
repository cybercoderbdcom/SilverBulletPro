using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using SilverBulletPro.Core.Models;

namespace SilverBulletPro
{
	// Token: 0x02000022 RID: 34
	public class DialogEditWordlist : Page, IComponentConnector
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600012C RID: 300 RVA: 0x0000A567 File Offset: 0x00008767
		// (set) Token: 0x0600012D RID: 301 RVA: 0x0000A56F File Offset: 0x0000876F
		public Wordlist WordList { get; private set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0000A578 File Offset: 0x00008778
		// (set) Token: 0x0600012F RID: 303 RVA: 0x0000A580 File Offset: 0x00008780
		public DialogResult DialogResult { get; private set; }

		// Token: 0x06000130 RID: 304 RVA: 0x0000A58C File Offset: 0x0000878C
		public DialogEditWordlist(Wordlist wordlist)
		{
			this.WordList = wordlist;
			this.InitializeComponent();
			foreach (string newItem in GlobalData.Settings.Environment.GetWordlistTypeNames())
			{
				this.wordlistType.Items.Add(newItem);
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000A608 File Offset: 0x00008808
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				this.wordlistName.Text = this.WordList.Name;
				this.wordlistPath.Text = this.WordList.Path;
				this.wordlistPurpose.Text = this.WordList.Purpose;
				this.wordlistType.SelectedItem = this.WordList.Type;
			}
			catch
			{
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000A684 File Offset: 0x00008884
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.DialogResult = DialogResult.Cancel;
				((MainDialog)base.Parent).Close();
			}
			catch
			{
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000A6C0 File Offset: 0x000088C0
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			try
			{
				this.DialogResult = DialogResult.OK;
				this.WordList.Name = this.wordlistName.Text;
				this.WordList.Path = this.wordlistPath.Text;
				this.WordList.Purpose = this.wordlistPurpose.Text;
				this.WordList.Type = this.wordlistType.SelectedItem.ToString();
				((MainDialog)base.Parent).Close();
			}
			catch
			{
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000A758 File Offset: 0x00008958
		private void Page_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			try
			{
				if (e.Key == Key.Return)
				{
					this.Button_Click_1(null, null);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000A78C File Offset: 0x0000898C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialogeditwordlist.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000A7BC File Offset: 0x000089BC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((DialogEditWordlist)target).KeyDown += this.Page_KeyDown;
				((DialogEditWordlist)target).Loaded += this.Page_Loaded;
				return;
			case 2:
				this.wordlistName = (System.Windows.Controls.TextBox)target;
				return;
			case 3:
				this.wordlistPath = (System.Windows.Controls.TextBox)target;
				return;
			case 4:
				this.wordlistType = (System.Windows.Controls.ComboBox)target;
				return;
			case 5:
				this.wordlistPurpose = (System.Windows.Controls.TextBox)target;
				return;
			case 6:
				((System.Windows.Controls.Button)target).Click += this.Button_Click_1;
				return;
			case 7:
				((System.Windows.Controls.Button)target).Click += this.Button_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000097 RID: 151
		internal System.Windows.Controls.TextBox wordlistName;

		// Token: 0x04000098 RID: 152
		internal System.Windows.Controls.TextBox wordlistPath;

		// Token: 0x04000099 RID: 153
		internal System.Windows.Controls.ComboBox wordlistType;

		// Token: 0x0400009A RID: 154
		internal System.Windows.Controls.TextBox wordlistPurpose;

		// Token: 0x0400009B RID: 155
		private bool _contentLoaded;
	}
}

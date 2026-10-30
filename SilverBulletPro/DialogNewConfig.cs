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
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Core.Functions.Files;
using SilverBulletPro.Core.ViewModels;
using SilverBulletPro.Repositories;
using SilverBulletPro.Views.Main.Configs;

namespace SilverBulletPro
{
	// Token: 0x02000025 RID: 37
	public class DialogNewConfig : Page, IComponentConnector
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000147 RID: 327 RVA: 0x0000ABF6 File Offset: 0x00008DF6
		// (set) Token: 0x06000148 RID: 328 RVA: 0x0000ABFE File Offset: 0x00008DFE
		public object Caller { get; set; }

		// Token: 0x06000149 RID: 329 RVA: 0x0000AC08 File Offset: 0x00008E08
		public DialogNewConfig(object caller)
		{
			this.InitializeComponent();
			this.Caller = caller;
			this.authorTextbox.Text = GlobalData.SBSettings.General.DefaultAuthor;
			this.nameTextbox.Focus();
			this.categoryCombobox.Items.Add(ConfigRepository.defaultCategory);
			foreach (object newItem in (from c in GlobalData.ConfigManager.ConfigsCollection
			select c.Category into category
			where category != ConfigRepository.defaultCategory
			select category).Distinct<string>())
			{
				this.categoryCombobox.Items.Add(newItem);
			}
			this.categoryCombobox.SelectedIndex = 0;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000AD14 File Offset: 0x00008F14
		private void acceptButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.Caller.GetType() == typeof(ConfigManager))
			{
				if (this.nameTextbox.Text.Trim() == string.Empty)
				{
					Alert.Error("The name cannot be blank", "Error", false);
					return;
				}
				if (this.nameTextbox.Text != Files.MakeValidFileName(this.nameTextbox.Text, true))
				{
					Alert.Error("The name contains invalid characters", "Error", false);
					return;
				}
				if (string.IsNullOrWhiteSpace(this.categoryCombobox.Text))
				{
					this.categoryCombobox.Text = ConfigRepository.defaultCategory;
				}
				else if (this.categoryCombobox.Text != Files.MakeValidFileName(this.categoryCombobox.Text, true))
				{
					Alert.Error("The category contains invalid characters", "Error", false);
					return;
				}
				try
				{
					string text = this.iconTextbox.Text;
					try
					{
						Convert.FromBase64String(text);
					}
					catch
					{
						try
						{
							if (!string.IsNullOrWhiteSpace(text) && !File.Exists(text))
							{
								text = string.Empty;
							}
							else
							{
								text = ImageExtension.ToBase64(text);
							}
						}
						catch
						{
						}
					}
					((ConfigManager)this.Caller).CreateConfig(this.nameTextbox.Text, this.categoryCombobox.Text, this.authorTextbox.Text, text);
				}
				catch (Exception ex)
				{
					Alert.Exception(ex, "");
					return;
				}
			}
			((MainDialog)base.Parent).Close();
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000AEB0 File Offset: 0x000090B0
		private void OpenIconButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Icon File|*.jpg;*.jpeg;*.jpe;*.bmp;*.png;*.ico"
			};
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = true;
			if ((flag.GetValueOrDefault() == flag2 & flag != null) && openFileDialog.FileName != string.Empty && ImageExtension.AllowedExtensions.Contains(Path.GetExtension(openFileDialog.FileName).ToUpperInvariant()))
			{
				this.iconTextbox.Text = openFileDialog.FileName;
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000AF2C File Offset: 0x0000912C
		private void TextBox_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
					if (array != null && array.Length != 0 && File.Exists(array[0]) && ImageExtension.AllowedExtensions.Contains(Path.GetExtension(array[0]).ToUpperInvariant()))
					{
						((TextBox)sender).Text = array[0];
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000AFB0 File Offset: 0x000091B0
		private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000AFB9 File Offset: 0x000091B9
		private void Page_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.acceptButton_Click(this, new RoutedEventArgs());
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000AFD0 File Offset: 0x000091D0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/dialogs/dialognewconfig.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000B000 File Offset: 0x00009200
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((DialogNewConfig)target).KeyDown += this.Page_KeyDown;
				return;
			case 2:
				this.nameTextbox = (TextBox)target;
				return;
			case 3:
				((Button)target).Click += this.OpenIconButton_Click;
				return;
			case 4:
				this.iconTextbox = (TextBox)target;
				this.iconTextbox.Drop += this.TextBox_Drop;
				this.iconTextbox.PreviewDragOver += this.TextBox_PreviewDragOver;
				return;
			case 5:
				this.categoryCombobox = (ComboBox)target;
				return;
			case 6:
				this.authorTextbox = (TextBox)target;
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

		// Token: 0x040000A8 RID: 168
		internal TextBox nameTextbox;

		// Token: 0x040000A9 RID: 169
		internal TextBox iconTextbox;

		// Token: 0x040000AA RID: 170
		internal ComboBox categoryCombobox;

		// Token: 0x040000AB RID: 171
		internal TextBox authorTextbox;

		// Token: 0x040000AC RID: 172
		internal Button acceptButton;

		// Token: 0x040000AD RID: 173
		private bool _contentLoaded;
	}
}

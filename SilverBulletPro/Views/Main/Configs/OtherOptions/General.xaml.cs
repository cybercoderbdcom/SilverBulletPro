using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Command;
using SilverBulletPro.Core;
using SilverBulletPro.Core.Extensions;
using SilverBulletPro.Extensions;

namespace SilverBulletPro.Views.Main.Configs.OtherOptions
{
	// Token: 0x0200019F RID: 415
	public partial class General : Page
	{
		// Token: 0x06000B8E RID: 2958 RVA: 0x0003DF00 File Offset: 0x0003C100
		public General()
		{
			this.InitializeComponent();
			base.DataContext = (this.settings = GlobalData.ConfigManager.CurrentConfig.Config.Settings);
			this.previewButton.Command = new RelayCommand(new Action(this.ShowPreview), () => !string.IsNullOrWhiteSpace(this.iconTextBox.Text));
			this.categoryComboBox.Items.Add("Default");
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0003DF7C File Offset: 0x0003C17C
		private void AddContinueOnStatuses_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(this.continueOnStatusesComboBox.Text))
				{
					HashSet<string> hashSet = new HashSet<string>(this.settings.ContinueOnStatuses);
					hashSet.Add(this.continueOnStatusesComboBox.Text);
					this.settings.ContinueOnStatuses = hashSet.ToArray<string>();
					this.continueOnStatusesComboBox.SelectedIndex = this.continueOnStatusesComboBox.Items.Count - 1;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0003E004 File Offset: 0x0003C204
		private void RemoveContinueOnStatuses_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.continueOnStatusesComboBox.SelectedIndex != -1)
				{
					HashSet<string> hashSet = new HashSet<string>(this.settings.ContinueOnStatuses);
					hashSet.Remove(this.continueOnStatusesComboBox.Text);
					this.settings.ContinueOnStatuses = hashSet.ToArray<string>();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x0003E06C File Offset: 0x0003C26C
		private void SetIconButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (StringExtension.IsUrl(this.iconTextBox.Text))
				{
					this.settings.Icon = this.iconTextBox.Text;
					this.ChangeIcon();
				}
				else if (StringExtension.IsBase64(this.iconTextBox.Text) || string.IsNullOrWhiteSpace(this.iconTextBox.Text))
				{
					this.settings.Icon = this.iconTextBox.Text;
					this.ChangeIcon();
				}
				else if (!File.Exists(this.iconTextBox.Text))
				{
					Alert.Error("Icon is not exists", "Error", false);
				}
				else
				{
					this.settings.Icon = ImageExtension.ToBase64(this.iconTextBox.Text);
					this.ChangeIcon();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x0003E148 File Offset: 0x0003C348
		private void ChangeIcon()
		{
			try
			{
				if (string.IsNullOrWhiteSpace(this.settings.Icon))
				{
					this.ellipse.Visibility = Visibility.Collapsed;
				}
				else
				{
					this.ellipse.Visibility = Visibility.Visible;
					if (StringExtension.IsUrl(this.settings.Icon))
					{
						using (MemoryStream memoryStream = (MemoryStream)ImageExtension.GetStream(this.settings.Icon))
						{
							this.icon.ImageSource = memoryStream.ToImage();
							this.settings.Icon = StreamExtension.ConvertToBase64(memoryStream);
						}
					}
					if (StringExtension.IsBase64(this.settings.Icon))
					{
						this.icon.ImageSource = ImageExtension.Base64ToBytes(this.settings.Icon).ToImage();
					}
					else if (File.Exists(this.settings.Icon))
					{
						this.settings.Icon = ImageExtension.ToBase64(this.settings.Icon);
						this.icon.ImageSource = ImageExtension.Base64ToBytes(this.settings.Icon).ToImage();
						this.settings.Icon = this.settings.Icon;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0003E2AC File Offset: 0x0003C4AC
		private void TextBox_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (e.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string[] array = e.Data.GetData(DataFormats.FileDrop) as string[];
					if (array != null && array.Length != 0 && File.Exists(array[0]) && ImageExtension.AllowedExtensions.Contains(Path.GetExtension(array[0]).ToUpperInvariant()))
					{
						((TextBox)sender).Text = ImageExtension.ToBase64(array[0]);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0003E334 File Offset: 0x0003C534
		private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x0003E340 File Offset: 0x0003C540
		private void ShowPreview()
		{
			try
			{
				MainDialog mainDialog = null;
				if (StringExtension.IsUrl(this.iconTextBox.Text))
				{
					mainDialog = new MainDialog(new MainDialog.InputDialog
					{
						Dialog = new DialogIconPreview(this, (MemoryStream)ImageExtension.GetStream(this.iconTextBox.Text)),
						Title = "Icon Preview"
					});
				}
				else if (StringExtension.IsBase64(this.iconTextBox.Text))
				{
					mainDialog = new MainDialog(new MainDialog.InputDialog
					{
						Dialog = new DialogIconPreview(this, ImageExtension.Base64ToBytes(this.iconTextBox.Text)),
						Title = "Icon Preview"
					});
				}
				else if (File.Exists(this.iconTextBox.Text))
				{
					this.iconTextBox.Text = ImageExtension.ToBase64(this.iconTextBox.Text);
					mainDialog = new MainDialog(new MainDialog.InputDialog
					{
						Dialog = new DialogIconPreview(this, ImageExtension.Base64ToBytes(this.iconTextBox.Text))
					});
				}
				mainDialog.ShowDialog();
			}
			catch (Exception ex)
			{
				Alert.Exception(ex, "");
			}
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0003E464 File Offset: 0x0003C664
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				this.iconTextBox.Text = this.settings.Icon;
				this.ChangeIcon();
			}
			catch
			{
			}
		}

		// Token: 0x040005B9 RID: 1465
		private ConfigSettings settings;
	}
}

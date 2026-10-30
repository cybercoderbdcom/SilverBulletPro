using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HandyControl.Controls;
using Microsoft.Win32;
using SilverBulletPro.Core;
using SilverBulletPro.ViewModels;
using Xceed.Wpf.Toolkit;

namespace SilverBulletPro.Views.Main.Settings
{
	// Token: 0x02000191 RID: 401
	public class Themes : Page, IComponentConnector
	{
		// Token: 0x06000A10 RID: 2576 RVA: 0x0002ED9C File Offset: 0x0002CF9C
		public Themes()
		{
			this.InitializeComponent();
			base.DataContext = GlobalData.SBSettings.Themes;
			this.SetColors();
			this.SetColorPreviews();
			this.SetImagePreviews();
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x0002EDCC File Offset: 0x0002CFCC
		public void SetColors()
		{
			this.SetAppColorBrush("BackgroundMain", GlobalData.SBSettings.Themes.BackgroundMain);
			this.SetAppColorBrush("BackgroundSecondary", GlobalData.SBSettings.Themes.BackgroundSecondary);
			this.SetAppColorBrush("ForegroundMain", GlobalData.SBSettings.Themes.ForegroundMain);
			this.SetAppColorBrush("ForegroundGood", GlobalData.SBSettings.Themes.ForegroundGood);
			this.SetAppColorBrush("ForegroundBad", GlobalData.SBSettings.Themes.ForegroundBad);
			this.SetAppColorBrush("ForegroundCustom", GlobalData.SBSettings.Themes.ForegroundCustom);
			this.SetAppColorBrush("ForegroundRetry", GlobalData.SBSettings.Themes.ForegroundRetry);
			this.SetAppColorBrush("ForegroundToCheck", GlobalData.SBSettings.Themes.ForegroundToCheck);
			this.SetAppColorBrush("ForegroundMenuSelected", GlobalData.SBSettings.Themes.ForegroundMenuSelected);
			this.SetAppColorBrush("ForegroundMainTabCtrlSelectedItem", GlobalData.SBSettings.Themes.ForegroundMainTabCtrlSelectedItem);
			this.SetAppColorBrush("PrimaryBrush", GlobalData.SBSettings.Themes.PrimaryBrush);
			this.SetAppColorBrush("PrimaryTextBrush", GlobalData.SBSettings.Themes.PrimaryTextBrush);
			this.SetAppColorBrush("BorderBrush", GlobalData.SBSettings.Themes.BorderBrush);
			this.SetAppColor("MainBarColor", GlobalData.SBSettings.Themes.MainBar);
			GlobalData.MainWindow.SetStyle();
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x0002EF50 File Offset: 0x0002D150
		private void SetColorPreviews()
		{
			this.BackgroundMain.SelectedColor = new Color?(this.GetAppColorBrush("BackgroundMain"));
			this.BackgroundSecondary.SelectedColor = new Color?(this.GetAppColorBrush("BackgroundSecondary"));
			this.ForegroundMain.SelectedColor = new Color?(this.GetAppColorBrush("ForegroundMain"));
			this.ForegroundGood.SelectedColor = new Color?(this.GetAppColorBrush("ForegroundGood"));
			this.ForegroundBad.SelectedColor = new Color?(this.GetAppColorBrush("ForegroundBad"));
			this.ForegroundCustom.SelectedColor = new Color?(this.GetAppColorBrush("ForegroundCustom"));
			this.ForegroundRetry.SelectedColor = new Color?(this.GetAppColorBrush("ForegroundRetry"));
			this.ForegroundToCheck.SelectedColor = new Color?(this.GetAppColorBrush("ForegroundToCheck"));
			this.ForegroundMenuSelected.SelectedColor = new Color?(this.GetAppColorBrush("ForegroundMenuSelected"));
			this.PrimaryBrush.SelectedColor = new Color?(this.GetAppColorBrush("PrimaryBrush"));
			this.PrimaryTextBrush.SelectedColor = new Color?(this.GetAppColorBrush("PrimaryTextBrush"));
			this.BorderBrush.SelectedColor = new Color?(this.GetAppColorBrush("BorderBrush"));
			this.MainBar.SelectedColor = new Color?(this.GetAppColor("MainBarColor"));
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x0002F0BC File Offset: 0x0002D2BC
		public void SetAppColorBrush(string resourceName, string color)
		{
			Application.Current.Resources[resourceName] = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x0002F0DE File Offset: 0x0002D2DE
		public void SetAppColor(string resourceName, string color)
		{
			Application.Current.Resources[resourceName] = (Color)ColorConverter.ConvertFromString(color);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x0002F100 File Offset: 0x0002D300
		public Color GetAppColorBrush(string resourceName)
		{
			return ((SolidColorBrush)Application.Current.Resources[resourceName]).Color;
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x0002F11C File Offset: 0x0002D31C
		public Color GetAppColor(string resourceName)
		{
			return (Color)Application.Current.Resources[resourceName];
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0002F134 File Offset: 0x0002D334
		private void SetImagePreviews()
		{
			try
			{
				this.backgroundImagePreview.Source = this.GetImageBrush(GlobalData.SBSettings.Themes.BackgroundImage);
				this.backgroundLogoPreview.Source = this.GetImageBrush(GlobalData.SBSettings.Themes.BackgroundLogo);
			}
			catch
			{
			}
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x0002F198 File Offset: 0x0002D398
		private BitmapImage GetImageBrush(string file)
		{
			BitmapImage result;
			try
			{
				if (File.Exists(file))
				{
					result = new BitmapImage(new Uri(file));
				}
				else
				{
					result = new BitmapImage(new Uri("pack://application:,,,/" + Assembly.GetExecutingAssembly().GetName().Name + ";component/Images/Themes/empty.png", UriKind.Absolute));
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x0002F200 File Offset: 0x0002D400
		private void resetButton_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.SBSettings.Themes.BackgroundMain = "#222";
			GlobalData.SBSettings.Themes.BackgroundSecondary = "#111";
			GlobalData.SBSettings.Themes.ForegroundMain = "#dcdcdc";
			GlobalData.SBSettings.Themes.ForegroundGood = "#adff2f";
			GlobalData.SBSettings.Themes.ForegroundBad = "#ff6347";
			GlobalData.SBSettings.Themes.ForegroundCustom = "#ff8c00";
			GlobalData.SBSettings.Themes.ForegroundRetry = "#ffff00";
			GlobalData.SBSettings.Themes.ForegroundToCheck = "#7fffd4";
			GlobalData.SBSettings.Themes.ForegroundMenuSelected = "#1e90ff";
			GlobalData.SBSettings.Themes.ForegroundMainTabCtrlSelectedItem = "#FFFFFFFF";
			GlobalData.SBSettings.Themes.PrimaryBrush = "#326cf3";
			GlobalData.SBSettings.Themes.PrimaryTextBrush = "#ffffff";
			GlobalData.SBSettings.Themes.BorderBrush = "#3f3f46";
			GlobalData.SBSettings.Themes.MainBar = "#ffffff";
			this.SetColors();
			this.SetColorPreviews();
			this.SetImagePreviews();
		}

		// Token: 0x06000A1A RID: 2586 RVA: 0x0002F338 File Offset: 0x0002D538
		private void loadBackgroundImage_MouseDown(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
			openFileDialog.FilterIndex = 4;
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = false;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				return;
			}
			GlobalData.SBSettings.Themes.BackgroundImage = openFileDialog.FileName;
			this.SetColors();
			this.SetImagePreviews();
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x0002F39C File Offset: 0x0002D59C
		private void loadBackgroundLogo_MouseDown(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
			openFileDialog.FilterIndex = 4;
			bool? flag = openFileDialog.ShowDialog();
			bool flag2 = false;
			if (flag.GetValueOrDefault() == flag2 & flag != null)
			{
				return;
			}
			GlobalData.SBSettings.Themes.BackgroundLogo = openFileDialog.FileName;
			this.SetColors();
			this.SetImagePreviews();
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x0002F400 File Offset: 0x0002D600
		private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
		{
			if (e.NewValue != null)
			{
				GlobalData.SBSettings.Themes.GetType().GetProperty(((ColorPicker)sender).Name.ToString()).SetValue(GlobalData.SBSettings.Themes, this.ColorToHtml(e.NewValue.Value), null);
			}
			this.SetColors();
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x0002F46C File Offset: 0x0002D66C
		private string ColorToHtml(Color color)
		{
			return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x0002F4BF File Offset: 0x0002D6BF
		private void useImagesCheckbox_Checked(object sender, RoutedEventArgs e)
		{
			this.SetColors();
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x0002F4C7 File Offset: 0x0002D6C7
		private void useImagesCheckbox_Unchecked(object sender, RoutedEventArgs e)
		{
			this.SetColors();
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x0002F4CF File Offset: 0x0002D6CF
		private void backgroundImageOpacityUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			GlobalData.MainWindow.SetStyle();
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x0002F4DC File Offset: 0x0002D6DC
		private void RemoveBackgroundImage_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.backgroundImagePreview.Source = null;
				GlobalData.SBSettings.Themes.BackgroundImage = string.Empty;
				this.SetColors();
				this.SetImagePreviews();
			}
			catch
			{
			}
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x0002F52C File Offset: 0x0002D72C
		private void RemoveBackgroundLogo_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.backgroundLogoPreview.Source = null;
				GlobalData.SBSettings.Themes.BackgroundLogo = string.Empty;
				this.SetColors();
				this.SetImagePreviews();
			}
			catch
			{
			}
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0002F57C File Offset: 0x0002D77C
		private void SaveTheme_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog
				{
					Filter = "SB Theme|*.json",
					FileName = "SB Theme"
				};
				bool? flag = saveFileDialog.ShowDialog();
				bool flag2 = false;
				if (!(flag.GetValueOrDefault() == flag2 & flag != null))
				{
					IOManager.SaveSettings<SBSettingsThemes>(saveFileDialog.FileName, GlobalData.SBSettings.Themes);
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x0002F604 File Offset: 0x0002D804
		private void LoadTheme_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "SB Theme|*.json",
					CheckFileExists = true,
					CheckPathExists = true
				};
				bool? flag = openFileDialog.ShowDialog();
				bool flag2 = false;
				if (!(flag.GetValueOrDefault() == flag2 & flag != null))
				{
					GlobalData.SBSettings.Themes = IOManager.LoadSettings<SBSettingsThemes>(openFileDialog.FileName);
					this.SetColors();
					this.SetColorPreviews();
					this.SetImagePreviews();
				}
			}
			catch (Exception ex)
			{
				GlobalData.Logger.Log(ex.Message, 2, true, 0);
			}
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0002F6A0 File Offset: 0x0002D8A0
		private void Snow_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.MainWindow.IsEnabledSnow(false);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x0002F6B0 File Offset: 0x0002D8B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/SilverBulletPro;V1.4.1;component/views/main/settings/silverbullet/themes.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x0002F6E0 File Offset: 0x0002D8E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "7.0.2.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.BackgroundMain = (ColorPicker)target;
				this.BackgroundMain.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 2:
				this.BackgroundSecondary = (ColorPicker)target;
				this.BackgroundSecondary.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 3:
				this.ForegroundMain = (ColorPicker)target;
				this.ForegroundMain.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 4:
				this.ForegroundGood = (ColorPicker)target;
				this.ForegroundGood.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 5:
				this.ForegroundBad = (ColorPicker)target;
				this.ForegroundBad.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 6:
				this.ForegroundCustom = (ColorPicker)target;
				this.ForegroundCustom.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 7:
				this.ForegroundRetry = (ColorPicker)target;
				this.ForegroundRetry.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 8:
				this.ForegroundToCheck = (ColorPicker)target;
				this.ForegroundToCheck.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 9:
				this.ForegroundMenuSelected = (ColorPicker)target;
				this.ForegroundMenuSelected.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 10:
				this.ForegroundMainTabCtrlSelectedItem = (ColorPicker)target;
				this.ForegroundMainTabCtrlSelectedItem.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 11:
				this.PrimaryBrush = (ColorPicker)target;
				this.PrimaryBrush.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 12:
				this.PrimaryTextBrush = (ColorPicker)target;
				this.PrimaryTextBrush.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 13:
				this.BorderBrush = (ColorPicker)target;
				this.BorderBrush.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 14:
				this.MainBar = (ColorPicker)target;
				this.MainBar.SelectedColorChanged += this.ColorPicker_SelectedColorChanged;
				return;
			case 15:
				this.loadThemeButton = (Button)target;
				this.loadThemeButton.Click += this.LoadTheme_Click;
				return;
			case 16:
				this.saveThemeButton = (Button)target;
				this.saveThemeButton.Click += this.SaveTheme_Click;
				return;
			case 17:
				this.resetButton = (Button)target;
				this.resetButton.Click += this.resetButton_Click;
				return;
			case 18:
				this.useImagesCheckbox = (CheckBox)target;
				this.useImagesCheckbox.Checked += this.useImagesCheckbox_Checked;
				this.useImagesCheckbox.Unchecked += this.useImagesCheckbox_Unchecked;
				return;
			case 19:
				this.backgroundImageOpacityUpDown = (NumericUpDown)target;
				return;
			case 20:
				((Button)target).Click += this.RemoveBackgroundImage_Click;
				return;
			case 21:
				((Button)target).Click += this.loadBackgroundImage_MouseDown;
				return;
			case 22:
				this.backgroundImagePreview = (Image)target;
				return;
			case 23:
				((Button)target).Click += this.RemoveBackgroundLogo_Click;
				return;
			case 24:
				((Button)target).Click += this.loadBackgroundLogo_MouseDown;
				return;
			case 25:
				this.backgroundLogoPreview = (Image)target;
				return;
			case 26:
				((CheckBox)target).Click += this.Snow_Click;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040004DA RID: 1242
		internal ColorPicker BackgroundMain;

		// Token: 0x040004DB RID: 1243
		internal ColorPicker BackgroundSecondary;

		// Token: 0x040004DC RID: 1244
		internal ColorPicker ForegroundMain;

		// Token: 0x040004DD RID: 1245
		internal ColorPicker ForegroundGood;

		// Token: 0x040004DE RID: 1246
		internal ColorPicker ForegroundBad;

		// Token: 0x040004DF RID: 1247
		internal ColorPicker ForegroundCustom;

		// Token: 0x040004E0 RID: 1248
		internal ColorPicker ForegroundRetry;

		// Token: 0x040004E1 RID: 1249
		internal ColorPicker ForegroundToCheck;

		// Token: 0x040004E2 RID: 1250
		internal ColorPicker ForegroundMenuSelected;

		// Token: 0x040004E3 RID: 1251
		internal ColorPicker ForegroundMainTabCtrlSelectedItem;

		// Token: 0x040004E4 RID: 1252
		internal ColorPicker PrimaryBrush;

		// Token: 0x040004E5 RID: 1253
		internal ColorPicker PrimaryTextBrush;

		// Token: 0x040004E6 RID: 1254
		internal ColorPicker BorderBrush;

		// Token: 0x040004E7 RID: 1255
		internal ColorPicker MainBar;

		// Token: 0x040004E8 RID: 1256
		internal Button loadThemeButton;

		// Token: 0x040004E9 RID: 1257
		internal Button saveThemeButton;

		// Token: 0x040004EA RID: 1258
		internal Button resetButton;

		// Token: 0x040004EB RID: 1259
		internal CheckBox useImagesCheckbox;

		// Token: 0x040004EC RID: 1260
		internal NumericUpDown backgroundImageOpacityUpDown;

		// Token: 0x040004ED RID: 1261
		internal Image backgroundImagePreview;

		// Token: 0x040004EE RID: 1262
		internal Image backgroundLogoPreview;

		// Token: 0x040004EF RID: 1263
		private bool _contentLoaded;
	}
}

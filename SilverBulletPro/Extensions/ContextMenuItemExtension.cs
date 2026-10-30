using System;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro.IconPacks;

namespace SilverBulletPro.Extensions
{
	// Token: 0x020001F4 RID: 500
	public static class ContextMenuItemExtension
	{
		// Token: 0x06001022 RID: 4130 RVA: 0x0004E198 File Offset: 0x0004C398
		public static MenuItem CreateMenuItem<T>(ContextMenuItemType itemType, string header, RelayCommand<T> command, object commandParameter = null)
		{
			MenuItem menuItem = new MenuItem();
			switch (itemType)
			{
			case ContextMenuItemType.Cut:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 375
				};
				menuItem.InputGestureText = "Ctrl+X";
				break;
			case ContextMenuItemType.Copy:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 343
				};
				menuItem.InputGestureText = "Ctrl+C";
				break;
			case ContextMenuItemType.Paste:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 1036
				};
				menuItem.InputGestureText = "Ctrl+C";
				break;
			case ContextMenuItemType.Delete:
				menuItem.Icon = new PackIconMaterialDesign
				{
					Kind = 215
				};
				menuItem.InputGestureText = "Del";
				break;
			case ContextMenuItemType.SelectAll:
				menuItem.Icon = new PackIconModern
				{
					Kind = 586
				};
				menuItem.InputGestureText = "Ctrl+A";
				break;
			case ContextMenuItemType.Find:
				menuItem.Icon = new PackIconJamIcons
				{
					Kind = 702
				};
				menuItem.InputGestureText = "Ctrl+F";
				break;
			case ContextMenuItemType.Replace:
				menuItem.Icon = new PackIconMaterialDesign
				{
					Kind = 318
				};
				menuItem.InputGestureText = "Ctrl+H";
				break;
			case ContextMenuItemType.Notepad:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 505
				};
				break;
			case ContextMenuItemType.Json:
				menuItem.Icon = new PackIconMaterial
				{
					Kind = 1751
				};
				break;
			case ContextMenuItemType.Start:
				menuItem.Icon = new PackIconVaadinIcons
				{
					Kind = 99
				};
				break;
			case ContextMenuItemType.Stop:
				menuItem.Icon = new PackIconTypicons
				{
					Kind = 182,
					Width = 14.0,
					Height = 16.0
				};
				break;
			}
			menuItem.Header = header;
			menuItem.CommandParameter = commandParameter;
			menuItem.Command = command;
			return menuItem;
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x0004E378 File Offset: 0x0004C578
		public static MenuItem CreateMenuItem(ContextMenuItemType itemType, string header, RoutedUICommand command, object commandParameter = null)
		{
			MenuItem menuItem = new MenuItem();
			switch (itemType)
			{
			case ContextMenuItemType.Cut:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 375
				};
				menuItem.InputGestureText = "Ctrl+X";
				break;
			case ContextMenuItemType.Copy:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 343
				};
				menuItem.InputGestureText = "Ctrl+C";
				break;
			case ContextMenuItemType.Paste:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 1036
				};
				menuItem.InputGestureText = "Ctrl+C";
				break;
			case ContextMenuItemType.Delete:
				menuItem.Icon = new PackIconMaterialDesign
				{
					Kind = 215
				};
				menuItem.InputGestureText = "Del";
				break;
			case ContextMenuItemType.SelectAll:
				menuItem.Icon = new PackIconModern
				{
					Kind = 586
				};
				menuItem.InputGestureText = "Ctrl+A";
				break;
			case ContextMenuItemType.Find:
				menuItem.Icon = new PackIconJamIcons
				{
					Kind = 702
				};
				menuItem.InputGestureText = "Ctrl+F";
				break;
			case ContextMenuItemType.Replace:
				menuItem.Icon = new PackIconMaterialDesign
				{
					Kind = 318
				};
				menuItem.InputGestureText = "Ctrl+H";
				break;
			case ContextMenuItemType.Notepad:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 505
				};
				break;
			case ContextMenuItemType.Start:
				menuItem.Icon = new PackIconVaadinIcons
				{
					Kind = 99
				};
				break;
			case ContextMenuItemType.Stop:
				menuItem.Icon = new PackIconTypicons
				{
					Kind = 182,
					Width = 14.0,
					Height = 16.0
				};
				break;
			}
			menuItem.Header = header;
			menuItem.CommandParameter = commandParameter;
			menuItem.Command = command;
			return menuItem;
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x0004E540 File Offset: 0x0004C740
		public static MenuItem CreateMenuItem(ContextMenuItemType itemType, string header, RelayCommand command, object commandParameter = null)
		{
			MenuItem menuItem = new MenuItem();
			switch (itemType)
			{
			case ContextMenuItemType.Cut:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 375
				};
				menuItem.InputGestureText = "Ctrl+X";
				break;
			case ContextMenuItemType.Copy:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 343
				};
				menuItem.InputGestureText = "Ctrl+C";
				break;
			case ContextMenuItemType.Paste:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 1036
				};
				menuItem.InputGestureText = "Ctrl+C";
				break;
			case ContextMenuItemType.Delete:
				menuItem.Icon = new PackIconMaterialDesign
				{
					Kind = 215
				};
				menuItem.InputGestureText = "Del";
				break;
			case ContextMenuItemType.SelectAll:
				menuItem.Icon = new PackIconModern
				{
					Kind = 586
				};
				menuItem.InputGestureText = "Ctrl+A";
				break;
			case ContextMenuItemType.Find:
				menuItem.Icon = new PackIconJamIcons
				{
					Kind = 702
				};
				menuItem.InputGestureText = "Ctrl+F";
				break;
			case ContextMenuItemType.Replace:
				menuItem.Icon = new PackIconMaterialDesign
				{
					Kind = 318
				};
				menuItem.InputGestureText = "Ctrl+H";
				break;
			case ContextMenuItemType.Notepad:
				menuItem.Icon = new PackIconFontAwesome
				{
					Kind = 505
				};
				break;
			case ContextMenuItemType.Start:
				menuItem.Icon = new PackIconVaadinIcons
				{
					Kind = 99
				};
				break;
			case ContextMenuItemType.Stop:
				menuItem.Icon = new PackIconTypicons
				{
					Kind = 182,
					Width = 14.0,
					Height = 16.0
				};
				break;
			}
			menuItem.Header = header;
			menuItem.CommandParameter = commandParameter;
			menuItem.Command = command;
			return menuItem;
		}
	}
}
